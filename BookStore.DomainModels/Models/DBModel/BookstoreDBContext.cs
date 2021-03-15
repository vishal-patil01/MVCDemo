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
    }
}
