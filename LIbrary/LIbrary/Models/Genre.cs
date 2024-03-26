using LIbrary.Repository.Generic;
using System.ComponentModel.DataAnnotations;

namespace LIbrary.Models
{
    public class Genre: IEntityBase
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string name { get; set; }
        public virtual ICollection<Book> books { get; set; }

    }
}
