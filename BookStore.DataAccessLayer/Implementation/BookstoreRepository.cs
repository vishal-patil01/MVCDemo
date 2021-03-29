using BookStore.DataAccessLayer.Interface;
using BookStore.DomainModels.Models.DBModels;
using BookStore.DomainModels.Models.ViewModel;
using BookStore.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Implementation
{
    public class BookstoreRepository : IBookstoreRepository
    {
        private readonly BookstoreDBContext _bookstoreDBContext;
        public BookstoreRepository(BookstoreDBContext bookstoreDBContext)
        {
            _bookstoreDBContext = bookstoreDBContext;
        }

        public async Task<bool> AddBook(Book book)
        {
            await _bookstoreDBContext.AddAsync(book);
            int rowCount = await _bookstoreDBContext.SaveChangesAsync();
            return (rowCount != 0);
        }

        public async Task<List<Book>> GetAllBook()
        {
            return _bookstoreDBContext.Book.ToList();
        }

        public async Task<BookViewModel> GetBookDetails(int id)
        {
            return _bookstoreDBContext.Book.Where(book => book.Id.Equals(id))
                 .Select(book => new BookViewModel()
                 {
                     Id = book.Id,
                     Author = book.Author,
                     Title = book.Title,
                     CoverImageUrl = book.CoverImage,
                     Description = book.Description,
                     NumberOfPages = book.NumberOfPages,
                     BookGallary_Images_URL = book.BookGallary_Images.Select(images => new BookImages()
                     {
                         Id = images.Id,
                         BookId = images.BookId,
                         ImageUrl = images.ImageUrl
                     }).ToList()

                 }).FirstOrDefault();
        }
    }
}
