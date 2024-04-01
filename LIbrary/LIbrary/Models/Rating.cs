using LIbrary.Repository.Generic;
using System.ComponentModel.DataAnnotations;

namespace LIbrary.Models
{
    public class Rating:IEntityBase
    {
        [Key]
        public string Id { get; set; }
        public int? rating { get; set; }
        public string? bookId { get; set; }
        public virtual Book book { get; set; } = new Book();
    }
}
