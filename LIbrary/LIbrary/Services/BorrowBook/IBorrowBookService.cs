using LIbrary.Models;

namespace LIbrary.Services.ReturnBook
{
    public interface IBorrowBookService
    {
        public Task BorrowBook(string readerId,string bookId);    
    }
}
