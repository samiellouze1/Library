using LIbrary.Repository.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LIbrary.Models
{
    public class Reader: IdentityUser, IEntityBase
    {
        public virtual ICollection<Borrow> borrows { get; set; }
    }
}
