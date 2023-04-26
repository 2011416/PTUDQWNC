using FurnitureShop.Core.Contracts;
using FurnitureShop.Core.DTO.Query;
using FurnitureShop.Core.Entities;
using FurnitureShop.Data.Contexts;
using FurnitureShop.Services.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SlugGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Services.Blogs.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BlogDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public CategoryRepository(BlogDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public async Task<IList<T>> GetCategoriesAsync<T>(
            Func<IQueryable<Category>, IQueryable<T>> mapper,
            CancellationToken cancellationToken = default)
        {
            IQueryable<Category> categories = _context.Set<Category>()
                .Include(c => c.Products);
            return await mapper(categories).ToListAsync(cancellationToken);
        }





        private IQueryable<Category> FilterCategory(
            CategoryQuery query
            )
        {
            IQueryable<Category> categories = _context.Set<Category>()
                .Include(c => c.Products);
            if (!string.IsNullOrWhiteSpace(query.Keyword))
            {
                categories = categories.Where(
                    c => c.Name.Contains(query.Keyword)
                    || c.UrlSlug.Contains(query.Keyword)
                    || c.Description.Contains(query.Keyword));

            }

            if (!string.IsNullOrWhiteSpace(query.UrlSlug))
            {
                categories = categories.Where(c => c.UrlSlug == query.UrlSlug);
            }
            if (!string.IsNullOrWhiteSpace(query.ProductSlug))
            {
                categories = categories.Where(c => c.Products.Any(p => p.UrlSlug == query.ProductSlug));
            }

            return categories;
        }

        public async Task<IPagedList<T>> GetPagedCategoriesAsync<T>(
            CategoryQuery query, IPagingParams pagingParams,
            Func<IQueryable<Category>, IQueryable<T>> mapper,
            CancellationToken cancellationToken = default)
        {
            IQueryable<Category> categoryQuery = FilterCategory(query);
            IQueryable<T> queryResult = mapper(categoryQuery);
            return await queryResult.ToPagedListAsync(pagingParams, cancellationToken);
        }
        public async Task<bool> IsSlugExistedAsync(int id, string slug, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Category>()
                .AnyAsync(x => x.Id != id && x.UrlSlug == slug, cancellationToken);
        }
        public async Task<bool> DeleteCategoryByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Categories
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync(cancellationToken) > 0;
        }
        public async Task<Category> GetCategoryBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Category>().Include(u => u.Products)
                .FirstOrDefaultAsync(a => a.UrlSlug == slug, cancellationToken);
        }
        public async Task<Category> GetCategoryByIdIsDetailAsync(int id, bool isDetail = false, CancellationToken cancellationToken = default)
        {
            if (!isDetail)
            {
                return await _context.Set<Category>().FindAsync(id);
            }
            return await _context.Set<Category>().Where(a => a.Id == id).FirstOrDefaultAsync(cancellationToken);
        }
        public async Task<Product> GetProductSlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            IQueryable<Product> userQuery = _context.Set<Product>()
                .Where(p => p.UrlSlug == slug);

            return await userQuery.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> CreateOrUpdateCategoryAsync(Category category, IEnumerable<string> products, CancellationToken cancellationToken = default)
        {
            if (category.Id > 0)
            {
                await _context.Entry(category).Collection(x => x.Products).LoadAsync(cancellationToken);
            }
            else
            {
                category.Products = new List<Product>();
            }

            var validProduct = products.Where(x => !string.IsNullOrEmpty(x))
                .Select(x => new
                {
                    Name = x,
                    Slug = x.GenerateSlug(),
                })
                .GroupBy(x => x.Slug)
                .ToDictionary(g => g.Key, g => g.First().Name);

            foreach (var item in validProduct)
            {
                if (category.Products.Any(x => string.Compare(x.UrlSlug, item.Key, StringComparison.InvariantCultureIgnoreCase) == 0)) continue;

                var users = await GetProductSlugAsync(item.Key, cancellationToken) ?? new Product()
                {
                    Name = item.Value,
                    Price = item.Value,
                    UrlSlug = item.Key,
                };

                category.Products.Add(users);
            }
            category.Products = category.Products.Where(u => validProduct.ContainsKey(u.UrlSlug)).ToList();

            if (category.Id > 0)
            {
                _context.Update(category);
            }
            else
            {
                _context.Add(category);
            }
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
    
