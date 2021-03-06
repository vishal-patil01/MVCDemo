using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.DBModel
{
    public class Book
    {
        public int Id { get; set; }
        [DataType(DataType.Text)]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string Author { get; set; }
        [DisplayName("Number Of Pages")]
        public string NumberOfPages { get; set; }
    }
}
