using ManageProject.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

{
    builder
      .ConfigureCors()
      .ConfigureServices()
      .ConfigureSwaggerOpenApi();
      
}


var app = builder.Build();

{
    app.SetupRequestPipeline();
    app.UsingDataSeeder();
   

    app.Run();
}