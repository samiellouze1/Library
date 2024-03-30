using LIbrary.Repository.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIbrary.Models
{
    public class Reader: IdentityUser, IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual ICollection<Borrow> borrows { get; set; }
    }
}
