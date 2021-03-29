using BookStore.BussinessLayer.Interface;
using BookStore.DataAccessLayer.Interface;
using BookStore.DomainModels.Models.Configurations;
using BookStore.DomainModels.Models.Constants;
using BookStore.DomainModels.Models.DBModels;
using BookStore.DomainModels.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
                var user = await UserService.Login(signinModel);
                var role =await UserService.GetUserRole(user);
                if (user != null)
                {
                    var userclaim = new List<Claim>
                    {
                    new Claim("UserId",user.ID.ToString()),
                    new Claim("UserName",user.FirstName+" "+user.LastName),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.Role,role.RoleId.RoleName.ToString())
                    };
                    var claimIdenties = new ClaimsIdentity(userclaim, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimPrincipal = new ClaimsPrincipal(claimIdenties);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal,
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
        public async Task<IActionResult> SignUp() {
            ViewBag.Roles =  await UserService.GetRoles();
            return View();
        } 

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

        [HttpGet]
        [Route("[Controller]/SignOut")]
        public async Task<IActionResult> SignOut(LoginViewModel signinModel)
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new AuthenticationProperties()
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = true,
                    AllowRefresh = true
                });
            return RedirectToAction("GetAllBook", "BookStore");
        }

        [AllowAnonymous]
        [AcceptVerbs("Get","Post")]
        public async Task<IActionResult> CheckEmailExists(string email)
        {
            var notExist = await UserService.IsEmailExist(email);
            if (notExist)
            {
                return Json(true);
            }
            return Json($"{email} Is Already Exists.");
        }
    }
}
