using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Core.DTO.Query
{
    public class ProductQuery
    {
        public string Keyword { get; set; }
        public int UserId { get; set; }
    }
}
