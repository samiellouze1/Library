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
    }
}
