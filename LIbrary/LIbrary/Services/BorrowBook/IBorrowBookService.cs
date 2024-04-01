namespace LIbrary.Services.ReturnBook
{
    public interface IBorrowBookService
    {
        public Task BorrowBooks(string readerId, List<string> bookCopyIds);
        public Task ReturnBook( string borrowItemId);
        public Task ConfirmReturnBook(string librarianId, string borrowItemId);
    }
}
