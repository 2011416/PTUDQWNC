using FluentValidation.Validators;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FurnitureShop.WebAPI.Models.User
{
    public class UserFilterModel:PagingModel
    {
        public string Keyword { get; set; }
        public string Name { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }
    }
}
