using FurnitureShop.Core.Collections;
using FurnitureShop.Core.DTO.Item;
using FurnitureShop.Core.DTO.Query;
using FurnitureShop.Core.Entities;
using FurnitureShop.Services.Blogs.Products;
using FurnitureShop.Services.Blogs.Users;
using FurnitureShop.Services.Media;
using FurnitureShop.WebApi.Models;
using FurnitureShop.WebAPI.Models.Product;
using FurnitureShop.WebAPI.Models.User;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Hosting;
using SlugGenerator;
using System.Net;

namespace FurnitureShop.WebAPI.Endpoints
{
    public static class ProductEndpoint
    {
        public static WebApplication MapProductEndpoints(this WebApplication app)
        {
            var routeGroupBuilder = app.MapGroup("/api/product");
            routeGroupBuilder.MapGet("/all", GetAllProduct)
            .WithName("GetAllProduct")
            .Produces<ApiResponse<ProductDto>>();
            routeGroupBuilder.MapGet("/", GetProducts)
            .WithName("GetProduct")
            .Produces<ApiResponse<PaginationResult<ProductDetail>>>();

            routeGroupBuilder.MapGet("/{id:int}", GetDetailProductById)
           .WithName("GetDetailProductById")
           .Produces<ApiResponse<ProductDto>>();


            routeGroupBuilder.MapGet("/byslug/{slug:regex(^[a-z0-9_-]+$)}", GetDetailProductBySlug)
                .WithName("GetDetailProductBySlug")
                .Produces<ApiResponse<ProductDto>>();


            routeGroupBuilder.MapPost("/", AddProduct)
                .WithName("AddProduct")
                .Accepts<ProductEditModel>("multipart/form-data")
                .Produces(401)
                .Produces<ApiResponse<ProductDetail>>();
            routeGroupBuilder.MapPut("/", AddProduct)
               .WithName("UpdateProduct")
               .Accepts<ProductEditModel>("multipart/form-data")
               .Produces(401)
               .Produces<ApiResponse<ProductDetail>>();


            routeGroupBuilder.MapDelete("/{id:int}", DeleteProduct)
                .WithName("DeleteAProduct")
                .Produces(401)
                .Produces<ApiResponse<string>>();
            return app;
        }
        private static async Task<IResult> GetAllProduct(
           IProductRepository productRepository)
        {
            var product = await productRepository.GetProductAsync(product => product.ProjectToType<ProductDto>());
            return Results.Ok(ApiResponse.Success(product));
        }
        public static async Task<IResult> GetProducts(
         [AsParameters] ProductFilterModel model,
         IProductRepository productRepository,
         IMapper mapper)
        {
            var productQuery = mapper.Map<ProductQuery>(model);

            var projectList = await productRepository.GetPagedProductAsync<ProductDetail>(productQuery, model,
            projects => projects.ProjectToType<ProductDetail>());

            var pagingnationResult = new PaginationResult<ProductDetail>(projectList);

            return Results.Ok(ApiResponse.Success(pagingnationResult));
        }

        private static async Task<IResult> GetDetailProductById(
      int id, IProductRepository productRepository, IMapper mapper)
        {
            var project = await productRepository.GetCachedProductByIdAsync(id, true);

            var projectQuery = mapper.Map<ProductDto>(project);

            return projectQuery == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy id"))
                : Results.Ok(ApiResponse.Success(mapper.Map<ProductDto>(project)));
        }
        private static async Task<IResult> GetDetailProductBySlug(
      string slug, IProductRepository productRepository, IMapper mapper)
        {
            var project = await productRepository.GetProductBySlugAsync(slug);

            var projectQuery = mapper.Map<ProductDto>(project);

            return projectQuery == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy slug"))
                : Results.Ok(ApiResponse.Success(mapper.Map<ProductDto>(project)));
        }

        private static async Task<IResult> DeleteProduct(
      int id, IProductRepository productRepository)
        {
            return await productRepository.DeleteProductByIdAsync(id)
                ? Results.Ok(ApiResponse.Success("Product đã được xoá ", HttpStatusCode.NoContent))
                : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, "Khong tim thay product"));
        }
        private static async Task<IResult> AddProduct(
         HttpContext context,
         IProductRepository productRepository,
         IMapper mapper, IMediaManager media)
        {
            var model = await ProductEditModel.BindAsync(context);
            var slug = model.Name.GenerateSlug();
            if (await productRepository.CheckSlugExistedAsync(model.Id, slug))
            {
                return Results.Ok(ApiResponse.Fail(
                    HttpStatusCode.Conflict, $"Slug {slug} đã được sử dụng cho product khác"));
            }
            var product = model.Id > 0 ? await productRepository.GetProductByIdAsync(model.Id) : null;
            if (product == null)
            {
                product = new Product()
                {
                 
                };

            }

            product.Name = model.Name;
            product.UserId = model.UserId;
            product.Collection = model.Collection;
            product.Material = model.Material;
            product.Price = model.Price;
            product.Description = model.Description;
            product.UrlImage = model.UrlImage;
            product.Size = model.Size;
            
            product.UrlSlug = model.Name.GenerateSlug();

            if (model.ImageFile?.Length > 0)
            {
                string hostname = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.PathBase}/",
                    uploadedPath = await media.SaveFileAsync(
                        model.ImageFile.OpenReadStream(), model.ImageFile.FileName, model.ImageFile.ContentType);
                if (!string.IsNullOrWhiteSpace(uploadedPath))
                {
                    product.UrlImage = uploadedPath;
                }
            }
            await productRepository.CreateOrUpdateProductAsync(product, model.GetSelectedCategories());
            return Results.Ok(ApiResponse.Success(mapper.Map<ProductDetail>(product), HttpStatusCode.Created));

        }
    }
}
