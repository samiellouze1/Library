using LIbrary.Repository.Generic;
using System.ComponentModel.DataAnnotations;

namespace LIbrary.Models
{
    public class BookCopy : IEntityBase
    {
        [Key]
        public int id { get; set; }
        public int bookId { get; set; }
        public Book book { get; set; }
        public int availabilityStatusId { get; set; }
        public AvailabilityStatus availabilityStatus { get; set; }
        public int bookCopyStatusId { get; set; }
        public BookCopyStatus bookCopyStatus { get; set; }
        public int bookCopyId { get; set; }
        public BookCopy bookCopy { get; set; }
        public ICollection<Borrow> borrows { get; set; }

    }
}
