using LIbrary.Repository.Generic;
using System.ComponentModel.DataAnnotations;

namespace LIbrary.Models
{
    public class Author:IEntityBase
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string name { get; set; }
        public virtual ICollection<Book> books { get; set; }
    }
}
