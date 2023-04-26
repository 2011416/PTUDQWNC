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
using System.Net;

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
            routeGroupBuilder.MapGet("/{id:int}", GetDetailCategoryById)
            .WithName("GetDetailCategoryById")
            .Produces<ApiResponse<CategoryDto>>();
            routeGroupBuilder.MapGet("/byslug/{slug:regex(^[a-z0-9_-]+$)}", GetDetailCategoryBySlug)
            .WithName("GetDetailCategoryBySlug")
            .Produces<ApiResponse<CategoryDto>>();

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

    }
}
