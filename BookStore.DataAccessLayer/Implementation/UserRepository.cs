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

        public async Task<User> Login(User user)
        {
            return await _bookstoreDBContext.User.Where(users => users.Email == user.Email && users.Password == user.Password).FirstOrDefaultAsync();
        }

        public async Task<User_Roles> GetUserRole(User user)
        {
            return await _bookstoreDBContext.User_Roles.Where(ur => ur.UserId == user)
                .Select(ur => new User_Roles()
                {
                    UserId = ur.UserId,
                    RoleId = ur.RoleId
                }).FirstOrDefaultAsync();
        }

        public async Task<bool> Register(User user, Roles role)
        {
            int rowCount = 0;
            using (var dbContext = _bookstoreDBContext)
            {
                var registerdUser = await dbContext.AddAsync(user);
                var registerdRole = await dbContext.Roles.FindAsync(role.Id);
                await dbContext.SaveChangesAsync();
                var user_roles = new User_Roles()
                {
                    UserId = user,
                    RoleId = registerdRole,
                };
                await dbContext.AddAsync(user_roles);
                rowCount = await dbContext.SaveChangesAsync();
            }
            return (rowCount > 0);
        }
        public async Task<List<Roles>> GetRoles()
        {
            return await _bookstoreDBContext.Roles.ToListAsync();
        }

        public async Task<User> IsEmailExist(string email)
        {
            return await _bookstoreDBContext.User.Where(users => users.Email == email).FirstOrDefaultAsync();
        }
    }
}