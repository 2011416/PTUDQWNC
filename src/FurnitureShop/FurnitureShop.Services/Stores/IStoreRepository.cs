//using FurnitureShop.Core.Contracts;
//using FurnitureShop.Core.DTO;
//using FurnitureShop.Core.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FurnitureShop.Services.Blogs
//{
//    public interface IStoreRepository
//    {
//        Task<Product> GetProductAsync(int year, int month, string slug, CancellationToken cancellationToken = default);

//        Task<IList<Product>> GetPopularProductsAsync(int num, CancellationToken cancellationToken = default);

//        Task<bool> IsPostSlugExistedAsync(int productId, string slug, CancellationToken token = default);

//        Task IncreaseViewCountAsync(int productId, CancellationToken cancellationToken = default);

//        Task<IList<CategoryItem>> GetCategoriesAsync(
//        bool showOnMenu = false,
//        CancellationToken cancellationToken = default);

//        Task<IPagedList<TagItem>> GetPagedTagsAsync(
//            IPagingParams pagingParams,
//            CancellationToken cancellationToken = default);
//    }
//}
