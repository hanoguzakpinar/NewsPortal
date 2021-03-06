using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Data.Abstract;
using NewsPortal.Entities.Concrete;
using NewsPortal.Shared.Data.Concrete.EntityFramework;

namespace NewsPortal.Data.Concrete.EntityFramework.Repositories
{
    public class EfReportRepository : EfEntityRepositoryBase<Report>, IReportRepository
    {
        public EfReportRepository(DbContext context) : base(context)
        {
        }
    }
}
