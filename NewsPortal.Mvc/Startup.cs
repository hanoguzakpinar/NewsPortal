using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewsPortal.Services.AutoMapper.Profiles;
using NewsPortal.Services.Extensions;

namespace NewsPortal.Mvc
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });
            //mvc ve razor runtime package dahil etme.
            services.AddSession();//session yapýsýný ekleme.
            services.AddAutoMapper(typeof(CategoryProfile), typeof(ReportProfile));//automapperi dahil etme.
            services.LoadMyServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())//geliþtirme ayarlarý
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();//varolmayan viewlere gidildiðinde 404 fýrlatýr.
            }

            app.UseSession();//authen ve authodan önce tanýmlanmalýdýr.

            app.UseStaticFiles();//wwwroot dosyalarýna eriþim

            app.UseRouting();

            app.UseAuthentication();//kimlik kontrolü

            app.UseAuthorization();//yetki kontrolü

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"//id nullable
                );
                endpoints.MapDefaultControllerRoute();//varsayýlan olarak home-indexe yönlendirir.
            });
        }
    }
}