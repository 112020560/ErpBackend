using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Articulos;
using Business.Catalogs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApi
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
            services.AddTransient<ICatalogs>(x => new Catalogs(Configuration.GetConnectionString("Default")));
            services.AddTransient<IPersonas>(x => new Personas(Configuration.GetConnectionString("Default")));
            services.AddTransient<IArtuclos>(x => new Articulos(Configuration.GetConnectionString("Default")));

            #region Cors
            // ********************
            // Setup CORS
            // ********************
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                        //.AllowCredentials();
                });

                options.AddPolicy("AllowSpecific", builder =>
                {
                    builder.WithOrigins(Configuration["AllowedHosts"])
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                    // AllowCredentials();
                });
            });

            #endregion

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("AllowAllOrigins");
            }
            else 
            {
                app.UseCors("AllowAllOrigins");
                app.UseCors("AllowSpecific");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
