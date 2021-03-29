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
        public Task<User> Login(User user);
        public Task<bool> Register(User user,Roles role);
        public Task<User> IsEmailExist(string email);
        public Task<List<Roles>> GetRoles();
        public Task<User_Roles> GetUserRole(User user);
    }
}
