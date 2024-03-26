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
        public string userId { get; set; }
        public virtual User user { get; set; }
    }
}
