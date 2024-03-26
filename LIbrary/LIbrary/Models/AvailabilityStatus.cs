using LIbrary.Repository.Generic;
using System.ComponentModel.DataAnnotations;

namespace LIbrary.Models
{
    public class AvailabilityStatus:IEntityBase
    {
        [Key]
        public virtual string Id { get; set; }
        [Required]
        public string name { get; set; }
        public virtual ICollection<BookCopy> bookCopies { get; set; }

    }
}
