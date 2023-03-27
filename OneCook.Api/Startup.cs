using System;
using System.IO;
using System.Reflection;
using Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector.QuickPulse;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OneCook.BL.CustomServices;
using OneCook.BL.CustomServices.Interfaces;
using OneCook.BL.Services;
using OneCook.BL.Services.Interfaces;
using OneCook.DL.Models.Context;
using OneCook.DL.UnitOfWork;

namespace OneCook.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBString")));
#if DEBUG
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBString")));
#else
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBStringHome")));

#endif
            //services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase("OneCook"));


            //DI
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserServiceBL, UserServiceBL>();
            services.AddScoped<ICategoryServiceBL, CategoryServiceBL>();
            services.AddScoped<ILikeServiceBL, LikeServiceBL>();
            services.AddScoped<ICommentServiceBL, CommentServiceBL>();
            services.AddScoped<IRecipeServiceBL, RecipeServiceBL>();
            services.AddScoped<IFavoriteServiceBL, FavoriteServiceBL>();
            services.AddScoped<IFollowerServiceBL, FollowerServiceBL>();
            services.AddScoped<IImageServiceBL, ImageServiceBL>();
            services.AddScoped<IIngredientServiceBL, IngredientServiceBL>();
            services.AddScoped<IStepServiceBL, StepServiceBL>();

            //Blob Storage
            services.AddScoped<IStorageService, StorageService>();

            services.AddSwaggerGen();

#if DEBUG
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            services.AddSwaggerGen(options =>
            {
                options.IncludeXmlComments(xmlPath);
            });
#endif
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddApplicationInsightsTelemetry();
            services.ConfigureTelemetryModule<QuickPulseTelemetryModule>((module, o) => module.AuthenticationApiKey = "4e5215db-2bc2-4e17-ba4c-14b4fed7a7d9");

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Cors
            app.UseCors("MyPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Swagger
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
