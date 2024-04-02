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
        [Required]
        public DateTime startDate { get; set; }
        [Required]
        public DateTime endDate { get; set; }
        public int? rating { get; set; }
        public string? review { get; set; }
        public string? bookCopyId { get; set; }
        public virtual BookCopy bookCopy { get; set; } = new BookCopy();
        public string? librarianId { get; set; }
        public virtual Librarian librarian { get; set; } = new Librarian();
        public string? readerId { get; set; }
        public virtual Reader reader { get; set; }
        public string? borrowItemStatusId { get; set; }
        public virtual BorrowItemStatus borrowItemStatus { get; set; }= new BorrowItemStatus();
    }
}
