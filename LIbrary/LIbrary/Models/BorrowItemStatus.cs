using LIbrary.Repository.Generic;
using System.ComponentModel.DataAnnotations;

namespace LIbrary.Models
{
    public class BorrowItemStatus: IEntityBase
    {
        [Key]
        public string Id { get; set; }
        public string name {  get; set; }
        public virtual ICollection<BorrowItem> borrowItems { get; set; }
    }
}
