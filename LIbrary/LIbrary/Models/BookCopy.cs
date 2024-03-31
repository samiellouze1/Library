using LIbrary.Repository.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIbrary.Models
{
    public class BookCopy : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string? bookId { get; set; }
        public virtual Book book { get; set; } = new Book();
        public string? bookCopyStatusId { get; set; }
        public virtual BookCopyStatus bookCopyStatus { get; set; } = new BookCopyStatus();
        public virtual ICollection<BorrowItem> borrowItems { get; set; } = new List<BorrowItem>();

    }
}
