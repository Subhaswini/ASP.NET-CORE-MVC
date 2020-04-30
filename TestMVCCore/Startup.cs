using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.Extensions.Configuration;
using TestMVCCore.Models;
using Microsoft.Extensions.Options;

namespace TestMVCCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //string websiteTitle = _configuration.GetValue<string>("WebsiteTitle");
            services.Configure<WebOptions>(_configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<WebOptions> optionsAccessor)
        {
            string websiteTitle = optionsAccessor.Value.Title;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            /*app.UseStatusCodePages("text/html", "We're <b>really</b> sorry, but something went wrong. Error code: {0}");
            app.UseStatusCodePages(async context =>
            {
                context.HttpContext.Response.ContentType = "text/html";

                if (context.HttpContext.Response.StatusCode == 404)
                {
                    // Log this error here, e.g. to a database. You can use the context.HttpContext.Request 
                    // object to access important information like the requested URL
                }

                await context.HttpContext.Response.WriteAsync(
                    "People, We're <b>really</b> sorry, but something went wrong. Error code: " +
                    context.HttpContext.Response.StatusCode);
            });*/
            app.UseStatusCodePagesWithRedirects("/Error/Http?statusCode={0}");
            //app.UseMvc();
            app.UseStaticFiles();
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider
                (
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images")
                ),
                RequestPath = "/Images"
            });
            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Query", "Query/{*QueryTest}",
                     defaults: new { controller = "Query", action = "QueryTest" });
                endpoints.MapControllerRoute("Validation", "Validation/{*EditUser}",
                      defaults: new { controller = "Validation", action = "EditUser" });
                endpoints.MapControllerRoute("Validation", "Validation/{*SimpleValidation}",
                        defaults: new { controller = "Validation", action = "SimpleValidation" });
                endpoints.MapControllerRoute("Validation", "Validation/{*Create}",
                       defaults: new { controller = "Validation", action = "Create" });
               
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
