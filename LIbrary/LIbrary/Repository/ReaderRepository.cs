using LIbrary.Data;
using LIbrary.Models;
using LIbrary.Repository.Generic;

namespace LIbrary.Repository
{
    public class ReaderRepository : EntityBaseRepository<Reader>, IReaderRepository
    {
        public ReaderRepository(AppDbContext context) : base(context)
        {

        }
    }
}
