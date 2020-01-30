﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using client.vysorShop.microServices.Data.Repositories;
using client.vysorShop.microServices.Models;
using client.vysorShop.microServices.Models.Interfaces;
using client.vysorShop.microServices.Services;
using client.vysorShop.microServices.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace client.vysorShop.microServices
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
            services.AddScoped<IClientServices, ClientServices>();
            services.AddScoped<IClientRepository, ClientRepository>();
            //EF
            services.AddScoped<dondiegoDBContext, dondiegoDBContext>();

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

            app.Use((context, next) =>
            {
                context.Response.Headers["Access-Control-Allow-Origin"] = "*";
                return next.Invoke();
            });
            app.UseCors(options => options.AllowAnyOrigin());
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
