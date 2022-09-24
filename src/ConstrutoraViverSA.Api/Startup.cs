using System;
using ConstrutoraViverSA.Application.Interfaces;
using ConstrutoraViverSA.Application.Services;
using ConstrutoraViverSA.Infraestrutura;
using ConstrutoraViverSA.Repository.Interfaces;
using ConstrutoraViverSA.Repository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ConstrutoraViverSA.Api
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
            
            services.AddScoped<ApplicationContext>();

            //Services
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<IObraService, ObraService>();
            services.AddScoped<IOrcamentoService, OrcamentoService>();
            
            //Repositories
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IObraRepository, ObraRepository>();
            services.AddScoped<IOrcamentoRepository, OrcamentoRepository>();

            // Register the Swagger Generator service. This service is responsible for genrating Swagger Documents.
            // Note: Add this service at the end after AddMvc() or AddMvcCore().
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Construtora Viver SA API",
                    Version = "v1",
                    Description = "Description for the API goes here.",
                    Contact = new OpenApiContact
                    {
                        Name = "Matheus Vieira Santos",
                        Email = "matheus.eu.mv@gmail.com",
                        Url = new Uri("https://cc.uffs.edu.br/pessoa/matheus.vieirasantos/"),
                    },
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Construtora Viver SA API V1");

                // To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
                c.RoutePrefix = "swagger";
            });
        }
    }
}