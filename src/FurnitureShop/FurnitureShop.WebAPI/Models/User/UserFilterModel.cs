namespace FurnitureShop.WebAPI.Models.User
{
    public class UserFilterModel:PagingModel
    {
        public string Keyword { get; set; }
        public string Name { get; set; }
    }
}
