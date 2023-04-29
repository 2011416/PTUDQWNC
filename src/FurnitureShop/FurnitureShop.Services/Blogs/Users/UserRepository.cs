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

namespace FurnitureShop.Services.Blogs.Users
{
    public class UserRepository:IUserRepository
    {
        private readonly BlogDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public UserRepository(BlogDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public async Task<IList<T>> GetUserAsync<T>(
            Func<IQueryable<User> , IQueryable<T>> mapper,
            CancellationToken cancellationToken= default)
        {
            IQueryable<User> users = _context.Set<User>();
               return await mapper(users).ToListAsync(cancellationToken);
        }
       private IQueryable<User> FilterUser(UserQuery query) {

            IQueryable<User> userQuery = _context.Set<User>()
                    .Include(p=> p.Role)
                   .Include(pr => pr.Products)
                   .Include(pr => pr.Deliveries);
            if (!string.IsNullOrWhiteSpace(query.Keyword))
            {
                userQuery = userQuery.Where(u=> u.Name.Contains(query.Keyword)
                || u.Adress.Contains(query.Keyword)
                ||u.UrlSlug.Contains(query.Keyword)
                || u.Email.Contains(query.Keyword));
            }
            if (!string.IsNullOrEmpty(query.DeliverSlug))
            {
                userQuery = userQuery.Where(u=> u.Deliveries.Any(d=> d.UrlSlug==query.DeliverSlug));
            }
            if (!string.IsNullOrEmpty(query.RoleSlug))
            {
                userQuery = userQuery.Where(u => u.Role.UrlSlug== query.DeliverSlug);
            }
            return userQuery;
        }

        public async Task<IPagedList<T>> GetPagedUserAsync<T>(
          UserQuery query, IPagingParams pagingParams, Func<IQueryable<User>, IQueryable<T>> mapper, CancellationToken cancellationToken = default)
        {
            IQueryable<User> userFindQuery = FilterUser(query);
            IQueryable<T> queryResult = mapper(userFindQuery);
            return await queryResult.ToPagedListAsync(pagingParams, cancellationToken);
        }

        public async Task<User> GetCachedUserByIdAsync(int userId, bool userDetail = false, CancellationToken cancellationToken = default)
        {
            return await _memoryCache.GetOrCreateAsync($"Users.by-id.{userId}",
                async (entry) =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
                    return await GetUserByIdAsync(userId, userDetail);
                });
        }
        public async Task<User> GetUserByIdAsync(int userId, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            if (!includeDetails)
            {
                return await _context.Set<User>().FindAsync(userId);
            }
            return await _context.Set<User>()
                .Include(u=> u.Role)
               .Include(u => u.Products)
               .Include(u => u.Deliveries)
                .FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);

        }
        public async Task<User> GetUserBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            IQueryable<User> userQuery = _context.Set<User>()
                .Include(u=> u.Role)
                .Include(u => u.Products)
               .Include(u => u.Deliveries);

            if (!string.IsNullOrEmpty(slug))
            {
                userQuery = userQuery.Where(pr => pr.UrlSlug == slug);
            }
            return await userQuery.FirstOrDefaultAsync(cancellationToken);

        }
        public async Task<bool> CheckSlugExistedAsync(int id, string slug, CancellationToken cancellationToken = default)
        {
            return await _context.Set<User>()
                .AnyAsync(x => x.Id != id && x.UrlSlug == slug, cancellationToken);
        }
        public async Task<bool> CreateOrUpdateUserAsync(User user, CancellationToken cancellationToken = default)
        {

            if (user.Id > 0)
            {
                _context.Update(user);
            }
            else
            {
                _context.Add(user);
            }
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> DeleteUserByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Users
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync(cancellationToken) > 0;
        }
        public async Task<bool> IsSlugExistedAsync(int id, string slug, CancellationToken cancellationToken = default)
        {
            return await _context.Set<User>()
                .AnyAsync(x => x.Id != id && x.UrlSlug == slug, cancellationToken);
        }

    }
}
