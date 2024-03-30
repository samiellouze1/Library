using LIbrary.Repository.Generic;
using System.ComponentModel.DataAnnotations;

namespace LIbrary.Models
{
    public class ShoppingCartItem:IEntityBase
    {
        [Key]
        public string Id { get; set; }
        public string bookCopyId { get; set; }
        public virtual BookCopy BookCopy { get; set; }
        public string readerId { get; set; }
        public virtual Reader reader { get; set; }
    }
}
