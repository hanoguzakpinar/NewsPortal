using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Entities.Concrete;
using NewsPortal.Entities.Dtos;
using NewsPortal.Mvc.Areas.Admin.Models;
using NewsPortal.Services.Abstract;
using NewsPortal.Shared.Utilities.Extensions;
using NewsPortal.Shared.Utilities.Results.ComplexTypes;

namespace NewsPortal.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAllNonDeleted();

            return View(result.Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_CategoryAddPartial");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int categoryId)
        {
            var result = await _categoryService.GetCategoryUpdateDto(categoryId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return PartialView("_CategoryUpdatePartial", result.Data);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.Update(categoryUpdateDto, "Oğuzhan Akpınar");
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var categoryUpdateAjaxModel = JsonSerializer.Serialize(new CategoryUpdateAjaxViewModel
                    {
                        CategoryDto = result.Data,
                        CategoryUpdatePartial = await this.RenderViewToStringAsync("_CategoryUpdatePartial", categoryUpdateDto)
                    });
                    return Json(categoryUpdateAjaxModel);
                }
            }
            var categoryUpdateAjaxErrorModel = JsonSerializer.Serialize(new CategoryUpdateAjaxViewModel
            {
                CategoryUpdatePartial = await this.RenderViewToStringAsync("_CategoryUpdatePartial", categoryUpdateDto)
            });
            return Json(categoryUpdateAjaxErrorModel);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.Add(categoryAddDto, "Oğuzhan Akpınar");
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var categoryAddAjaxModel = JsonSerializer.Serialize(new CategoryAddAjaxViewModel
                    {
                        CategoryDto = result.Data,
                        CategoryAddPartial = await this.RenderViewToStringAsync("_CategoryAddPartial", categoryAddDto)
                    });
                    return Json(categoryAddAjaxModel);
                }
            }
            var categoryAddAjaxErrorModel = JsonSerializer.Serialize(new CategoryAddAjaxViewModel
            {
                CategoryAddPartial = await this.RenderViewToStringAsync("_CategoryAddPartial", categoryAddDto)
            });
            return Json(categoryAddAjaxErrorModel);
        }

        public async Task<JsonResult> GetAllCategories()
        {
            var result = await _categoryService.GetAllNonDeleted();
            var categories = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(categories);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int categoryId)
        {
            var result = await _categoryService.Delete(categoryId, "Oğuzhan Akpınar");
            var deletedeCategory = JsonSerializer.Serialize(result.Data);
            return Json(deletedeCategory);
        }
    }
}