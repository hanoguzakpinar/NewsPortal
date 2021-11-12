﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Entities.ComplexTypes;
using NewsPortal.Entities.Concrete;
using NewsPortal.Entities.Dtos;
using NewsPortal.Mvc.Areas.Admin.Controllers;
using NewsPortal.Mvc.Helpers.Abstract;
using NewsPortal.Mvc.Helpers.Concrete;
using NewsPortal.Shared.Utilities.Results.ComplexTypes;
using NToastNotify;

namespace NewsPortal.Mvc.Areas.NormalUser.Controllers
{
    [Area("NormalUser")]
    public class HomeController : BaseController
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IToastNotification _toastNotification;
        public HomeController(UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper, SignInManager<User> signInManager, IToastNotification toastNotification) : base(userManager, mapper, imageHelper)
        {
            _signInManager = signInManager;
            _toastNotification = toastNotification;
        }

        [Authorize]
        [HttpGet]
        public async Task<ViewResult> Index()
        {
            var user = await UserManager.GetUserAsync(HttpContext.User);
            var updateDto = Mapper.Map<UserUpdateDto>(user);
            return View(updateDto);
        }

        [Authorize]
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
                    userUpdateDto.Picture = uploadedImageDtoResult.ResultStatus == ResultStatus.Success ? uploadedImageDtoResult.Data.FullName : "userImages/defaultUser.png";

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

                    _toastNotification.AddSuccessToastMessage("Bilgileriniz güncellenmiştir.");
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

        [Authorize]
        [HttpGet]
        public ViewResult PasswordChange()
        {
            return View();
        }

        [Authorize]
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

                        _toastNotification.AddSuccessToastMessage("Şifreniz başarıyla güncellenmiştir.");
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
    }
}