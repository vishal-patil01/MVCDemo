using BookStore.DomainModels.Models.Constants;
using BookStore.DomainModels.Models.DBModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.DBModel
{
    public class BookstoreDBContext : DbContext
    {
        public BookstoreDBContext()
        {
        }

        public BookstoreDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book> Book { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<User_Roles> User_Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().HasData(
                new Roles
                {
                    Id=1,
                    RoleName = RolesEnum.Admin
                },
                 new Roles
                 {
                     Id=2,
                     RoleName = RolesEnum.User
                 }
            );
        }
    }
}
