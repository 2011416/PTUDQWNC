using FurnitureShop.Core.DTO;
using FurnitureShop.Core.Entities;
using FurnitureShop.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Services.Blogs
{
    public class StoreRepository
    {
        private readonly StoreDbContext _context;

        public StoreRepository(StoreDbContext context)
        {
            _context = context;
        }

        //    public async Task<Post> GetPostAsync(int year, int month, string slug, CancellationToken cancellationToken = default)
        //    {
        //        IQueryable<Post> postsQuery = _context.Set<Post>()
        //            .Include(x => x.Category)
        //            .Include(x => x.Author);

        //        if (year > 0)
        //        {
        //            postsQuery = postsQuery.Where(x => x.PostedDate.Year == year);
        //        }

        //        if (month > 0)
        //        {
        //            postsQuery = postsQuery.Where(x => x.PostedDate.Month == month);
        //        }

        //        if (!string.IsNullOrEmpty(slug))
        //        {
        //            postsQuery = postsQuery.Where(x => x.UrlSlug == slug);
        //        }

        //        return await postsQuery.FirstOrDefaultAsync(cancellationToken);
        //    }

        //    public async Task<IList<Post>> GetPopularArticlesAsync(int numPosts, CancellationToken cancellationToken = default)
        //    {
        //        return await _context.Set<Post>()
        //            .Include(x => x.Author)
        //            .Include(x => x.Category)
        //            .OrderByDescending(p => p.ViewCount)
        //            .Take(numPosts)
        //            .ToListAsync(cancellationToken);
        //    }

        //    public async Task<bool> IsPostSlugExistedAsync(int postId, string slug, CancellationToken cancellationToken = default)
        //    {
        //        return await _context.Set<Post>()
        //            .AnyAsync(x => x.Id != postId && x.UrlSlug == slug,
        //                cancellationToken);
        //    }

        //    public async Task IncreaseViewCountAsync(int postId, CancellationToken cancellationToken = default)
        //    {
        //        await _context.Set<Post>()
        //            .Where(x => x.Id == postId)
        //            .ExecuteUpdateAsync(p =>
        //            p.SetProperty(x => x.ViewCount, x => x.ViewCount + 1),
        //            cancellationToken);
        //    }

        public async Task<IList<CategoryItem>> GetCategoriesAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<Category> categories = _context.Set<Category>();
       
            return await categories
                .OrderBy(x => x.Name)
                .Select(x => new CategoryItem()
                {
                    Id = x.Id,
                    Name = x.Name,
                    UrlSlug = x.UrlSlug,
                    Description = x.Description,
                    PostCount = x.Products.Count
                })
                .ToListAsync(cancellationToken);
        }

        //    public async Task<IPagedList<TagItem>> GetPagedTagsAsync(IPagingParams pagingParams, CancellationToken cancellationToken = default)
        //    {
        //        var tagQuery = _context.Set<Tag>()
        //            .Select(x => new TagItem()
        //            {
        //                Id = x.Id,
        //                Name = x.Name,
        //                UrlSlug = x.UrlSlug,
        //                Description = x.Description,
        //                PostCount = x.Posts.Count(p => p.Published)
        //            });

        //        return await tagQuery
        //            .ToPagedListAsync(pagingParams, cancellationToken);
        //    }
    }
}

