using LIbrary.Repository.Generic;
using System.ComponentModel.DataAnnotations;

namespace LIbrary.Models
{
    public class Borrow: IEntityBase
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public DateOnly dateOfBorrow { get; set; }
        [Required]
        public DateOnly dateOfReturn { get; set; }
        public string bookCopyId { get; set; }
        public virtual  BookCopy bookCopy { get; set; }
        public string readerId { get; set; }
        public virtual Reader reader { get; set; }
        public string librarianId { get; set; }
        public virtual Librarian librarian {  get; set; }
    }
}
