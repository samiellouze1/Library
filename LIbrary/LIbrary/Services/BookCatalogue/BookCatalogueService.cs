using LIbrary.Models;
using LIbrary.Repository.Specific;

namespace LIbrary.Services.BookCatalogue
{
    public class BookCatalogueService : IBookCatalogueService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookCopyRepository _bookCopyRepository;
        private readonly IBorrowItemRepository _borrowItemRepository;
        public BookCatalogueService(IBookRepository bookRepository, IBookCopyRepository bookCopyRepository, IBorrowItemRepository borrowItemRepository)
        {
            _bookRepository = bookRepository;
            _bookCopyRepository = bookCopyRepository;
            _borrowItemRepository = borrowItemRepository;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllEagerBooksAsync();
            return books.ToList();
        }

        public async Task<Book> GetBookByIdAsync(string bookId)
        {
            var book = await _bookRepository.GetEagerBookByIdAsync(bookId);
            return book;
        }
    }
}
