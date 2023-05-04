using FurnitureShop.WebAPI.Models.Category;

namespace FurnitureShop.WebAPI.Models.Product
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlSlug { get; set; }
        public string Price { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public string Collection { get; set; }
        public string UrlImage { get; set; }
        public IList<CategoryDto> Categories { get; set; }

    }
}
