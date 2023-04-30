using FurnitureShop.Core.Contracts;
using FurnitureShop.Core.DTO.Query;
using FurnitureShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Services.Blogs.Categories
{
    public interface ICategoryRepository
    {
        Task<IList<T>> GetCategoriesAsync<T>(
            Func<IQueryable<Category>, IQueryable<T>> mapper,
            CancellationToken cancellationToken = default);
        Task<IPagedList<T>> GetPagedCategoriesAsync<T>(
            CategoryQuery query, IPagingParams pagingParams,
            Func<IQueryable<Category>, IQueryable<T>> mapper,
            CancellationToken cancellationToken = default);
        Task<bool> IsSlugExistedAsync(int id, string slug, CancellationToken cancellationToken = default);
        Task<bool> DeleteCategoryByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Category> GetCategoryBySlugAsync(string slug, CancellationToken cancellationToken = default);
        Task<Category> GetCategoryByIdIsDetailAsync(int id, bool isDetail = false, CancellationToken cancellationToken = default);
        Task<bool> CreateOrUpdateCategoryAsync(Category category, CancellationToken cancellationToken = default);
        Task<Product> GetProductSlugAsync(string slug, CancellationToken cancellationToken = default);

    }
}
