using LIbrary.Repository.Generic;
using Microsoft.AspNetCore.Identity;

namespace LIbrary.Models
{
    public class Librarian : IdentityUser, IEntityBase
    {
        public virtual ICollection<BorrowItem> borrowItems { get; set; } = new List<BorrowItem>();
    }
}
