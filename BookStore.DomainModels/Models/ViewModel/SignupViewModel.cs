using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore.DomainModels.Models.ViewModel
{
    public class SignupViewModel
    {
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
