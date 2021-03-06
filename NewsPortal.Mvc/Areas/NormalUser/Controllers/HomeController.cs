using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Entities.ComplexTypes;
using NewsPortal.Entities.Concrete;
using NewsPortal.Entities.Dtos;
using NewsPortal.Mvc.Areas.Admin.Controllers;
using NewsPortal.Mvc.Helpers.Abstract;
using NewsPortal.Mvc.Helpers.Concrete;
using NewsPortal.Services.Abstract;
using NewsPortal.Services.Concrete;
using NewsPortal.Shared.Utilities.Results.ComplexTypes;
using NToastNotify;

namespace NewsPortal.Mvc.Areas.NormalUser.Controllers
{
    [Area("NormalUser")]
    public class HomeController : BaseController
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IReportService _reportService;
        private readonly IMailService _mailService;
        public HomeController(UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper, SignInManager<User> signInManager, IReportService reportService, IMailService mailService) : base(userManager, mapper, imageHelper)
        {
            _signInManager = signInManager;
            _reportService = reportService;
            _mailService = mailService;
        }

        [Authorize(Roles = "Normal")]
        [HttpGet]
        public async Task<ViewResult> Index()
        {
            var user = await UserManager.GetUserAsync(HttpContext.User);
            var updateDto = Mapper.Map<UserUpdateDto>(user);
            return View(updateDto);
        }

        [Authorize(Roles = "Normal")]
        [HttpPost]
        public async Task<ViewResult> Index(UserUpdateDto userUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool isNewPictureUploaded = false;
                var oldUser = await UserManager.GetUserAsync(HttpContext.User);
                var oldUserPicture = oldUser.Picture;
                if (userUpdateDto.PictureFile != null)
                {
                    var uploadedImageDtoResult = await ImageHelper.Upload(userUpdateDto.UserName, userUpdateDto.PictureFile, PictureType.User);
                    userUpdateDto.Picture = uploadedImageDtoResult.ResultStatus == ResultStatus.Success ? uploadedImageDtoResult.Data.FullName : "userImages/defaultUser.jpg";

                    if (oldUserPicture != "userImages/defaultUser.jpg")
                    {
                        isNewPictureUploaded = true;
                    }
                }

                var updatedUser = Mapper.Map<UserUpdateDto, User>(userUpdateDto, oldUser);
                var result = await UserManager.UpdateAsync(updatedUser);
                if (result.Succeeded)
                {
                    if (isNewPictureUploaded)
                    {
                        ImageHelper.Delete(oldUserPicture);
                    }

                    TempData["SuccessMessage"] = "Bilgileriniz güncellenmiştir.";
                    return View(userUpdateDto);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(userUpdateDto);
                }
            }
            else
            {
                return View(userUpdateDto);
            }
        }

        [Authorize(Roles = "Normal")]
        [HttpGet]
        public ViewResult PasswordChange()
        {
            return View();
        }

        [Authorize(Roles = "Normal")]
        [HttpPost]
        public async Task<ViewResult> PasswordChange(UserPasswordChangeDto passwordChangeDto)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.GetUserAsync(HttpContext.User);
                var isVerified =
                    await UserManager.CheckPasswordAsync(user, passwordChangeDto.CurrentPassword);
                if (isVerified)
                {
                    var result = await UserManager.ChangePasswordAsync(user,
                        passwordChangeDto.CurrentPassword, passwordChangeDto.NewPassword);
                    if (result.Succeeded)
                    {
                        await UserManager
                            .UpdateSecurityStampAsync(
                                user); //önemli bir işlem olduğu için stamp değiştirilir.
                        await _signInManager
                            .SignOutAsync(); //şifre değiştirilince çıkış yaptırılır.
                        await _signInManager.PasswordSignInAsync(user,
                            passwordChangeDto.NewPassword, true, false);
                        //4. parametre yanlış girişte hesap kilitlensin mi? 3.parametre beni hatırla kısmı.

                        TempData["SuccessMessage"] = "Şifreniz başarıyla güncellenmiştir.";
                        return View();
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                        return View(passwordChangeDto);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Lütfen, şifrenizi kontrol ediniz.");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles = "Normal")]
        [HttpGet]
        public async Task<IActionResult> Reports()
        {
            var result = await _reportService.GetAllNonDeletedAsync();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }

            return NotFound();
        }

        [Authorize(Roles = "Normal")]
        [HttpGet]
        public async Task<IActionResult> ReportDetail(int reportId)
        {
            var report = await _reportService.GetAsync(reportId);
            if (report.ResultStatus == ResultStatus.Success)
            {
                return View(report.Data);
            }

            return NotFound();
        }

        [Authorize(Roles = "Normal")]
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [Authorize(Roles = "Normal")]
        [HttpPost]
        public IActionResult Contact(EmailSendDto emailSendDto)
        {
            if (ModelState.IsValid)
            {
                emailSendDto.Name = LoggedInUser.FirstName + " " + LoggedInUser.LastName;
                emailSendDto.Email = LoggedInUser.Email;
                var result = _mailService.SendContactEmail(emailSendDto);
                TempData["SuccessMessage"] = "Mesajınız başarılı bir şekilde gönderildi.";
                return View();
            }

            return View(emailSendDto);
        }
    }
}