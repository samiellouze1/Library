using LIbrary.Models;

namespace LIbrary.Services.BookCatalogue
{
    public interface IBookCatalogueService
    {
        public Task<Book> GetBookByIdAsync(string id);
        public Task<ICollection<Book>> GetAllBooksAsync();
        public Task<ICollection<Book>> GetBooksByReaderIdAsync(string id);
    }
}
