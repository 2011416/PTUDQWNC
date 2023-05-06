using FurnitureShop.Core.Collections;
using FurnitureShop.Core.DTO.Item;
using FurnitureShop.Core.DTO.Query;
using FurnitureShop.Core.Entities;
using FurnitureShop.Services.Blogs.Categories;
using FurnitureShop.WebApi.Models;
using FurnitureShop.WebAPI.Models.Category;
using FurnitureShop.WebAPI.Models.Product;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SlugGenerator;
using System.Net;
using System.Reflection.Metadata;

namespace FurnitureShop.WebAPI.Endpoints
{
    public static class CategoryEndpoint
    {
        public static WebApplication MapCategoryEndpoints(this WebApplication app)
        {
            var routeGroupBuilder = app.MapGroup("/api/categories");
            routeGroupBuilder.MapGet("/all", GetAllCategories)
            .WithName("GetAllCategories")
            .Produces<ApiResponse<CategoryDto>>();
            routeGroupBuilder.MapGet("/", GetCategories)

    .WithName("GetCategories")
    .Produces<ApiResponse<PaginationResult<CategoryDto>>>();

           
            routeGroupBuilder.MapGet("/id/{id:int}", GetDetailCategoryById)
            .WithName("GetDetailCategoryById")
            .Produces<ApiResponse<CategoryDto>>();
            routeGroupBuilder.MapGet("/slug/{slug:regex(^[a-z0-9_-]+$)}", GetDetailCategoryBySlug)
            .WithName("GetDetailCategoryBySlug")
            .Produces<ApiResponse<CategoryDto>>();
            routeGroupBuilder.MapDelete("/{id:int}", DeleteCategory)
          .WithName("DeleteCategory")
          .Produces(401)
          .Produces<ApiResponse<string>>();
          
            routeGroupBuilder.MapPost("/", AddOrUpdateCategories)
                .WithName("AddNewCategory")
                .Accepts<CategoryEditModel>("multipart/form-data")
                .Produces(401)
                .Produces<ApiResponse<CategoryItem>>();
            routeGroupBuilder.MapPut("/", AddOrUpdateCategories)
               .WithName("UpdateCategory")
               .Accepts<CategoryEditModel>("multipart/form-data")
               .Produces(401)
               .Produces<ApiResponse<CategoryItem>>();

            return app;
        }

        private static async Task<IResult> GetAllCategories(ICategoryRepository categoryRepository)
        {
            var category = await categoryRepository
                .GetCategoriesAsync(category => category.ProjectToType<CategoryDto>());
            return Results.Ok(ApiResponse.Success(category));
        }

        private static async Task<IResult> GetCategories(
            [AsParameters] CategoryFilterModel model,
            ICategoryRepository categoryRepository,
            IMapper mapper
            )
        {
            var categoryQuery = mapper.Map<CategoryQuery>(model);
            var categoryList = await categoryRepository.GetPagedCategoriesAsync<CategoryDto>(
                categoryQuery, model, category => category.ProjectToType<CategoryDto>());
            var pagingnationResult = new PaginationResult<CategoryDto>(categoryList);
            return Results.Ok(ApiResponse.Success(pagingnationResult));

        }
        private static async Task<IResult> GetDetailCategoryById(
        int id, ICategoryRepository categoryRepository, IMapper mapper)
        {
            var category = await categoryRepository.GetCategoryByIdIsDetailAsync(id, true);

            var CategoryQuery = mapper.Map<CategoryDto>(category);

            return CategoryQuery == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy id"))
                : Results.Ok(ApiResponse.Success(mapper.Map<CategoryDto>(category)));
        }
        private static async Task<IResult> GetDetailCategoryBySlug(
        [FromRoute] string slug,
        ICategoryRepository categoryRepository,
        IMapper mapper)
        {
            var categoryList = await categoryRepository.GetCategoryBySlugAsync(slug);
            var CategoryQuery = mapper.Map<CategoryDto>(categoryList);

            return CategoryQuery == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, "Không tìm thấy slug"))
                : Results.Ok(ApiResponse.Success(mapper.Map<CategoryDto>(categoryList)));
        }

        private static async Task<IResult> DeleteCategory(
       int id, ICategoryRepository categoryRepository)
        {
            return await categoryRepository.DeleteCategoryByIdAsync(id)
                ? Results.Ok(ApiResponse.Success("Category đã được xoá ", HttpStatusCode.NoContent))
                : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, "Khong tim thay category"));
        }

        private static async  Task<IResult> AddOrUpdateCategories(
            HttpContext context,
            ICategoryRepository categoryRepository,
            IMapper mapper
            )
        {
            var model = await CategoryEditModel.BindAsync(context);
            var slug = model.Name.GenerateSlug();
            if(await categoryRepository.IsSlugExistedAsync(model.Id, slug))
            {
                return Results.Ok(ApiResponse.Fail(
                   HttpStatusCode.Conflict, $"Slug {slug} đã được sử dụng cho bài viết category khác"));
            }
            var category = model.Id> 0 ? await categoryRepository.GetCategoryByIdIsDetailAsync(model.Id) : null;
            if(category == null) { 
                category= new Category();
            }

            category.Name = model.Name;
            category.Description= model.Description;
            category.UrlSlug = model.Name.GenerateSlug();

            await categoryRepository.CreateOrUpdateCategoryAsync(category);
            return Results.Ok(ApiResponse.Success(mapper.Map<CategoryItem>(category), HttpStatusCode.Created));
        }



    }
}
