using LIbrary.Data;
using LIbrary.Models;
using LIbrary.Repository.Generic;

namespace LIbrary.Repository.Specific
{
    public class LibrarianRepository : EntityBaseRepository<Librarian>, ILibrarianRepository
    {
        public LibrarianRepository(AppDbContext context) : base(context)
        {

        }
    }
}
