using LIbrary.Repository.Generic;
using Microsoft.AspNetCore.Identity;

namespace LIbrary.Models
{
    public class Librarian : IdentityUser, IEntityBase
    {
        public virtual ICollection<BorrowItem> borrows { get; set; }
    }
}
