using FurnitureShop.WebAPI.Models.Category;

namespace FurnitureShop.WebAPI.Models.Delivery
{
    public class DeliverEditModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public DateTime Date { get; set; }
        public static async ValueTask<DeliverEditModel> BindAsync(HttpContext context)
        {
            var form = await context.Request.ReadFormAsync();
            return new DeliverEditModel()
            {

                Id = int.Parse(form["Id"]),
                Name = form["Name"],
                UserId = int.Parse(form["UserId"]),
                Date = DateTime.Parse(form["Date"])

            };
        }
    }
    
}
