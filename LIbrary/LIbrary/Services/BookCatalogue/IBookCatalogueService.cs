using LIbrary.Models;

namespace LIbrary.Services.BookCatalogue
{
    public interface IBookCatalogueService
    {
        public Task<Book> GetBookByIdAsync(string id);
        public Task<List<Book>> GetAllBooksAsync();
    }
}
