using FurnitureShop.Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FurnitureShop.Services.Media;
using FurnitureShop.Services.Timing;
using FurnitureShop.Data.Seeders;

using Microsoft.Extensions.Options;
using FurnitureShop.Services.Blogs.Categories;
using FurnitureShop.Services.Blogs.Roles;

namespace ManageProject.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddMemoryCache();
            builder.Services.AddDbContext<BlogDbContext>(options =>
             options.UseSqlServer(
               builder.Configuration
                 .GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IDataSeeder, DataSeeder>();
    
            builder.Services.AddScoped<ITimeProvider, LocalTimeProvider>();
            builder.Services.AddScoped<IMediaManager, LocalFileSystemMediaManager>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();



            return builder;
        }
        public static WebApplicationBuilder ConfigureCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("ManageProjectApp", policyBuilder =>
            policyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            return builder;
        }
        // cau hinh viec su dung NLog
  //      public static WebApplicationBuilder ConfigureNLog(this WebApplicationBuilder builder)
  //      {
  //          builder.Logging.ClearProviders();
		//	builder.Host.UseNLog();
  //          return builder;

		//}

		public static WebApplicationBuilder ConfigureSwaggerOpenApi(
            this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            return builder;
        }
        public static WebApplication SetupRequestPipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseCors("ManageProjectApp");
            return app;
        }
        public static IApplicationBuilder UsingDataSeeder(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            try
            {
                scope.ServiceProvider
                    .GetRequiredService<IDataSeeder>()
                    .Initialize();

            }
            catch (Exception ex)
            {
                scope.ServiceProvider
                    .GetRequiredService<ILogger<Program>>()
                    .LogError(ex, "Couldn't insert data into database");
            }
            return app;
        }

    }
   
}
    
