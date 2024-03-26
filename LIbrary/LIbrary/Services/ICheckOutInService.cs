namespace LIbrary.Services
{
    public interface ICheckOutInService
    {
        public Task BorrowBook(string bookId);
        public Task ReturnBook(string borrowId);
        public Task ConfirmReturnBook(string borrowId);
    }
}
