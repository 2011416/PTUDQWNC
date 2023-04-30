using FurnitureShop.Core.Contracts;
using FurnitureShop.Core.DTO.Query;
using FurnitureShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Services.Blogs.Products
{
    public interface IProductRepository
    {
         Task<IList<T>> GetProductAsync<T>(
            Func<IQueryable<Product>, IQueryable<T>> mapper,
            CancellationToken cancellationToken = default);
        Task<IPagedList<T>> GetPagedProductAsync<T>(
         ProductQuery query, IPagingParams pagingParams, Func<IQueryable<Product>, IQueryable<T>> mapper, CancellationToken cancellationToken = default);
        Task<Product> GetCachedProductByIdAsync(int productId, bool isDetail = false, CancellationToken cancellationToken = default);
        Task<Product> GetProductByIdAsync(int productId, bool includeDetails = false, CancellationToken cancellationToken = default);
        Task<Product> GetProductBySlugAsync(string slug, CancellationToken cancellationToken = default);
        Task<bool> CheckSlugExistedAsync(int id, string slug, CancellationToken cancellationToken = default);
        Task<bool> DeleteProductByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Product> CreateOrUpdateProductAsync(
        Product product, IEnumerable<string> categories,
        CancellationToken cancellationToken = default);


    }
}
