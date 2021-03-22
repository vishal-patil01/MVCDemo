using BookStore.DomainModels.Models.DBModel;
using BookStore.DomainModels.Models.ViewModel;
using BookStore.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Interface
{
    public interface IUserRepository
    {
        public User Login(User user);
        public Task<bool> Register(User user);
        public Task<User> IsEmailExist(string email);
    }
}
