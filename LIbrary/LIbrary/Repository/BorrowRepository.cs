using LIbrary.Data;
using LIbrary.Models;
using LIbrary.Repository.Generic;

namespace LIbrary.Repository
{
    public class BorrowItemRepository : EntityBaseRepository<BorrowItem>, IBorrowItemRepository
    {
        public BorrowItemRepository(AppDbContext context) : base(context)
        {

        }
    }
}
