using BookStore.DomainModels.Models.Constants;
using System.ComponentModel.DataAnnotations;

namespace BookStore.DomainModels.Models.DBModel
{
    public class Roles
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Roles Should Not Be Empty")]
        public RolesEnum RoleName { get; set; }
    }
}
