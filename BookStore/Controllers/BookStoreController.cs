using BookStore.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookStoreController : Controller
    {
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

            }
            return View();
        }
        public IActionResult GetAllBook()
        {
            return View();
        }
    }
}
