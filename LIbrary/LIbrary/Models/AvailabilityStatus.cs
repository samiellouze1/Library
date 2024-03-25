using LIbrary.Repository.Generic;
using System.ComponentModel.DataAnnotations;

namespace LIbrary.Models
{
    public class AvailabilityStatus:IEntityBase
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
    }
}
