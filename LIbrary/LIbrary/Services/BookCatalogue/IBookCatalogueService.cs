using LIbrary.Models;

namespace LIbrary.Services.BookCatalogue
{
    public interface IBookCatalogueService
    {
        public Task<Book> GetBookByIdAsync(string bookId);
        public Task<List<Book>> GetAllBooksAsync();
        public Task<bool> IsAvailableNow( string bookId);
    }
}
