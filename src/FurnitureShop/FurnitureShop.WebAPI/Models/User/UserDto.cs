﻿namespace FurnitureShop.WebAPI.Models.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }
        public string phoneNumber { get; set; }
        public string UrlSlug { get; set; }
        public int RoleId { get; set; }
    }
}
