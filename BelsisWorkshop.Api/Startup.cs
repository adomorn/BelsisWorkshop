using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BelsisWorkshop.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container. asd asd asd
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<ITicket, Ticket>();
            //services.AddScoped<ITicket, Ticket>();
            services.AddSingleton<ITicket, Ticket>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Belsis Workshop API", Version = "v1" });
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ITicket ticket)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ticket.Adi = "Belsis 2";
            app.UseRouting();
            app.UseRequestCulture();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Belsis API v1");
                c.RoutePrefix = "api";
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("3. hello world<br/>");
            //});
            //app.Use(async (context, next) => {
            //    await context.Response.WriteAsync("1. hello World<br/>");
            //    await next.Invoke();

            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}