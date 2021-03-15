using BookStore.BussinessLayer.Interface;
using BookStore.DataAccessLayer.Interface;
using BookStore.DomainModels.Models.ViewModel;
using BookStore.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BussinessLayer.Implementation
{
    public class BookstoreService : IBookstoreService
    {
        private readonly IBookstoreRepository _bookstoreRepository;

        public BookstoreService(IBookstoreRepository bookstoreRepository)
        {
            _bookstoreRepository = bookstoreRepository;
        }

        public async Task<bool> AddBook(BookViewModel bookViewModel)
        {
            Book book = new Book()
            {
                Title = bookViewModel.Title,
                Author = bookViewModel.Author,
                CoverImage = bookViewModel.CoverImageUrl,
                Description = bookViewModel.Description,
                NumberOfPages = bookViewModel.NumberOfPages,
                BookGallary_Images=bookViewModel.BookGallary_Images_URL
            };
            return await _bookstoreRepository.AddBook(book);
        }

        public async Task<List<BookViewModel>> GetAllBook()
        {
            List<BookViewModel> bookList = new List<BookViewModel>();
            List<Book> books = await _bookstoreRepository.GetAllBook();
            if (books.Count != 0)
            {
                foreach (Book book in books)
                {
                    bookList.Add(new BookViewModel()
                    {
                        Id = book.Id,
                        Author = book.Author,
                        Title = book.Title,
                        CoverImageUrl = book.CoverImage,
                        Description = book.Description,
                        NumberOfPages = book.NumberOfPages
                    });
                }
            }
            return bookList;
        }

        public async Task<BookViewModel> GetBookDetails(int id)
        {
           return await _bookstoreRepository.GetBookDetails(id);
        }
    }
}
