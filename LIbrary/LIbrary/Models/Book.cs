using LIbrary.Repository.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIbrary.Models
{
    public class Book:IEntityBase
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string description { get; set; }
        [Required]  
        public DateTime dateOfCreation { get; set; }
        [Required]
        public string coverUrl { get; set; }
        [ForeignKey("author")]
        public string authorId { get; set; }
        public virtual Author author { get; set; }
        public string genreId { get; set; }
        public virtual Genre genre { get; set; }
        public virtual ICollection<BookCopy> bookCopies { get; set; }

    }
}
