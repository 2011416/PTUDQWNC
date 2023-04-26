using Mapster;
using MapsterMapper;

namespace FurnitureShop.WebAPI.Mapsters
{
    public static class MapsterDependencyInjection
    {
        public static WebApplicationBuilder ConfigureMaster(this WebApplicationBuilder builder)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(typeof(MapsterConfiguration).Assembly);
            builder.Services.AddSingleton(config);
            builder.Services.AddScoped<IMapper, ServiceMapper>();
            return builder;
        }
    }
}
