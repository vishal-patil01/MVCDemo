using BookStore.BussinessLayer.Interface;
using BookStore.DataAccessLayer.Interface;
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
    public class BookStoreController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IBookstoreService _bookstoreService;
        private readonly IOptions<ConfigurationsProperties> _configurationProperties;
        public BookStoreController(IWebHostEnvironment environment, IBookstoreService bookstoreService, IOptions<ConfigurationsProperties> configurationProperties)
        {
            _environment = environment;
            _bookstoreService = bookstoreService;
            _configurationProperties = configurationProperties;
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
                book.CoverImageUrl = await UploadImages(_configurationProperties.Value.CoverImagePath, book.CoverImage);
                book.BookGallary_Images_URL = new List<BookImages>();
                foreach (var bookgallary in book.BookGallary_Images)
                {
                    var image = new BookImages()
                    {
                        BookId = book.Id,
                        ImageUrl = await UploadImages(_configurationProperties.Value.GalleryImagesPath, bookgallary)
                    };
                    book.BookGallary_Images_URL.Add(image);
                }
                await _bookstoreService.AddBook(book);
                ModelState.Clear();
                return View();
            }
            ModelState.AddModelError("", "Please fill form");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
            var books = await _bookstoreService.GetAllBook();
            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> GetBookDetails(int id)
        {
            var book = await _bookstoreService.GetBookDetails(id);
            return View(book);
        }
        private async Task<string> UploadImages(string path, IFormFile file)
        {
            var localPath = path + Guid.NewGuid().ToString() + file.FileName;
            string imagesPath = Path.Combine(_environment.WebRootPath, localPath);
            await file.CopyToAsync(new FileStream(imagesPath, FileMode.Create));
            return "/" + localPath;
        }
    }
}
