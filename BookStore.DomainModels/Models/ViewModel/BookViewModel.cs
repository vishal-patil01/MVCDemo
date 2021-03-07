using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.ViewModel
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [DataType(DataType.Text)]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        [StringLength(500)]
        public string Description { get; set; }
        public string Author { get; set; }
        [DisplayName("Number Of Pages")]
        public int NumberOfPages { get; set; }
        [DataType(DataType.DateTime)]
        public string CreationDate { get; set; }
    }
}
