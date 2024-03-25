using LIbrary.Repository.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIbrary.Models
{
    public class Book:IEntityBase
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string description { get; set; }
        [Required]  
        public DateTime dateOfCreation { get; set; }
        [Required]
        public String coverUrl { get; set; }
        [ForeignKey("author")]
        public int authorId { get; set; }
        public Author author { get; set; }
    }
}
