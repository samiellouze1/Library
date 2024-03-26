using LIbrary.Repository.Generic;
using System.ComponentModel.DataAnnotations;

namespace LIbrary.Models
{
    public class Borrow: IEntityBase
    {
        [Key]
        public int id { get; set; }
        [Required]
        public DateOnly dateOfBorrow { get; set; }
        [Required]
        public DateOnly dateOfReturn { get; set; }
        public int bookCopyId { get; set; }
        public BookCopy bookCopy { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
    }
}
