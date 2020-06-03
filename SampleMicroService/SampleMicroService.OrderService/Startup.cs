using SampleMicroService.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace SampleMicroService.OrderService
{
    public class Startup
    {
        /// <summary>
        /// Configuration'ý inject alýyoruz.
        /// </summary>
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //Configuration içindeki deðerleri alýyoruz.
            var serviceConfig = Configuration.GetServiceConfig();
            //Servisin consul'e kayýt olmasý için ayarlamalarý uyguluyoruz.
            services.RegisterConsulServices(serviceConfig);

            services.AddControllers();
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/version", async context =>
                {
                    await context.Response.WriteAsync($"v{Assembly.GetExecutingAssembly().GetName().Version}");
                });
            });
        }
    }
}
