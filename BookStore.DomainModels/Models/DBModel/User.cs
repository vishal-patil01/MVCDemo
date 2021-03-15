using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore.DomainModels.Models.DBModel
{
    public class User
    {
        public int ID { get; set; }

        [DataType(DataType.Text)]
        [Required]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Required]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}
