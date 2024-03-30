using LIbrary.Repository.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIbrary.Models
{
    public class ShoppingCartItem:IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string bookCopyId { get; set; }
        public virtual BookCopy BookCopy { get; set; }
        public string readerId { get; set; }
        public virtual Reader reader { get; set; }
    }
}
