using BookStore.DomainModels.Models.DBModels;
using Microsoft.AspNetCore.Http;
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
        [Required(ErrorMessage ="Title Should Not Be Empty")]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(500)]
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string Author { get; set; }

        [Required]
        [DisplayName("Number Of Pages")]
        [Range(10,4000,ErrorMessage ="Value Must Be Greater Than Zero")]
        public int NumberOfPages { get; set; }
        
        [DataType(DataType.DateTime)]
        public string CreationDate { get; set; }

        [DisplayName("Cover Image")]
        public string CoverImageUrl { get; set; }

        [DisplayName("Book Gallery Image")]
        public List<BookImages> BookGallary_Images_URL { get; set; }

        [DisplayName("Cover Image")]
        [DataType(DataType.Upload)]
        public IFormFile CoverImage { get; set; }

        public IFormFileCollection BookGallary_Images { get; set; }
    }
}
