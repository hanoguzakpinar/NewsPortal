using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
using NToastNotify;

namespace NewsPortal.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportController : BaseController
    {
        private readonly IReportService _reportService;
        private readonly ICategoryService _categoryService;
        private readonly IToastNotification _toastNotification;

        public ReportController(IReportService reportService, ICategoryService categoryService, UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper, IToastNotification toastNotification) : base(userManager, mapper, imageHelper)
        {
            _reportService = reportService;
            _categoryService = categoryService;
            _toastNotification = toastNotification;
        }

        [Authorize(Roles = "SuperAdmin,Report.Read")]
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

        [Authorize(Roles = "SuperAdmin,Report.Create")]
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

        [Authorize(Roles = "SuperAdmin,Report.Create")]
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
                    _toastNotification.AddSuccessToastMessage(result.Message, new ToastrOptions
                    {
                        Title = "Başarılı İşlem!"
                    });
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

        [Authorize(Roles = "SuperAdmin,Report.Update")]
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

        [Authorize(Roles = "SuperAdmin,Report.Update")]
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
                        : "postImages/defaultThumbnail.png";
                    if (oldThumbnail != "postImages/defaultThumbnail.png")
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

                    _toastNotification.AddSuccessToastMessage(result.Message);
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

        [Authorize(Roles = "SuperAdmin,Report.Delete")]
        [HttpPost]
        public async Task<JsonResult> Delete(int reportId)
        {
            var result = await _reportService.DeleteAsync(reportId, LoggedInUser.UserName);
            var reportResult = JsonSerializer.Serialize(result);
            return Json(reportResult);
        }

        [Authorize(Roles = "SuperAdmin,Report.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllReports()
        {
            var reports = await _reportService.GetAllNonDeletedAndActiveAsync();
            var reportResult = JsonSerializer.Serialize(reports, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(reportResult);
        }

        [Authorize(Roles = "SuperAdmin,Report.Read")]
        [HttpGet]
        public async Task<IActionResult> DeletedReports()
        {
            var result = await _reportService.GetAllByDeletedAsync();
            return View(result.Data);

        }
        [Authorize(Roles = "SuperAdmin,Report.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllDeletedReports()
        {
            var result = await _reportService.GetAllByDeletedAsync();
            var reports = JsonSerializer.Serialize(result, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(reports);
        }
        [Authorize(Roles = "SuperAdmin,Report.Update")]
        [HttpPost]
        public async Task<JsonResult> UndoDelete(int reportId)
        {
            var result = await _reportService.UndoDeleteAsync(reportId, LoggedInUser.UserName);
            var undoDeleteReportResult = JsonSerializer.Serialize(result);
            return Json(undoDeleteReportResult);
        }
        [Authorize(Roles = "SuperAdmin,Report.Delete")]
        [HttpPost]
        public async Task<JsonResult> HardDelete(int reportId)
        {
            var result = await _reportService.HardDeleteAsync(reportId);
            var hardDeletedReportResult = JsonSerializer.Serialize(result);
            return Json(hardDeletedReportResult);
        }


    }
}