using BookStore.BussinessLayer.Interface;
using BookStore.DataAccessLayer.Interface;
using BookStore.DomainModels.Models.Configurations;
using BookStore.DomainModels.Models.Constants;
using BookStore.DomainModels.Models.DBModels;
using BookStore.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class UserController : Controller
    {
        public UserController()
        {
        }

        [HttpGet]
        [Route("[Controller]/Login")]
        public IActionResult Login() => View();

        [HttpGet]
        [Route("[Controller]/")]
        [Route("[Controller]/SignUp")]
        public IActionResult SignUp() => View();
    }
}
