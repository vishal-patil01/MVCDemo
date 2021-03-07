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
        [Required]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(500)]
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string Author { get; set; }

        [Required]
        [DisplayName("Number Of Pages")]
        public int NumberOfPages { get; set; }
        
        [DataType(DataType.DateTime)]
        public string CreationDate { get; set; }
    }
}
