using BookStore.BussinessLayer.Interface;
using BookStore.DataAccessLayer.Interface;
using BookStore.DomainModels.Models.DBModel;
using BookStore.DomainModels.Models.ViewModel;
using BookStore.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BussinessLayer.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Login(LoginViewModel loginViewModel)
        {
            User user = new User()
            {
                Email = loginViewModel.Email,
                Password = loginViewModel.Password
            };
            return _userRepository.Login(user);
        }

        public async Task<bool> Register(SignupViewModel signupViewModel)
        {
            User user = new User()
            {
                FirstName = signupViewModel.FirstName,
                LastName = signupViewModel.LastName,
                Email = signupViewModel.Email,
                Password = signupViewModel.Password
            };
            return await _userRepository.Register(user, signupViewModel.Role);
        }

        public async Task<User_Roles> GetUserRole(User user)
        {
            return await _userRepository.GetUserRole(user);
        }
        public async Task<List<Roles>> GetRoles()
        {
            return await _userRepository.GetRoles();
        }

        public async Task<bool> IsEmailExist(string email)
        {
            return await _userRepository.IsEmailExist(email) == null;
        }
    }
}
