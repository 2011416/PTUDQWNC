﻿namespace FurnitureShop.WebAPI.Models.Category
{
    public class CategoryEditModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string UrlSlug { get; set; }
    }
}
