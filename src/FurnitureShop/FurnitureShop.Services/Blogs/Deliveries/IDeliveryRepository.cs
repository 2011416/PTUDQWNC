using FurnitureShop.Core.Contracts;
using FurnitureShop.Core.DTO.Query;
using FurnitureShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Services.Blogs.Deliveries
{
    public interface IDeliveryRepository
    {
        Task<IList<T>> GetDeliveryAsync<T>(
           Func<IQueryable<Delivery>, IQueryable<T>> mapper,
           CancellationToken cancellationToken = default);
        Task<IPagedList<T>> GetPagedDeliveryAsync<T>(
         DeliveryQuery query, IPagingParams pagingParams, Func<IQueryable<Delivery>, IQueryable<T>> mapper, CancellationToken cancellationToken = default);
        Task<Delivery> GetDeliveryByIdAsync(int id, bool includeDetails = false, CancellationToken cancellationToken = default);
        Task<Delivery> GetCachedDeliveryByIdAsync(int DeliveryId, bool isDetail = false, CancellationToken cancellationToken = default);
        Task<Delivery> GetDeliveryBySlugAsync(string slug, CancellationToken cancellationToken = default);
        Task<bool> CheckSlugExistedAsync(int id, string slug, CancellationToken cancellationToken = default);
        Task<bool> CreateOrUpdateDeliveryAsync(Delivery delivery, CancellationToken cancellationToken = default);
        Task<bool> DeleteDeliveryByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
