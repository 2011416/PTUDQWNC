using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Core.DTO.Query
{
    public class CategoryQuery
    {
        public string Keyword { get; set; } 
        public string ProductSlug { get; set; }
        public string UrlSlug { get; set; }
    }
}
