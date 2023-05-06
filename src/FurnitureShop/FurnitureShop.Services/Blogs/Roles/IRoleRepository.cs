using FurnitureShop.Core.DTO.Item;
using FurnitureShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Services.Blogs.Roles
{
    public interface IRoleRepository
    {
        Task<IList<T>> GetRoleAsync<T>(
            Func<IQueryable<Role>, IQueryable<T>> mapper,
            CancellationToken cancellationToken = default);
        Task<Role> GetCachedRoleByIdAsync(int roleId, bool roleDetail = false, CancellationToken cancellationToken = default);
        Task<Role> GetRoleByIdAsync(int roleId, bool includeDetails = false, CancellationToken cancellationToken = default);
        Task<Role> GetRoleBySlugAsync(string slug, CancellationToken cancellationToken = default);
        Task<IList<RoleItem>> GetRoleAsync(
        CancellationToken cancellationToken = default);
    }
}
