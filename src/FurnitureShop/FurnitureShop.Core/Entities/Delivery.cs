﻿using FurnitureShop.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Core.Entities
{
    public class Delivery: IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; } 
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }  
    }
}
