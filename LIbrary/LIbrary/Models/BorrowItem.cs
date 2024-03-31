using LIbrary.Repository.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIbrary.Models
{
    public class BorrowItem: IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string? bookCopyId { get; set; }
        public virtual BookCopy bookCopy { get; set; } = new BookCopy();
        public string? borrowId { get; set; }
        public virtual Borrow borrow { get; set; } = new Borrow();
        public string? librarianId { get; set; }
        public virtual Librarian librarian { get; set; } = new Librarian();
        public string? borrowItemStatusId { get; set; }
        public virtual BorrowItemStatus borrowItemStatus { get; set; }= new BorrowItemStatus();
    }
}
