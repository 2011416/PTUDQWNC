
using FurnitureShop.Services.Blogs.Categories;
using FurnitureShop.Services.Blogs.Roles;
using FurnitureShop.WebApi.Models;
using FurnitureShop.WebAPI.Models.Category;
using FurnitureShop.WebAPI.Models.Role;
using Mapster;
using MapsterMapper;
using System.Net;

namespace FurnitureShop.WebAPI.Endpoints
{
    public static  class RoleEndpoint
    {
        public static WebApplication MapRoleEndPoints(this WebApplication app)
        {
            var routeGroupBuilder = app.MapGroup("/api/role");
            routeGroupBuilder.MapGet("/all", GetAllRoles)
            .WithName("GetAllRole")
            .Produces<ApiResponse<RoleDto>>();
            routeGroupBuilder.MapGet("/id/{id:int}", GetDetailRoleById)
            .WithName("GetDetailRoleById")
            .Produces<ApiResponse<RoleDto>>();
            routeGroupBuilder.MapGet("/{slug:regex(^[a-z0-9_-]+$)}", GetDetailRoleBySlug)
            .WithName("GetDetailRoleBySlug")
            .Produces<ApiResponse<RoleDto>>();
            return app;
        }
        private static async Task<IResult> GetAllRoles(IRoleRepository roleRepository)
        {
            var role = await roleRepository
                .GetRoleAsync(role => role.ProjectToType<RoleDto>());
            return Results.Ok(ApiResponse.Success(role));
        }
        private static async Task<IResult> GetDetailRoleById(
       int id, IRoleRepository roleRepository, IMapper mapper)
        {
            var role = await roleRepository.GetCachedRoleByIdAsync(id, true);

            var roleQuery = mapper.Map<RoleDto>(role);

            return roleQuery == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy id"))
                : Results.Ok(ApiResponse.Success(mapper.Map<RoleDto>(role)));
        }
        private static async Task<IResult> GetDetailRoleBySlug(
     string  slug, IRoleRepository roleRepository, IMapper mapper)
        {
            var role = await roleRepository.GetRoleBySlugAsync(slug);

            var roleQuery = mapper.Map<RoleDto>(role);

            return roleQuery == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy id"))
                : Results.Ok(ApiResponse.Success(mapper.Map<RoleDto>(role)));
        }
    }
}
