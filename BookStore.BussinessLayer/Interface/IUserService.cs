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
        public Task<bool> Login(LoginViewModel loginViewModel);
        public Task<bool> Register(SignupViewModel signupViewModel);
    }
}
