using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DomainModels.Models.DBModel
{
    public class User_Roles
    {
        public int Id { get; set; }
        public User UserId { get; set; }
        public Roles RoleId { get; set; }
    }
}
