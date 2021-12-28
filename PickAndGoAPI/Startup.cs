using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PickAndGoAPI.Aisles.AppService;
using PickAndGoAPI.Brands.AppService;
using PickAndGoAPI.Categories.AppService;
using PickAndGoAPI.Customers.AppService;
using PickAndGoAPI.Data;
using PickAndGoAPI.Distributions.AppService;
using PickAndGoAPI.InventoryControl.AppService;
using PickAndGoAPI.Products.AppService;
using PickAndGoAPI.Providers.AppService;
using PickAndGoAPI.PurchasesDetails.AppService;
using PickAndGoAPI.PurchasesOrders.AppService;
using PickAndGoAPI.QualityRegistries.AppService;
using PickAndGoAPI.SalesDetails.AppService;
using PickAndGoAPI.SalesOrders.AppService;
using PickAndGoAPI.SequencesAisles.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI
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
            services.AddDbContext<DataContext>();
            
            services.AddScoped<AisleMasterAppService>();
            services.AddScoped<BrandMasterAppService>();
            services.AddScoped<CategoryMasterAppService>();
            services.AddScoped<CategoryMasterAppService>();
            services.AddScoped<CustomerMasterAppService>();
            services.AddScoped<DistributionMasterAppService>();
            services.AddScoped<InventoryAppService>();
            services.AddScoped<ProductsMasterAppService>();
            services.AddScoped<ProviderMasterAppService>();
            services.AddScoped<PurchasesDetailsMasterAppService>();
            services.AddScoped<PurchasesOrdersMasterAppService>();
            services.AddScoped<PurchaseOrdersAppService>();
            services.AddScoped<QualityRegistryMasterAppService>();
            services.AddScoped<SalesDetailsMasterAppService>();
            services.AddScoped<SalesOrdersMasterAppService>();
            services.AddScoped<SequencesAislesMasterAppService>();

            
            
            
             
            services.AddMvc().AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PickAndGoAPI", Version = "v1" });
            });

            services.AddCors(options => options.AddPolicy("AllowWebApp",
                builder => builder.AllowAnyOrigin()
                             .AllowAnyHeader()
                             .AllowAnyMethod()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PickAndGoAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowWebApp");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
