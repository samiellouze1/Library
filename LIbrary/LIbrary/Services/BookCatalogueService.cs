using LIbrary.Models;
using LIbrary.Repository;
namespace LIbrary.Services
{
    public class BookCatalogueService : IBookCatalogueService
    {
        private readonly IBookRepository _bookRepository;
        public BookCatalogueService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ICollection<Book>> GetAllBooksAsync()
        {
            try
            {
                ICollection<Book> books = await _bookRepository.GetAllAsync();
                return books;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Book> GetBookByIdAsync(string id)
        {
            try
            {
                Book book = await _bookRepository.GetByIdAsync(id);
                return book;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Task<ICollection<Book>> GetBooksByReaderIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
