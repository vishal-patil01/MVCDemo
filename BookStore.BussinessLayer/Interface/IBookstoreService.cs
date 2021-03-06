using BookStore.DomainModels.Models.ViewModel;
using BookStore.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BussinessLayer.Interface
{
    public interface IBookstoreService
    {
        public Task<bool> AddBook(BookViewModel book);
        public Task<List<BookViewModel>> GetAllBook();
        public Task<BookViewModel> GetBookDetails(int id);
    }
}
