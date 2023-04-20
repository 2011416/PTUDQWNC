using FurnitureShop.Core.Contracts;
using FurnitureShop.Core.DTO;
using FurnitureShop.Core.Entities;
using FurnitureShop.Data.Contexts;
using FurnitureShop.Services.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Services.Blogs
{
    public class StoreRepository : IStoreRepository
    {
        private readonly StoreDbContext _context;

        public StoreRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductAsync(int year, int month, string slug, CancellationToken cancellationToken = default)
        {
            IQueryable<Product> productsQuery = _context.Set<Product>()
                .Include(x => x.Category)
                .Include(x => x.Producer);

            if (year > 0)
            {
                productsQuery = productsQuery.Where(x => x.PostedDate.Year == year);
            }

            if (month > 0)
            {
                productsQuery = productsQuery.Where(x => x.PostedDate.Month == month);
            }

            if (!string.IsNullOrEmpty(slug))
            {
                productsQuery = productsQuery.Where(x => x.UrlSlug == slug);
            }

            return await productsQuery.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IList<Product>> GetPopularProductsAsync(int num, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Product>()
                .Include(x => x.Producer)
                .Include(x => x.Category)
                .OrderByDescending(p => p.ViewCount)
                .Take(num)
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> IsPostSlugExistedAsync(int productId, string slug, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Product>()
                .AnyAsync(x => x.Id != productId && x.UrlSlug == slug,
                    cancellationToken);
        }

        public async Task IncreaseViewCountAsync(int productId, CancellationToken cancellationToken = default)
        {
            await _context.Set<Product>()
                .Where(x => x.Id == productId)
                .ExecuteUpdateAsync(p =>
                p.SetProperty(x => x.ViewCount, x => x.ViewCount + 1),
                cancellationToken);
        }

        public async Task<IList<CategoryItem>> GetCategoriesAsync(bool showOnMenu = false, CancellationToken cancellationToken = default)
        {
            IQueryable<Category> categories = _context.Set<Category>();

            if (showOnMenu)
            {
                categories = categories.Where(x => x.ShowOnMenu);
            }

            return await categories
                .OrderBy(x => x.Name)
                .Select(x => new CategoryItem()
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlSlug = x.UrlSlug,
                    Description = x.Description,
                    ShowOnMenu = x.ShowOnMenu,
                    PostCount = x.Products.Count
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<IPagedList<TagItem>> GetPagedTagsAsync(IPagingParams pagingParams, CancellationToken cancellationToken = default)
        {
            var tagQuery = _context.Set<Tag>()
                .Select(x => new TagItem()
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlSlug = x.UrlSlug,
                    Description = x.Description,
                    ProductCount = x.Products.Count
                });

            return await tagQuery
                .ToPagedListAsync(pagingParams, cancellationToken);
        }
    }
}

