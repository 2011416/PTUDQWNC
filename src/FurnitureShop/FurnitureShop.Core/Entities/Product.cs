using FurnitureShop.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Core.Entities
{
    public class Product: IEntity
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
        public IList<Category> Categories { get; set; }
        public User User { get;set; }
     
    }
}
