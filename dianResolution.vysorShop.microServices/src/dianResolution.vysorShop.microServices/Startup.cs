using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dianResolution.vysorShop.microServices.Data;
using dianResolution.vysorShop.microServices.Models;
using dianResolution.vysorShop.microServices.Models.Interfaces;
using dianResolution.vysorShop.microServices.Services;
using dianResolution.vysorShop.microServices.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace dianResolution.vysorShop.microServices
{
    public class Startup
    {
        public const string AppS3BucketKey = "AppS3Bucket";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Add S3 to the ASP.NET Core dependency injection framework.
            services.AddAWSService<Amazon.S3.IAmazonS3>();

            //inject
            services.AddScoped<IResolutionServices, ResolutionServices>();
            services.AddScoped<IResolutionRepository, ResolutionRepository>();
            //EF
            services.AddDbContext<Context>(options =>
            options.UseMySQL(Configuration.GetConnectionString("dbQA")));
            services.AddScoped<Context, Context>();

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
