using BookStore.DomainModels.Models.DBModel;
using BookStore.DomainModels.Models.ViewModel;
using BookStore.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BussinessLayer.Interface
{
    public interface IUserService
    {
        public User Login(LoginViewModel loginViewModel);
        public Task<bool> Register(SignupViewModel signupViewModel);
        public Task<bool> IsEmailExist(string email);
    }
}
