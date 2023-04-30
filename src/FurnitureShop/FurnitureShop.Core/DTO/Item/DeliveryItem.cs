using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Core.DTO.Item
{
    public class DeliveryItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public DateTime Date { get; set; }
    }
}
