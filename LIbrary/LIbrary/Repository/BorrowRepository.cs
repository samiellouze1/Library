using LIbrary.Data;
using LIbrary.Models;
using LIbrary.Repository.Generic;

namespace LIbrary.Repository
{
    public class BorrowRepository : EntityBaseRepository<Borrow>, IBorrowRepository
    {
        public BorrowRepository(AppDbContext context) : base(context)
        {

        }
    }
}
