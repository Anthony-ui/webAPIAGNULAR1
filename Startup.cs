﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace webAPIAGNULAR1
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
            services.AddEntityFrameworkMySql();
            services.AddDbContext<BaseDatos>(options =>
                options.UseMySql(
                    Configuration.GetConnectionString("cn")));

            services.AddCors(co => co.AddPolicy("crs", po =>
            {            
                po.AllowAnyOrigin();
                po.AllowAnyHeader();
                po.AllowCredentials();
                po.AllowAnyMethod();

            }));
            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

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
                app.UseHsts();
            }
            app.UseCors("crs");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
    //hola que tal como estas mi nombre es ricardo
}
