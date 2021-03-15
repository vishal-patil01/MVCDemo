using BookStore.DomainModels.Models.ViewModel;
using BookStore.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Interface
{
    public interface IBookstoreRepository
    {
        public Task<bool> AddBook(Book book);
        public Task<List<Book>> GetAllBook();
        public Task<BookViewModel> GetBookDetails(int id);

    }
}
