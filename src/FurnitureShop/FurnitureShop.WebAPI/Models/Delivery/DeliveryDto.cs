namespace FurnitureShop.WebAPI.Models.Delivery
{
    public class DeliveryDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public DateTime Date { get; set; }
    }
}
