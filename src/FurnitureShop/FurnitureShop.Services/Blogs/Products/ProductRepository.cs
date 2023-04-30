using Azure;
using FurnitureShop.Core.Contracts;
using FurnitureShop.Core.DTO.Item;
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

namespace FurnitureShop.Services.Blogs.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly BlogDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public ProductRepository(BlogDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }
        public async Task<IList<T>> GetProductAsync<T>(
            Func<IQueryable<Product>, IQueryable<T>> mapper,
            CancellationToken cancellationToken = default)
        {
            IQueryable<Product> products = _context.Set<Product>();
            return await mapper(products).ToListAsync(cancellationToken);
        }

        private IQueryable<Product> FilterProduct(ProductQuery query)
        {

            IQueryable<Product> productQuery = _context.Set<Product>()
                  .Include(p => p.Categories)
                  .Include(p=> p.User);
           if(!string.IsNullOrWhiteSpace(query.Keyword))
            {
               productQuery = productQuery.Where(p=> p.Name.Contains(query.Keyword)
               || p.Collection.Contains(query.Keyword)
               || p.Material.Contains(query.Keyword)
               || p.Description.Contains(query.Keyword)
               || p.Size.Contains(query.Keyword)
               || p.Price.Contains(query.Keyword));

            }
           if(query.UserId> 0)
            {
                productQuery = productQuery.Where(p=> p.UserId == query.UserId);
            }
            return productQuery;
        }
        public async Task<IPagedList<T>> GetPagedProductAsync<T>(
         ProductQuery query, IPagingParams pagingParams, Func<IQueryable<Product>, IQueryable<T>> mapper, CancellationToken cancellationToken = default)
        {
            IQueryable<Product> productFindQuery = FilterProduct(query);
            IQueryable<T> queryResult = mapper(productFindQuery);
            return await queryResult.ToPagedListAsync(pagingParams, cancellationToken);
        }
        public async Task<Product> GetCachedProductByIdAsync(int productId, bool isDetail = false, CancellationToken cancellationToken = default)
        {
            return await _memoryCache.GetOrCreateAsync($"Products.by-id.{productId}",
                async (entry) =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
                    return await GetProductByIdAsync(productId, isDetail);
                });
        }
        public async Task<Product> GetProductByIdAsync(int productId, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            if (!includeDetails)
            {
                return await _context.Set<Product>().FindAsync(productId);
            }
            return await _context.Set<Product>()
               .Include(p=> p.Categories)
               .Include(p=> p.User)
                .FirstOrDefaultAsync(x => x.Id == productId, cancellationToken);

        }

        public async Task<Product> GetProductBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            IQueryable<Product> productQuery = _context.Set<Product>()
                .Include(p => p.User)
                .Include(p => p.Categories);
                

            if (!string.IsNullOrEmpty(slug))
            {
                productQuery = productQuery.Where(pr => pr.UrlSlug == slug);
            }
            return await productQuery.FirstOrDefaultAsync(cancellationToken);

        }

        public async Task<bool> CheckSlugExistedAsync(int id, string slug, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Product>()
                .AnyAsync(x => x.Id != id && x.UrlSlug == slug, cancellationToken);
        }
        public async Task<bool> DeleteProductByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Products
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync(cancellationToken) > 0;
        }

        public async Task<Product> CreateOrUpdateProductAsync(
        Product product, IEnumerable<string> categories,
        CancellationToken cancellationToken = default)
        {
            if (product.Id > 0)
            {
                await _context.Entry(product).Collection(x => x.Categories).LoadAsync(cancellationToken);
            }
            else
            {
                product.Categories = new List<Category>();
            }

            foreach (var categoryName in categories)
            {
                if (string.IsNullOrWhiteSpace(categoryName)) continue;
                if (product.Categories.Any(x => x.Name == categoryName)) continue;

                var category = await _context.Set<Category>()
                    .FirstOrDefaultAsync(x => x.Name == categoryName, cancellationToken);

                if (category == null)
                {
                    category = new Category()
                    {
                        Name = categoryName,
                        Description = categoryName,
                        UrlSlug = categoryName.GenerateSlug()
                    };

                }

                product.Categories.Add(category);
            }

            product.Categories = product.Categories.Where(t => categories.Contains(t.Name)).ToList();

            if (product.Id > 0)
                _context.Update(product);
            else
                _context.Add(product);

            await _context.SaveChangesAsync(cancellationToken);

            return product;
        }


    }
}
