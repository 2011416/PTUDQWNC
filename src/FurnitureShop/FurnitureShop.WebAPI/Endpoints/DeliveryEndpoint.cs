using FurnitureShop.Core.Collections;
using FurnitureShop.Core.DTO.Item;
using FurnitureShop.Core.DTO.Query;
using FurnitureShop.Core.Entities;
using FurnitureShop.Services.Blogs.Categories;
using FurnitureShop.Services.Blogs.Deliveries;
using FurnitureShop.WebApi.Models;
using FurnitureShop.WebAPI.Models.Category;
using FurnitureShop.WebAPI.Models.Delivery;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using SlugGenerator;
using System.Net;

namespace FurnitureShop.WebAPI.Endpoints
{
    public static class DeliveryEndpoint
    {
        public static WebApplication MapDeliveryEndpoints(this WebApplication app)
        {
            var routeGroupBuilder = app.MapGroup("/api/deliveries");
            routeGroupBuilder.MapGet("/all", GetAllDeliveries)
            .WithName("GetAllDeliveries")
            .Produces<ApiResponse<DeliveryDto>>();
            routeGroupBuilder.MapGet("/", GetDeliveries)
    .WithName("GetDeliveries")
    .Produces<ApiResponse<PaginationResult<DeliveryDto>>>();
            routeGroupBuilder.MapGet("/id/{id:int}", GetDetailDeliveryById)
            .WithName("GetDetailDeliveryById")
            .Produces<ApiResponse<DeliveryDto>>();
            routeGroupBuilder.MapGet("/slug/{slug:regex(^[a-z0-9_-]+$)}", GetDetailDeliveryBySlug)
            .WithName("GetDetailDeliveryBySlug")
            .Produces<ApiResponse<DeliveryDto>>();
            routeGroupBuilder.MapDelete("/{id:int}", DeleteDelivery)
          .WithName("DeleteDelivery")
          .Produces(401)
          .Produces<ApiResponse<string>>();

            routeGroupBuilder.MapPost("/", AddOrUpdateDelivery)
                .WithName("AddNewDelivery")
                .Accepts<DeliverEditModel>("multipart/form-data")
                .Produces(401)
                .Produces<ApiResponse<DeliveryItem>>();
            routeGroupBuilder.MapPut("/", AddOrUpdateDelivery)
               .WithName("UpdateDelivery")
               .Accepts<DeliverEditModel>("multipart/form-data")
               .Produces(401)
               .Produces<ApiResponse<DeliveryItem>>();
            return app;
        }

        private static async Task<IResult> GetAllDeliveries(IDeliveryRepository deliveryRepository)
        {
            var delivery = await deliveryRepository
                .GetDeliveryAsync(delivery => delivery.ProjectToType<DeliveryDto>());
            return Results.Ok(ApiResponse.Success(delivery));
        }
        private static async Task<IResult> GetDeliveries(
           [AsParameters] DeliveryFilterModel model,
           IDeliveryRepository deliveryRepository,
           IMapper mapper
           )
        {
            var deliveryQuery = mapper.Map<DeliveryQuery>(model);
            var deliveryList = await deliveryRepository.GetPagedDeliveryAsync<DeliveryDto>(
                deliveryQuery, model, delivery => delivery.ProjectToType<DeliveryDto>());
            var pagingnationResult = new PaginationResult<DeliveryDto>(deliveryList);
            return Results.Ok(ApiResponse.Success(pagingnationResult));

        }
        private static async Task<IResult> GetDetailDeliveryById(
       int id, IDeliveryRepository deliveryRepository, IMapper mapper)
        {
            var Delivery = await deliveryRepository.GetCachedDeliveryByIdAsync(id, true);

            var DeliveryQuery = mapper.Map<DeliveryDto>(Delivery);

            return DeliveryQuery == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy id"))
                : Results.Ok(ApiResponse.Success(mapper.Map<DeliveryDto>(Delivery)));
        }
        private static async Task<IResult> GetDetailDeliveryBySlug(
        [FromRoute] string slug,
        IDeliveryRepository deliveryRepository,
        IMapper mapper)
        {
            var DeliveryList = await deliveryRepository.GetDeliveryBySlugAsync(slug);
            var DeliveryQuery = mapper.Map<DeliveryDto>(DeliveryList);

            return DeliveryQuery == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, "Không tìm thấy slug"))
                : Results.Ok(ApiResponse.Success(mapper.Map<DeliveryDto>(DeliveryList)));
        }

        private static async Task<IResult> DeleteDelivery(
       int id, IDeliveryRepository deliveryRepository)
        {
            return await deliveryRepository.DeleteDeliveryByIdAsync(id)
                ? Results.Ok(ApiResponse.Success("Delivery đã được xoá ", HttpStatusCode.NoContent))
                : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, "Khong tim thay Delivery"));
        }

        private static async Task<IResult> AddOrUpdateDelivery(
            HttpContext context,
            IDeliveryRepository deliveryRepository,
            IMapper mapper
            )
        {
            var model = await DeliverEditModel.BindAsync(context);
            var slug = model.Name.GenerateSlug();
            if (await deliveryRepository.CheckSlugExistedAsync(model.Id, slug))
            {
                return Results.Ok(ApiResponse.Fail(
                   HttpStatusCode.Conflict, $"Slug {slug} đã được sử dụng cho bài viết Delivery khác"));
            }
            var delivery = model.Id > 0 ? await deliveryRepository.GetCachedDeliveryByIdAsync(model.Id) : null;
            if (delivery == null)
            {
                delivery = new Delivery();
            }

            delivery.Name = model.Name;
            delivery.User.Id = model.UserId;
            delivery.UrlSlug = model.Name.GenerateSlug();

            await deliveryRepository.CreateOrUpdateDeliveryAsync(delivery);
            return Results.Ok(ApiResponse.Success(mapper.Map<DeliveryItem>(delivery), HttpStatusCode.Created));
        }
    }
}
