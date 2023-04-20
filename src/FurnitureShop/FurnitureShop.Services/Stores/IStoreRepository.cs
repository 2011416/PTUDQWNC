using FurnitureShop.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Services.Blogs
{
    public interface IStoreRepository
    {
        //Task<Post> GetPostAsync(int year, int month, string slug, CancellationToken cancellationToken = default);

        //Task<IList<Post>> GetPopularArticlesAsync(int numPosts, CancellationToken cancellationToken = default);

        //Task<bool> IsPostSlugExistedAsync(int postId, string slug, CancellationToken token = default);

        //Task IncreaseViewCountAsync(int postId, CancellationToken cancellationToken = default);

        Task<IList<CategoryItem>> GetCategoriesAsync(
        bool showOnMenu = false,
        CancellationToken cancellationToken = default);

        //Task<IPagedList<TagItem>> GetPagedTagsAsync(
        //    IPagingParams pagingParams,
        //    CancellationToken cancellationToken = default);
    }
}
