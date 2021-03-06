using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.DBModel
{
    public class BookstoreDBContext : DbContext
    {
        public BookstoreDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BookstoreDBContext> Book { get; set; }
    }
}
