using LIbrary.Models;
using LIbrary.Repository.Specific;
using LIbrary.ViewModels.BookVM;

namespace LIbrary.Services.BookCatalogue
{
    public class BookCatalogueService : IBookCatalogueService
    {
        private readonly IBookRepository _bookRepository;
        public BookCatalogueService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<List<Book>> GetAllBooksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
