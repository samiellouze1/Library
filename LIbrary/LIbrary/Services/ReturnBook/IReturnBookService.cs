namespace LIbrary.Services.ReturnBook
{
    public interface IReturnBookService
    {
        public Task ReturnBook( string borrowItemId);
        public Task ConfirmReturnBook(string librarianId, string borrowItemId);
    }
}
