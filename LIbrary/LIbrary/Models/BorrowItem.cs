using LIbrary.Repository.Generic;
using System.ComponentModel.DataAnnotations;

namespace LIbrary.Models
{
    public class BorrowItem: IEntityBase
    {
        [Key]
        public string Id { get; set; }
        public string bookCopyId { get; set; }
        public virtual  BookCopy bookCopy { get; set; }
        public string borrowId { get; set; }
        public virtual Borrow borrow { get; set; }
        public string librarianId { get; set; }
        public virtual Librarian librarian { get; set; }
    }
}
