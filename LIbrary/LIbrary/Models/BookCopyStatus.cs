using LIbrary.Repository.Generic;
using System.ComponentModel.DataAnnotations;

namespace LIbrary.Models
{
    public class BookCopyStatus:IEntityBase
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int name { get; set; }
        public ICollection<BookCopy> bookCopies { get; set; }

    }
}
