using FurnitureShop.Core.Contracts;
using FurnitureShop.Core.DTO.Query;
using FurnitureShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Services.Blogs.Users

{
    public interface IUserRepository
    {
        Task<IList<T>> GetUserAsync<T>(
            Func<IQueryable<User>, IQueryable<T>> mapper,
            CancellationToken cancellationToken = default);

        Task<IPagedList<T>> GetPagedUserAsync<T>(
              UserQuery query, IPagingParams pagingParams, Func<IQueryable<User>, IQueryable<T>> mapper, CancellationToken cancellationToken = default);
         Task<User> GetCachedUserByIdAsync(int userId, bool userDetail = false, CancellationToken cancellationToken = default);

        Task<User> GetUserByIdAsync(int userId, bool includeDetails = false, CancellationToken cancellationToken = default);
        Task<User> GetUserBySlugAsync(string slug, CancellationToken cancellationToken = default);
        Task<bool> CheckSlugExistedAsync(int id, string slug, CancellationToken cancellationToken = default);
        Task<bool> CreateOrUpdateUserAsync(User user, CancellationToken cancellationToken = default);
        Task<bool> IsSlugExistedAsync(int id, string slug, CancellationToken cancellationToken = default);
        Task<bool> DeleteUserByIdAsync(int id, CancellationToken cancellationToken = default);

    }
}
