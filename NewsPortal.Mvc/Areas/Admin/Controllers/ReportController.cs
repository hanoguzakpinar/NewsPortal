using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Data.Abstract;
using NewsPortal.Mvc.Areas.Admin.Models;
using NewsPortal.Services.Abstract;
using NewsPortal.Shared.Utilities.Results.ComplexTypes;

namespace NewsPortal.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly ICategoryService _categoryService;

        public ReportController(IReportService reportService, ICategoryService categoryService)
        {
            _reportService = reportService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _reportService.GetAllNonDeletedAsync();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var result = await _categoryService.GetAllNonDeletedAsync();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(new ReportAddViewModel
                {
                    Categories = result.Data.Categories
                });
            }

            return NotFound();
        }
    }
}
