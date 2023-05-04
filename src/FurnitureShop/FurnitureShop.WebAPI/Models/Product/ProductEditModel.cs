using FurnitureShop.WebAPI.Models.Category;
using FurnitureShop.WebAPI.Models.User;
using System.Globalization;

namespace FurnitureShop.WebAPI.Models.Product
{
    public class ProductEditModel
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
        public int UserId { get; set; }

        public IFormFile ImageFile { get; set; }

        public string SelectedCategories { get; set; }
        public List<string> GetSelectedCategories()
        {
            return (SelectedCategories ?? "").Split(new[] { ',', ';', '\r', '\n' },
                        StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public static async ValueTask<ProductEditModel> BindAsync(HttpContext context)
        {
            var form = await context.Request.ReadFormAsync();
            return new ProductEditModel()
            {
                ImageFile = form.Files["ImageFile"],
                Id = int.Parse(form["Id"]),
                Name = form["Name"],
                Collection = form["Collection"],
                Description = form["Description"],
                Material = form["Material"],
                Price = form["Price"] ,
                UserId = int.Parse(form["UserId"]),
                Size = form["Size"],
                SelectedCategories = form["SelectedCategories"]
            };
        }
    }
}
