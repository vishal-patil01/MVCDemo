using BookStore.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DomainModels.Models.DBModels
{
    public class BookImages
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string ImageUrl { get; set; }
    }
}
