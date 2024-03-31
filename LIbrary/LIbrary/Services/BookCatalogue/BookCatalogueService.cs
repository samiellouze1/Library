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

        public Task<Book> GetAvailableBooksByIdAsync(string id)
        {
            throw new NotImplementedException();
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

        public async Task<List<Book>> GetBooksByReaderIdAsync(string id)
        {
            ICollection<BorrowItem> borrowItems = await _borrowItemRepository.GetAllAsync(bi => bi.borrow.reader, bi => bi.bookCopy.book, bi => bi.borrowItemStatus);
            borrowItems = borrowItems
                .Where(bi => bi.borrow.readerId == id)
                .ToList();
            List<Book> books= borrowItems
                .Select(bi => bi.bookCopy.book)
                .ToList();
            return books;
        }

        public async Task<List<Book>> GetBorrowedBooksByReaderIdAsync(string id)
        {
            ICollection<BorrowItem> borrowItems = await _borrowItemRepository.GetAllAsync(bi=>bi.borrow.reader,bi=>bi.bookCopy.book,bi=>bi.borrowItemStatus);
            List<BorrowItem> borrowedBorrowItems = borrowItems
                .Where(bi=>bi.borrow.readerId==id)
                .Where(bi => bi.borrowItemStatus.name == "Borrowed")
                .ToList();
            List<Book> borrowedBooks = borrowedBorrowItems.Select(bi=>bi.bookCopy.book).ToList();
            return borrowedBooks;
        }

        public async Task<List<Book>> GetReturnedBooksByReaderIdAsync(string id)
        {
            ICollection<BorrowItem> borrowItems = await _borrowItemRepository.GetAllAsync(bi => bi.borrow.reader, bi => bi.bookCopy.book, bi => bi.borrowItemStatus);
            List<BorrowItem> borrowedBorrowItems = borrowItems
                .Where(bi => bi.borrow.readerId == id)
                .Where(bi => bi.borrowItemStatus.name == "Returned")
                .ToList();
            List<Book> borrowedBooks = borrowedBorrowItems.Select(bi => bi.bookCopy.book).ToList();
            return borrowedBooks;
        }

    }
}
