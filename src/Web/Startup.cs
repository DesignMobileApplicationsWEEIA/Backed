using System.IO;
using Backend.Web.Database.Implementation;
using Domain.Cache.Implementations;
using Domain.Cache.Interfaces;
using Domain.Database.Interfaces;
using Domain.Repositories.Implementations;
using Domain.Repositories.Interfaces;
using Domain.Services.Implementations;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Web.Migrations;

namespace Backend.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddMemoryCache();

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<PostgresDbContext>(options => options.UseNpgsql(Configuration["Data:DbContext:ConnectionString"]));

            services.AddScoped<IDbContext, PostgresDbContext>();
            services.AddTransient<ICacheService, InMemoryCacheService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAchievementService, AchievementService>();
            services.AddTransient<IPlaceService, PlaceService>();
            services.AddTransient<IBuildingService, BuildingService>();
            services.AddTransient<ILogoService, LogoService>();
            services.AddTransient<IFacultyService, FacultyService>();
            services.AddTransient<IUserAchievementService, UserAchievementService>();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc().UseSwagger().UseSwaggerUi();
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<PostgresDbContext>().Database.Migrate();

                using (var dbContext = app.ApplicationServices.GetRequiredService<PostgresDbContext>())
                {
                    Seed.Init(dbContext, $"{env.WebRootPath}{Path.DirectorySeparatorChar}Logos{Path.DirectorySeparatorChar}" );
                }
            }
        }
    }
}
