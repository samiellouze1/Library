using LIbrary.Repository.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIbrary.Models
{
    public class Reader: IdentityUser, IEntityBase
    {
        public virtual ICollection<Borrow> borrows { get; set; } = new List<Borrow>();
    }
}
