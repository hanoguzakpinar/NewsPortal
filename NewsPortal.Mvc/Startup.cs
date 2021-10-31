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
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Admin/User/Login");//giriþ sayfasýný belirtme.
                options.LogoutPath = new PathString("/Admin/User/Logout");//çýkýþ sayfasýný belirtme.
                options.Cookie = new CookieBuilder
                {
                    Name = "NewsPortal",
                    HttpOnly = true,//cookie bilgilerini gizleme
                    SameSite = SameSiteMode.Strict, //csrf saldýrýlarýný önlemek için önemlidir.
                                                    //Sadece bizim siteden gelen cookileri kabul eder.
                    SecurePolicy = CookieSecurePolicy.SameAsRequest,//Always olmazsa güvenlik açýðý oluþturur,
                    //Geliþtirme ortamýnda olduðumuz için SameAsRequestte býraktýk.

                };
                options.SlidingExpiration = true;//kullanýcý tekrar giriþ yaptýðýnda süresini uzatmak için.
                options.ExpireTimeSpan = System.TimeSpan.FromDays(7);//giriþ yaptýktan sonra {7} gün boyunca tekrar giriþ yapmasýna gerek kalmaz.
                options.AccessDeniedPath = new PathString("/Admin/User/AccessDenied");//Yetkisiz giriþ yapýldýðýnda nereye yönlendirilsin.
            });
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