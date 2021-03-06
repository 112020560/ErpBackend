using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Articulos;
using Business.Catalogs;
using Business.Documents;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

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
            services.AddTransient<ICatalogs>(x => new CatalogsServices(Configuration.GetConnectionString("Default")));
            services.AddTransient<IPersonas>(x => new Personas(Configuration.GetConnectionString("Default")));
            services.AddTransient<IArtuclos>(x => new ArticulosVenta(Configuration.GetConnectionString("Default")));
            services.AddTransient<IBusquedaAvanzada>(x => new BusquedaAvanzada(Configuration.GetConnectionString("Default")));
            services.AddTransient<IDocument>(x => new Document(Configuration.GetConnectionString("Default")));

            #region  Versioning
            services.AddApiVersioning(o => {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });
            #endregion

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

            #region  Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "BackEnd API Rest",
                        Version = "v1",
                        Description = "Rest Services for BackEnd",
                        Contact = new OpenApiContact()
                        {
                            Name = "Felipe Alpizar",
                            Email = "felipe.alpizar@hotmail.com"
                        }
                    });

                //Locate the XML file being generated by ASP.NET...
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                //... and tell Swagger to use those XML comments.
                // c.IncludeXmlComments(xmlPath);
            });
            #endregion

            services.AddControllers();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Marcar miembros como static", Justification = "<pendiente>")]
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "V 1.0");
            });

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
