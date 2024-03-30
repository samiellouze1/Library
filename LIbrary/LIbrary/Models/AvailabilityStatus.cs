using LIbrary.Repository.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIbrary.Models
{
    public class AvailabilityStatus:IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual string Id { get; set; }
        [Required]
        public string name { get; set; } = "Available";
        public virtual ICollection<BookCopy> bookCopies { get; set; }
    }
}
