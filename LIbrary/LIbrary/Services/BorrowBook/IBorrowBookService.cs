using LIbrary.Models;

namespace LIbrary.Services.ReturnBook
{
    public interface IBorrowBookService
    {
        public Task BorrowBookCopy(string readerId,string bookCopyId);
    }
}
