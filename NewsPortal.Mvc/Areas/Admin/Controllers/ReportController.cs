using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Data.Abstract;
using NewsPortal.Entities.ComplexTypes;
using NewsPortal.Entities.Concrete;
using NewsPortal.Entities.Dtos;
using NewsPortal.Mvc.Areas.Admin.Models;
using NewsPortal.Mvc.Helpers.Abstract;
using NewsPortal.Services.Abstract;
using NewsPortal.Shared.Utilities.Results.ComplexTypes;

namespace NewsPortal.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportController : BaseController
    {
        private readonly IReportService _reportService;
        private readonly ICategoryService _categoryService;

        public ReportController(IReportService reportService, ICategoryService categoryService, UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper) : base(userManager, mapper, imageHelper)
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
            var result = await _categoryService.GetAllNonDeletedAndActiveAsync();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(new ReportAddViewModel
                {
                    Categories = result.Data.Categories
                });
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReportAddViewModel reportAddViewModel)
        {
            if (ModelState.IsValid)
            {
                var reportAddDto = Mapper.Map<ReportAddDto>(reportAddViewModel);
                var imageResult = await ImageHelper.Upload(reportAddViewModel.Title, reportAddViewModel.ThumbnailFile, PictureType.Post);
                reportAddDto.Thumbnail = imageResult.Data.FullName;

                var result = await _reportService.AddAsync(reportAddDto, LoggedInUser.UserName, LoggedInUser.Id);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    TempData.Add("SuccessMessage", result.Message);
                    return RedirectToAction("Index", "Report");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }

            var categories = await _categoryService.GetAllNonDeletedAndActiveAsync();
            reportAddViewModel.Categories = categories.Data.Categories;
            return View(reportAddViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int reportId)
        {
            var reportResult = await _reportService.GetReportUpdateDtoAsync(reportId);
            var categoriesResult = await _categoryService.GetAllNonDeletedAndActiveAsync();
            if (reportResult.ResultStatus == ResultStatus.Success && categoriesResult.ResultStatus == ResultStatus.Success)
            {
                var reportUpdateViewModel = Mapper.Map<ReportUpdateViewModel>(reportResult.Data);
                reportUpdateViewModel.Categories = categoriesResult.Data.Categories;
                return View(reportUpdateViewModel);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(ReportUpdateViewModel reportUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                bool isNewThumbnailUploaded = false;
                var oldThumbnail = reportUpdateViewModel.Thumbnail;
                if (reportUpdateViewModel.ThumbnailFile != null)
                {
                    var uploadedImageResult = await ImageHelper.Upload(reportUpdateViewModel.Title,
                        reportUpdateViewModel.ThumbnailFile, PictureType.Post);
                    reportUpdateViewModel.Thumbnail = uploadedImageResult.ResultStatus == ResultStatus.Success
                        ? uploadedImageResult.Data.FullName
                        : "postImages/defaultThumbnail.jpg";
                    if (oldThumbnail != "postImages/defaultThumbnail.jpg")
                    {
                        isNewThumbnailUploaded = true;
                    }
                }
                var reportUpdateDto = Mapper.Map<ReportUpdateDto>(reportUpdateViewModel);
                var result = await _reportService.UpdateAsync(reportUpdateDto, LoggedInUser.UserName);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    if (isNewThumbnailUploaded)
                    {
                        ImageHelper.Delete(oldThumbnail);
                    }
                    TempData.Add("SuccessMessage", result.Message);
                    return RedirectToAction("Index", "Report");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }

            var categories = await _categoryService.GetAllNonDeletedAndActiveAsync();
            reportUpdateViewModel.Categories = categories.Data.Categories;
            return View(reportUpdateViewModel);
        }
    }
}