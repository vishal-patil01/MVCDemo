using BookStore.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookStoreController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        public BookStoreController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(BookViewModel book)
        {
            if(ModelState.IsValid)
            {
                if(!book.CoverImage.ContentType.Contains("image") && book.CoverImage==null)
                {
                    ModelState.AddModelError("", "Please Upload Only Image File");
                    return View();
                }
                string imagesPath = _environment.WebRootPath + "/Images/Covers/" + Guid.NewGuid().ToString() + book.CoverImage.FileName;
                book.CoverImage.CopyToAsync(new FileStream(imagesPath, FileMode.Create));
                book.CoverImageUrl = imagesPath;
            }
            ModelState.AddModelError("","Please fill form");
            return View();
        }

        [HttpGet]
        public IActionResult GetAllBook()
        {
            return View();
        }
    }
}
