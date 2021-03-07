using Microsoft.AspNetCore.Http;
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
        [Required(ErrorMessage = "Title Should Not Be Empty")]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(500)]
        [Required]
        public string Description { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [DisplayName("Number Of Pages")]
        [Range(10, 4000, ErrorMessage = "Value Must Be Greater Than Zero")]
        public int NumberOfPages { get; set; }

        [DataType(DataType.DateTime)]
        public string CreationDate { get; set; }

        [Required]
        [DisplayName("Cover Image")]
        public string CoverImage { get; set; }
    }
}
