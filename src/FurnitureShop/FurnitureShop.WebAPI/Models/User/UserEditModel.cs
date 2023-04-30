using FurnitureShop.WebAPI.Models.Category;

namespace FurnitureShop.WebAPI.Models.User
{
    public class UserEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }
        public string phoneNumber { get; set; }
        public string UrlSlug { get; set; }
        public int RoleId { get; set; }
        public static async ValueTask<UserEditModel> BindAsync(HttpContext context)
        {
            var form = await context.Request.ReadFormAsync();
            return new UserEditModel()
            {

                Id = int.Parse(form["Id"]),
                Name = form["Name"],
                Email= form["Email"],
                Password = form["Password"],
                Adress = form["Adress"],
                phoneNumber = form["phoneNumber"],
                UrlSlug= form["UrlSlug"],
                RoleId= int.Parse(form["RoleId"])

            };
        }
    }
}
