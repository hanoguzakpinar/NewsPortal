using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsPortal.Entities.Concrete;
using NewsPortal.Entities.Dtos;

namespace NewsPortal.Mvc.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int CategoriesCount { get; set; }
        public int ReportsCount { get; set; }
        public int CommentsCount { get; set; }
        public int UsersCount { get; set; }
        public ReportListDto Reports { get; set; }
    }
}