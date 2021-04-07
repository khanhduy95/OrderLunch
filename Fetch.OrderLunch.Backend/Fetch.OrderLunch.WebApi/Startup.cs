using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Fetch.OrderLunch.Core.Interfaces;
using Fetch.OrderLunch.Infrastructure.Data;
using Fetch.OrderLunch.Infrastructure.Identity;
using Fetch.OrderLunch.WebApi.Application.Interfaces;
using Fetch.OrderLunch.WebApi.Application.Models;
using Fetch.OrderLunch.WebApi.Application.Services;
using Fetch.OrderLunch.WebApi.Infrastructure.AutofacModules;
using Fetch.OrderLunch.WebApi.Infrastructure.Filters;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.ServiceFabric;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace Fetch.OrderLunch.WebApi
{
    public class Startup
    {
        //readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsights(Configuration)
                .AddCustomMvc()
                .AddCustomDbContext(Configuration)
                .AddCustomSwagger(Configuration)
                .AddCustomAuthentication(Configuration);

            ////
            ///asdasd

            var container = new ContainerBuilder();
            container.Populate(services);
            container.RegisterModule(new ApplicationModule(Configuration.GetConnectionString("Default")));
            container.RegisterModule(new MediatorModule());

            return new AutofacServiceProvider(container.Build());
        }

        [Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            };
            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseMvc();

            app.UseStaticFiles();
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My service");
                c.RoutePrefix = string.Empty;  // Set Swagger UI at apps root
            });
            app.UseAuthentication();
           
        }
    }
    static class CustomExtensionsMethods
    {
        public static IServiceCollection AddApplicationInsights(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationInsightsTelemetry(configuration);
            var orchestratorType = configuration.GetValue<string>("OrchestratorType");

            if (orchestratorType?.ToUpper() == "K8S")
            {
                // Enable K8s telemetry initializer
                services.AddApplicationInsightsKubernetesEnricher();
            }
            if (orchestratorType?.ToUpper() == "SF")
            {
                // Enable SF telemetry initializer
                services.AddSingleton<ITelemetryInitializer>((serviceProvider) =>
                    new FabricTelemetryInitializer());
            }

            return services;
        }
        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));

            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IFoodService, FoodService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<IDailyMenuService, DailyMenuService>();
            services.AddTransient<IBasketService, BasketService>();

            services.AddHttpContextAccessor();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddControllersAsServices();  //Injecting Controllers themselves thru DI
                                              //For further info see: http://docs.autofac.org/en/latest/integration/aspnetcore.html#controllers-as-services

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            

            // Configure CORS for React UI
            return services;

        }
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderLunchContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Identity")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            return services;
        }
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("Bearer",
                new ApiKeyScheme
                {
                    In = "header",
                    Description = "Please enter into field the word 'Bearer' following by space and JWT",
                    Name = "Authorization",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                    { "Bearer", Enumerable.Empty<string>() },
                });
                // c.OperationFilter<AuthorizeCheckOperationFilter>();
                c.OperationFilter<FileUploadOperation>();
            });
            return services;
        }
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication()
              .AddFacebook(facebookOptions =>
              {
                  facebookOptions.AppId = "208182446945226";

                  facebookOptions.AppSecret = "2a2e9d0bada558a2ccb4b4078dad4b7b";
              })
              .AddCookie(x => x.SlidingExpiration = true)
              .AddJwtBearer(x =>
              {
                  x.TokenValidationParameters = new TokenValidationParameters()
                  {
                      ValidIssuer = MVSJwtTokens.Issuer,
                      ValidAudience = MVSJwtTokens.Audience,
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(MVSJwtTokens.Key))
                  };
              });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminRolePolicy",
                    policy => policy.RequireRole("Admin"));
            });

            return services;
        }
    }
}
