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
            serviceCollection.AddIdentity<User, Role>().AddEntityFrameworkStores<NewsPortalContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IReportService, ReportManager>();

            return serviceCollection;
        }
    }
}