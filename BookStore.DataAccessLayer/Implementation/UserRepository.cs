using BookStore.DataAccessLayer.Interface;
using BookStore.DomainModels.Models.DBModel;
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
    public class UserRepository : IUserRepository
    {
        private readonly BookstoreDBContext _bookstoreDBContext;
        public UserRepository(BookstoreDBContext bookstoreDBContext)
        {
            _bookstoreDBContext = bookstoreDBContext;
        }

        public async Task<User> Login(User user)
        {
          return _bookstoreDBContext.User
                .Where(users=>users.Email.Equals(users.Email) && users.Password.Equals(users.Password))
                .FirstOrDefault();
        }

        public async Task<bool> Register(User user)
        {
            await _bookstoreDBContext.AddAsync(user);
            var rowCount = await _bookstoreDBContext.SaveChangesAsync();
            return (rowCount != 0);
        }
    }
}