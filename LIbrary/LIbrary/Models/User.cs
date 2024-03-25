using LIbrary.Repository.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LIbrary.Models
{
    public class User: IdentityUser, IEntityBase
    {
        [Key] 
        public int id { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
    }
}
