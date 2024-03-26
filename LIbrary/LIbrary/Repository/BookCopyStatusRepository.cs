using LIbrary.Data;
using LIbrary.Models;
using LIbrary.Repository.Generic;

namespace LIbrary.Repository
{
    public class BookCopyStatusRepository : EntityBaseRepository<BookCopyStatus>, IBookCopyStatusRepository
    {
        public BookCopyStatusRepository(AppDbContext context) : base(context)
        {

        }
    }
}
