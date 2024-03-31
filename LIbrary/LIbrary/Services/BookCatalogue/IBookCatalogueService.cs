using LIbrary.Models;

namespace LIbrary.Services.BookCatalogue
{
    public interface IBookCatalogueService
    {
        public Task<Book> GetBookByIdAsync(string id);
        public Task<Book> GetAvailableBooksByIdAsync(string id);
        public Task<List<Book>> GetAllBooksAsync();
        public Task<List<Book>> GetBooksByReaderIdAsync(string id);
        public Task<List<Book>> GetBorrowedBooksByReaderIdAsync(string id);
        public Task<List<Book>> GetReturnedBooksByReaderIdAsync(string id);
    }
}
