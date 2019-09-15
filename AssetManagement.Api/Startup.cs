using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AssetManagement.Data;
using AssetManagement.Data.Infrastructure;
using AssetManagement.Data.Repositories;
using AssetManagement.Data.Repositories.Interface;
using AssetManagement.Service.AutoMapper;
using AssetManagement.Service.Category;
using AssetManagement.Service.Product;
using AssetManagement.Service.Shared.CategoryService;
using AssetManagement.Service.Shared.ProductService;
using Log4Net_Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace AssetManagement.Api
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

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("AssetManagementV1", new OpenApiInfo { Title = "Asset Management", Version = "v1" });
            });
            var config = new AutoMapper.MapperConfiguration(cfg=> {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

         
            services.AddTransient<ICategoryService,CategoryService>();
            services.AddTransient<IProductService, ProductService>();
    
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseSwagger();

            app.UseSwaggerUI(c=>{
                
                c.SwaggerEndpoint("/swagger/AssetManagementV1/swagger.json", "Asset Management V1");
                c.RoutePrefix = string.Empty;
            });


            //var all =
            //      Assembly
            //         .GetEntryAssembly()
            //         .GetReferencedAssemblies()
            //         .Select(Assembly.Load)
            //         .SelectMany(x => x.DefinedTypes)
            //         .Where(type => typeof(ControllerBase).GetTypeInfo().IsAssignableFrom(type.AsType())).Select(x=>x.Assembly).ToList();

            //foreach (var item in all)
            //{
            //    LogFourNet.SetUp(item, "log4net.config");
            //}
            

            app.UseMvc();
        }
    }
}
