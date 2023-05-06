namespace FurnitureShop.WebAPI.Models.Category
{
    public class CategoryFilterModel:PagingModel
    {
        public string Keyword { get; set; }
        public string UrlSlug { get; set; }
    }
}
