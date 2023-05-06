using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

namespace FurnitureShop.WebAPI.Models.Product
{
    public class ProductFilterModel :PagingModel
    {
        //public int UserId { get; set; }
        public string Keyword { get; set; }
        public IEnumerable<SelectListItem> UserList { get; set; }
    }
}
