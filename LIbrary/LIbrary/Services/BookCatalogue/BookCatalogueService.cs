using LIbrary.Models;
using LIbrary.Repository.Specific;
namespace LIbrary.Services.BookCatalogue
{
    public class BookCatalogueService : IBookCatalogueService
    {
        private readonly IBookRepository _bookRepository;
        //private readonly IBookCopyRepository _bookCopyRepository;
        //private readonly IBorrowRepository _borrowRepository;
        private readonly IBorrowItemRepository _borrowItemRepository;
        public BookCatalogueService(IBookRepository bookRepository,IBorrowItemRepository borrowItemRepository)
        {
            _bookRepository = bookRepository;
            _borrowItemRepository = borrowItemRepository;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            try
            {
                ICollection<Book> books = await _bookRepository.GetAllAsync(b=>b.author);
                return books.ToList();
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Task<List<Book>> GetBooksByReaderIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Book>> GetCurrentlyBorrowedBooksByReaderIdAsync(string id)
        {
            ICollection<BorrowItem> borrowItems = await _borrowItemRepository.GetAllAsync(bi=>bi.borrow.reader,bi=>bi.bookCopy.book,bi=>bi.borrowItemStatus);
            List<BorrowItem> borrowedBorrowItems = borrowItems.Where(bi => bi.borrowItemStatus.name == "Borrowed").ToList();
            List<Book> borrowedBooks = borrowedBorrowItems.Select(bi=>bi.bookCopy.book).ToList();
            return borrowedBooks;
        }
    }
}
