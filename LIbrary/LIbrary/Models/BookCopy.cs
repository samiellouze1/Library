using LIbrary.Repository.Generic;
using System.ComponentModel.DataAnnotations;

namespace LIbrary.Models
{
    public class BookCopy : IEntityBase
    {
        [Key]
        public string Id { get; set; }
        public string bookId { get; set; }
        public virtual Book book { get; set; }
        public string availabilityStatusId { get; set; }
        public virtual AvailabilityStatus availabilityStatus { get; set; }
        public string bookCopyStatusId { get; set; }
        public virtual BookCopyStatus bookCopyStatus { get; set; }
        public virtual ICollection<BorrowItem> borrows { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
