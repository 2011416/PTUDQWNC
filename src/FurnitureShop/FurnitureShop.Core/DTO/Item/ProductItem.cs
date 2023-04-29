using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Core.DTO.Item
{
    public class ProductItem
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
    }
}
