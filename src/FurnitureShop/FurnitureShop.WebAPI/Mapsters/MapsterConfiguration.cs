using FurnitureShop.Core.DTO.Item;
using FurnitureShop.Core.DTO.Query;
using FurnitureShop.Core.Entities;
using Mapster;

namespace FurnitureShop.WebAPI.Mapsters
{
    public class MapsterConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Category, CategoryItem>();
            config.NewConfig<Category, CategoryQuery>();

        }
    }
}
