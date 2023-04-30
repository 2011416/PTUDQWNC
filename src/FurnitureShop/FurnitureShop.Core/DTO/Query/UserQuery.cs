using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Core.DTO.Query
{
    public class UserQuery
    {
        public string Keyword { get; set; }
        public string Name { get; set; }
        public string RoleSlug { get; set; }
        public string DeliverSlug { get; set; }
    }
}
