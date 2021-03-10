using BookStore.DataAccessLayer.Interface;
using BookStore.Models.DBModel;
using BookStore.Models.ViewModel;
using Microsoft.Extensions.Configuration;
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
            return (rowCount != 0) ? true : false;
        }

        public async Task<List<Book>> GetAllBook()
        {
            return _bookstoreDBContext.Book.ToList();
        }

        public async Task<Book> GetBookDetails(int id)
        {
           return _bookstoreDBContext.Book.Where(book => book.Id.Equals(id)).First();
        }
    }
}
