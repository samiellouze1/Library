using LIbrary.Models;

namespace LIbrary.Services.ReturnBook
{
    public interface IBorrowBookService
    {
        public Task BorrowBookCopy(string readerId,string bookCopyId);
        public Task<bool> IsAlreadyBorrowed(string readerId, string bookId);

    }
}
