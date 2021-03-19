﻿using BookStore.BussinessLayer.Interface;
using BookStore.DataAccessLayer.Interface;
using BookStore.DomainModels.Models.Configurations;
using BookStore.DomainModels.Models.Constants;
using BookStore.DomainModels.Models.DBModels;
using BookStore.DomainModels.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class UserController : Controller
    {
        public IUserService UserService { get; }

        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpGet]
        [Route("[Controller]/Login")]
        public IActionResult Login() => View();

        [HttpPost]
        [Route("[Controller]/Login")]
        public async Task<IActionResult> Login(LoginViewModel signinModel)
        {
            if (ModelState.IsValid)
            {
                var user = UserService.Login(signinModel);
                if (user != null)
                {
                    var claimIdenties = new ClaimsIdentity("Custom");
                    var claimPrincipal = new ClaimsPrincipal(claimIdenties);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,claimPrincipal,
                        new AuthenticationProperties()
                        {
                            ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                            IsPersistent = true,
                            AllowRefresh = true
                        });
                    return RedirectToAction("GetAllBook", "BookStore");
                }
                ModelState.AddModelError("", "Invalid Credentials");
            }

            return View();
        }

        [HttpGet]
        [Route("[Controller]/")]
        [Route("[Controller]/SignUp")]
        public IActionResult SignUp() => View();

        [HttpPost]
        [Route("[Controller]/")]
        [Route("[Controller]/SignUp")]
        public async Task<IActionResult> SignUp(SignupViewModel signupViewModel)
        {
            if (ModelState.IsValid)
            {
                var isValid = await UserService.Register(signupViewModel);
                if (isValid)
                    return RedirectToAction("Login");
            }
            return View();
        }
    }
}
