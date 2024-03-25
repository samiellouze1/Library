using LIbrary.Repository.Generic;
using System.ComponentModel.DataAnnotations;

namespace LIbrary.Models
{
    public class Author:IEntityBase
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public ICollection<Book> books { get; set; }
    }
}
