using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LIbrary.Repository.Generic;

namespace LIbrary.Models
{
    public class BorrowItem:IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public DateTime startDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime endDate { get; set; } = DateTime.Now.AddMonths(1);
        public int? rating { get; set; }
        public string? review { get; set; }
        public string? bookCopyId { get; set; }
        public virtual BookCopy bookCopy { get; set; } = new BookCopy();
        public string? readerId { get; set; }
        public virtual Reader reader { get; set; }
        public string? borrowItemStatusId { get; set; }
        public virtual BorrowItemStatus borrowItemStatus { get; set; } = new BorrowItemStatus();
    }
}
