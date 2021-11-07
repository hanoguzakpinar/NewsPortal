using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewsPortal.Mvc.AutoMapper.Profiles;
using NewsPortal.Mvc.Helpers.Abstract;
using NewsPortal.Mvc.Helpers.Concrete;
using NewsPortal.Services.AutoMapper.Profiles;
using NewsPortal.Services.Extensions;

namespace NewsPortal.Mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(options =>
            {
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(value => "Bu alan bo� ge�ilmemelidir.");
            }).AddRazorRuntimeCompilation().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            }).AddNToastNotifyToastr();
            //mvc ve razor runtime package dahil etme.
            services.AddSession();//session yap�s�n� ekleme.
            services.AddAutoMapper(typeof(CategoryProfile), typeof(ReportProfile), typeof(UserProfile), typeof(ViewModelsProfile), typeof(CommentProfile));//automapperi dahil etme.
            services.LoadMyServices(connectionString: Configuration.GetConnectionString("LocalDB"));
            services.AddScoped<IImageHelper, ImageHelper>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Admin/Auth/Login");//giri� sayfas�n� belirtme.
                options.LogoutPath = new PathString("/Admin/Auth/Logout");//��k�� sayfas�n� belirtme.
                options.Cookie = new CookieBuilder
                {
                    Name = "NewsPortal",
                    HttpOnly = true,//cookie bilgilerini gizleme
                    SameSite = SameSiteMode.Strict, //csrf sald�r�lar�n� �nlemek i�in �nemlidir.
                                                    //Sadece bizim siteden gelen cookileri kabul eder.
                    SecurePolicy = CookieSecurePolicy.SameAsRequest,//Always olmazsa g�venlik a���� olu�turur,
                    //Geli�tirme ortam�nda oldu�umuz i�in SameAsRequestte b�rakt�k.

                };
                options.SlidingExpiration = true;//kullan�c� tekrar giri� yapt���nda s�resini uzatmak i�in.
                options.ExpireTimeSpan = System.TimeSpan.FromDays(7);//giri� yapt�ktan sonra {7} g�n boyunca tekrar giri� yapmas�na gerek kalmaz.
                options.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");//Yetkisiz giri� yap�ld���nda nereye y�nlendirilsin.
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())//geli�tirme ayarlar�
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();//varolmayan viewlere gidildi�inde 404 f�rlat�r.
            }

            app.UseSession();//authen ve authodan �nce tan�mlanmal�d�r.

            app.UseStaticFiles();//wwwroot dosyalar�na eri�im

            app.UseRouting();

            app.UseAuthentication();//kimlik kontrol�

            app.UseAuthorization();//yetki kontrol�

            app.UseNToastNotify(); // toastr ekleme

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"//id nullable
                );
                endpoints.MapDefaultControllerRoute();//varsay�lan olarak home-indexe y�nlendirir.
            });
        }
    }
}