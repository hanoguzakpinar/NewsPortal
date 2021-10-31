using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NewsPortal.Data.Abstract;
using NewsPortal.Data.Concrete;
using NewsPortal.Data.Concrete.EntityFramework.Contexts;
using NewsPortal.Entities.Concrete;
using NewsPortal.Services.Abstract;
using NewsPortal.Services.Concrete;

namespace NewsPortal.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<NewsPortalContext>();
            serviceCollection.AddIdentity<User, Role>(options =>
            {
                //Password Options
                options.Password.RequireDigit = false;//sayı içermesi zorunlu mu?
                options.Password.RequiredLength = 5;//en az kaç uzunlukta olmalı?
                options.Password.RequiredUniqueChars = 0;//özel karakter en az kaç tane olmalı?
                options.Password.RequireNonAlphanumeric = false;//özel karakter zorunlu mu?
                options.Password.RequireLowercase = false;//küçük harf zorunlu mu?
                options.Password.RequireUppercase = false;//büyük harf zorunlu mu?
                //Username and Email Options
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";//kullanıcı adı hangi özel karakterleri içerebilir?
                options.User.RequireUniqueEmail = true;//aynı email adresi bir defa mı kullanılsın?
            }).AddEntityFrameworkStores<NewsPortalContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IReportService, ReportManager>();

            return serviceCollection;
        }
    }
}