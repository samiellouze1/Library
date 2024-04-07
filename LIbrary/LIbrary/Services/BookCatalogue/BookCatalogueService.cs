using LIbrary.Models;
using LIbrary.Repository.Specific;

namespace LIbrary.Services.BookCatalogue
{
    public class BookCatalogueService : IBookCatalogueService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookCopyRepository _bookCopyRepository;
        private readonly IBorrowItemRepository _borrowItemRepository;
        private readonly IReaderRepository _readerRepository;
        public BookCatalogueService(IBookRepository bookRepository, IBookCopyRepository bookCopyRepository, IBorrowItemRepository borrowItemRepository, IReaderRepository readerRepository)
        {
            _bookRepository = bookRepository;
            _bookCopyRepository = bookCopyRepository;
            _borrowItemRepository = borrowItemRepository;
            _readerRepository = readerRepository;
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

        public bool IsAlreadyBorrowed(Book book,string readerId)
        {
            var readerIds = book.bookCopies
                .SelectMany(bc => bc.borrowItems)
                .Where(bi => bi.borrowItemStatusId == "1")
                .Select(bi => bi.readerId)
                .ToList();
            return readerIds.Contains(readerId);
        }
        public async Task<List<Book>> GetBorrowedBooksByReaderIdAsync(string id)
        {
            var reader = await _readerRepository.GetEagerReaderByIdAsync(id);
            var books = reader.borrowItems
                .Where(bi => bi.borrowItemStatusId == "1")
                .Select(r => r.bookCopy)
                .Select(bc => bc.book);
            return books.ToList();
        }

        public async Task<List<Book>> GetHistoryBooksByReaderIdAsync(string id)
        {
            var reader = await _readerRepository.GetEagerReaderByIdAsync(id);
            var books = reader.borrowItems
                .Select(r => r.bookCopy)
                .Select(bc => bc.book);
            return books.ToList();
        }

        public async Task<List<Book>> GetReturnedBooksByReaderIdAsync(string id)
        {
            var reader = await _readerRepository.GetEagerReaderByIdAsync(id);
            var books = reader.borrowItems
                .Where(bi => bi.borrowItemStatusId == "2")
                .Select(r => r.bookCopy)
                .Select(bc => bc.book);
            return books.ToList();
        }
    }
}
