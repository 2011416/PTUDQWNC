using FurnitureShop.Core.Contracts;
using FurnitureShop.Core.DTO.Query;
using FurnitureShop.Core.Entities;
using FurnitureShop.Data.Contexts;
using FurnitureShop.Services.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Services.Blogs.Deliveries
{
    public class DeliveryRepository:IDeliveryRepository
    {
        private readonly StoreDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public DeliveryRepository(StoreDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public async Task<IList<T>> GetDeliveryAsync<T>(
           Func<IQueryable<Delivery>, IQueryable<T>> mapper,
           CancellationToken cancellationToken = default)
        {
            IQueryable<Delivery> deliveries = _context.Set<Delivery>();
            return await mapper(deliveries).ToListAsync(cancellationToken);
        }
        private IQueryable<Delivery> FilterDelivery(DeliveryQuery query)
        {

            IQueryable<Delivery> deliveryQuery = _context.Set<Delivery>()
                .Include(d=> d.User);
                 
            if (!string.IsNullOrWhiteSpace(query.Keyword))
            {
                
                deliveryQuery = deliveryQuery.Where(d=> d.Name== query.Keyword);
            }
            return deliveryQuery;
           
        }
        public async Task<IPagedList<T>> GetPagedDeliveryAsync<T>(
         DeliveryQuery query, IPagingParams pagingParams, Func<IQueryable<Delivery>, IQueryable<T>> mapper, CancellationToken cancellationToken = default)
        {
            IQueryable<Delivery> deliveryQuery = FilterDelivery( query);
            IQueryable<T> queryResult = mapper(deliveryQuery);
            return await queryResult.ToPagedListAsync(pagingParams, cancellationToken);
        }

        public async Task<Delivery> GetDeliveryByIdAsync(int id, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            if (!includeDetails)
            {
                return await _context.Set<Delivery>().FindAsync(id);
            }
            return await _context.Set<Delivery>()
              .Include(d=> d.User)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        }
        public async Task<Delivery> GetCachedDeliveryByIdAsync(int DeliveryId, bool isDetail = false, CancellationToken cancellationToken = default)
        {
            return await _memoryCache.GetOrCreateAsync($"Deliverys.by-id.{DeliveryId}",
                async (entry) =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
                    return await GetDeliveryByIdAsync(DeliveryId, isDetail);
                });
        }
        public async Task<Delivery> GetDeliveryBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            IQueryable<Delivery> deliveryQuery = _context.Set<Delivery>()
                .Include(p => p.User);
             


            if (!string.IsNullOrEmpty(slug))
            {
                deliveryQuery = deliveryQuery.Where(pr => pr.UrlSlug == slug);
            }
            return await deliveryQuery.FirstOrDefaultAsync(cancellationToken);

        }

        public async Task<bool> CheckSlugExistedAsync(int id, string slug, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Delivery>()
                .AnyAsync(x => x.Id != id && x.UrlSlug == slug, cancellationToken);
        }
        public async Task<bool> CreateOrUpdateDeliveryAsync(Delivery delivery, CancellationToken cancellationToken = default)
        {

            if (delivery.Id > 0)
            {
                _context.Update(delivery);
            }
            else
            {
                _context.Add(delivery);
            }
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
        public async Task<bool> DeleteDeliveryByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Deliveries
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync(cancellationToken) > 0;
        }
    }
}
