
using LIbrary.Models;
using LIbrary.Repository.Specific;

namespace LIbrary.Services.ReturnBook
{
    public class BorrowBookService : IBorrowBookService
    {
        public Task BorrowBookCopy(string readerId, string bookCopyId)
        {
            throw new NotImplementedException();
        }
        public Task<List<Book>> GetBorrowedBooksByReaderIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
