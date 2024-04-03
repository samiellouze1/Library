using LIbrary.Repository.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIbrary.Models
{
    public class TimeLapse : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string BookId { get; set; }
        public virtual Book Book { get; set; } = new Book();
    }
}
