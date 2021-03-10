using BookStore.BussinessLayer.Interface;
using BookStore.DataAccessLayer.Interface;
using BookStore.DomainModels.Models.Constants;
using BookStore.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
        private readonly IBookstoreService _bookstoreService;
        public BookStoreController(IWebHostEnvironment environment, IBookstoreService bookstoreService)
        {
            _environment = environment;
            _bookstoreService = bookstoreService;
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
        public async Task<IActionResult> AddBook(BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                if (!book.CoverImage.ContentType.Contains("image") && book.CoverImage == null)
                {
                    ModelState.AddModelError("", "Please Upload Only Image File");
                    return View();
                }
                string imagesPath = _environment.WebRootPath + "/Images/Covers/" + Guid.NewGuid().ToString() + book.CoverImage.FileName;
                await book.CoverImage.CopyToAsync(new FileStream(imagesPath, FileMode.Create));
                book.CoverImageUrl = imagesPath;
                await _bookstoreService.AddBook(book);
                return View();
            }
            ModelState.AddModelError("", "Please fill form");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
            var books= await _bookstoreService.GetAllBook();
            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> GetBookDetails(int id)
        {
            var book = await _bookstoreService.GetBookDetails(id);
            return View(book);
        }
    }
}
