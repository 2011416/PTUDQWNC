namespace FurnitureShop.WebAPI.Models.Category
{
    public class CategoryFilterModel:PagingModel
    {
        public string Name { get; set; }
        public string UrlSlug { get; set; }
    }
}
