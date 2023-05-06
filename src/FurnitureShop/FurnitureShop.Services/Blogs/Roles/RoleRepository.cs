using FurnitureShop.Core.DTO.Item;
using FurnitureShop.Core.DTO.Query;
using FurnitureShop.Core.Entities;
using FurnitureShop.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Services.Blogs.Roles
{
    public class RoleRepository:IRoleRepository
    {
        private readonly StoreDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public RoleRepository(StoreDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public async Task<IList<T>> GetRoleAsync<T>(
            Func<IQueryable<Role>, IQueryable<T> > mapper,
            CancellationToken cancellationToken = default)
        {
            IQueryable<Role> roles = _context.Set<Role>()
                .Include(r=>r.Users);
            return await mapper(roles).ToListAsync(cancellationToken);
        }
        public async Task<IList<RoleItem>> GetRoleAsync(
        CancellationToken cancellationToken = default)
        {
            return await _context.Set<Role>()
                .OrderBy(a => a.Name)
                .Select(a => new RoleItem()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description
               
                })
                .ToListAsync(cancellationToken);
        }
        private IQueryable<Role> FilterRole(RoleQuery query)
        {
            IQueryable<Role> roleQuery = _context.Set<Role>()
                .Include(r => r.Users);
            if (!string.IsNullOrWhiteSpace(query.UrlSlug))
            {
                roleQuery = roleQuery.Where(r => r.UrlSlug == query.UrlSlug);
            }
           

            return roleQuery;
        }

        public async Task<Role> GetCachedRoleByIdAsync(int roleId, bool roleDetail = false, CancellationToken cancellationToken = default)
        {

            return await _memoryCache.GetOrCreateAsync($"role.by-id.{roleId}",
                async (entry) =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
                    return await GetRoleByIdAsync(roleId, roleDetail);
                });
        }
        public async Task<Role> GetRoleByIdAsync(int roleId, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            if (!includeDetails)
            {
                return await _context.Set<Role>().FindAsync(roleId);
            }
            return await _context.Set<Role>()
                .Include(x => x.Users)

                .FirstOrDefaultAsync(x => x.Id == roleId, cancellationToken);

        }
        public async Task<Role> GetRoleBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            IQueryable<Role> roleQuery = _context.Set<Role>()
                .Include(pr => pr.Users);


            if (!string.IsNullOrEmpty(slug))
            {
                roleQuery = roleQuery.Where(r => r.UrlSlug == slug);
            }
            return await roleQuery.FirstOrDefaultAsync(cancellationToken);

        }
    }
}
