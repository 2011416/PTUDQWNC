using FurnitureShop.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Core.Entities
{
    public class User:IEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }
        public string phoneNumber { get; set; }
        public string UrlSlug { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public IList<Product> Products { get; set; }
        public IList<Delivery> Deliveries { get; set; }
    }
}
