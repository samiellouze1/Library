using LIbrary.Repository.Generic;
using System.ComponentModel.DataAnnotations;

namespace LIbrary.Models
{
    public class Borrow:IEntityBase
    {
        [Key]
        public string Id { get; set; }
        public DateOnly dateOfBorrow { get; set; }
        public DateOnly dateOfReturn { get; set; }
        public string? readerId { get; set; }
        public virtual Reader reader { get; set; }
        public virtual ICollection<BorrowItem> borrowItems { get; set; }

    }
}
