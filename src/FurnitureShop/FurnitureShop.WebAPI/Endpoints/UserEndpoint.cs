using FurnitureShop.Core.Collections;
using FurnitureShop.Core.DTO.Item;
using FurnitureShop.Core.DTO.Query;
using FurnitureShop.Core.Entities;
using FurnitureShop.Services.Blogs.Categories;
using FurnitureShop.Services.Blogs.Users;
using FurnitureShop.WebApi.Models;
using FurnitureShop.WebAPI.Models.Category;
using FurnitureShop.WebAPI.Models.Product;
using FurnitureShop.WebAPI.Models.Role;
using FurnitureShop.WebAPI.Models.User;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SlugGenerator;
using System.Net;

namespace FurnitureShop.WebAPI.Endpoints
{
    public static class UserEndpoint
    {
        public static WebApplication MapUserEndpoints(this WebApplication app)
        {
            var routeGroupBuilder = app.MapGroup("/api/user");
            routeGroupBuilder.MapGet("/all", GetAllUser)
            .WithName("GetAllUser")
            .Produces<ApiResponse<UserDto>>();
            routeGroupBuilder.MapGet("/", GetUsers)
            .WithName("GetUser")
            .Produces<ApiResponse<PaginationResult<UserDto>>>();

            routeGroupBuilder.MapGet("/{id:int}", GetDetailUserById)
           .WithName("GetDetailUserById")
           .Produces<ApiResponse<UserDto>>();

      
            routeGroupBuilder.MapGet("/byslug/{slug:regex(^[a-z0-9_-]+$)}", GetDetailUserBySlug)
                .WithName("GetDetailUserBySlug")
                .Produces<ApiResponse<UserDto>>();

           
            routeGroupBuilder.MapPost("/", AddOrUpdateUsers)
                .WithName("AddOrUpdateUser")
                .Accepts<UserEditModel>("multipart/form-data")
                .Produces(401)
                .Produces<ApiResponse<UserDto>>();
            routeGroupBuilder.MapPut("/", AddOrUpdateUsers)
               .WithName("UpdateUser")
               .Accepts<UserEditModel>("multipart/form-data")
               .Produces(401)
               .Produces<ApiResponse<UserDto>>();


            routeGroupBuilder.MapDelete("/{id:int}", DeleteUser)
                .WithName("DeleteAnUser")
                .Produces(401)
                .Produces<ApiResponse<string>>();

            return app;
        }

        private static async Task<IResult> GetAllUser(
            IUserRepository userRepository)
        {
            var user = await userRepository.GetUserAsync(user => user.ProjectToType<UserDto>());
            return Results.Ok(ApiResponse.Success(user));
        }
        public static async Task<IResult> GetUsers(
          [AsParameters] UserFilterModel model,
          IUserRepository userRepository,
          IMapper mapper)
        {
            var userQuery = mapper.Map<UserQuery>(model);

            var projectList = await userRepository.GetPagedUserAsync<UserDto>(userQuery, model,
            projects => projects.ProjectToType<UserDto>());

            var pagingnationResult = new PaginationResult<UserDto>(projectList);

            return Results.Ok(ApiResponse.Success(pagingnationResult));
        }
        private static async Task<IResult> GetDetailUserById(
       int id, IUserRepository userRepository, IMapper mapper)
        {
            var user = await userRepository.GetCachedUserByIdAsync(id, true);

            var userQuery = mapper.Map<UserDto>(user);

            return userQuery == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy id"))
                : Results.Ok(ApiResponse.Success(mapper.Map<UserDto>(user)));
        }
        private static async Task<IResult> GetDetailUserBySlug(
       [FromRoute] string slug,
       IUserRepository userRepository,
       IMapper mapper)
        {
            var UserList = await userRepository.GetUserBySlugAsync(slug);
            var UserQuery = mapper.Map<UserDto>(UserList);

            return UserQuery == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, "Không tìm thấy slug"))
                : Results.Ok(ApiResponse.Success(mapper.Map<UserDto>(UserList)));
        }
        private static async Task<IResult> AddOrUpdateUsers(
             HttpContext context,
             IUserRepository userRepository,
             IMapper mapper
             )
        {
            var model = await UserEditModel.BindAsync(context);
            var slug = model.Name.GenerateSlug();
            if (await userRepository.IsSlugExistedAsync(model.Id, slug))
            {
                return Results.Ok(ApiResponse.Fail(
                   HttpStatusCode.Conflict, $"Slug {slug} đã được sử dụng cho bài viết user khác"));
            }
            var user = model.Id > 0 ? await userRepository.GetCachedUserByIdAsync(model.Id) : null;
            if (user == null)
            {
                user = new User();
            }

            user.Name = model.Name;
            user.Password = model.Password;
            user.UrlSlug = model.Name.GenerateSlug();
            user.Email = model.Email;
            user.phoneNumber = model.phoneNumber;
            user.Adress= model.Adress;
            user.Role.Id= model.RoleId;

            await userRepository.CreateOrUpdateUserAsync(user);
            return Results.Ok(ApiResponse.Success(mapper.Map<UserDto>(user), HttpStatusCode.Created));
        }
        private static async Task<IResult> DeleteUser(
       int id, IUserRepository userRepository)
        {
            return await userRepository.DeleteUserByIdAsync(id)
                ? Results.Ok(ApiResponse.Success("User đã được xoá ", HttpStatusCode.NoContent))
                : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, "Khong tim thay user"));
        }

    }
    }

