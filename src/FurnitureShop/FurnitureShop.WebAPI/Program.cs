using FurnitureShop.WebAPI.Endpoints;
using FurnitureShop.WebAPI.Mapsters;
using ManageProject.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

{
    builder
    .ConfigureMaster()
      .ConfigureCors()
      .ConfigureServices()
      .ConfigureSwaggerOpenApi();
      
}


var app = builder.Build();

{
    app.SetupRequestPipeline();
    app.UsingDataSeeder();
    app.MapCategoryEndpoints();

    app.Run();
}