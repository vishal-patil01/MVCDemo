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
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccessLayer.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly BookstoreDBContext _bookstoreDBContext;
        public UserRepository(BookstoreDBContext bookstoreDBContext)
        {
            _bookstoreDBContext = bookstoreDBContext;
        }

        public User Login(User user)
        {
            return _bookstoreDBContext.User.Where(users => users.Email == user.Email && users.Password == user.Password).FirstOrDefault();
        }

        public async Task<bool> Register(User user)
        {
            await _bookstoreDBContext.AddAsync(user);
            var rowCount = await _bookstoreDBContext.SaveChangesAsync();
            return (rowCount != 0);
        }

        public async Task<User> IsEmailExist(string email)
        {
            return await _bookstoreDBContext.User.Where(users => users.Email == email).FirstOrDefaultAsync();
        }
    }
}