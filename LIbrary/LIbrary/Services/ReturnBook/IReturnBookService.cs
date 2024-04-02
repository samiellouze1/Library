namespace LIbrary.Services.ReturnBook
{
    public interface IReturnBookService
    {
        public Task ReturnBookCopy(string readerId, string borrowItemId, string review, int rating);
        public Task ConfirmReturnBookCopy(string librarianId, string borrowItemId);
    }
}
