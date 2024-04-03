using LIbrary.Models;
using LIbrary.Repository.Specific;
using LIbrary.ViewModels.BookVM;

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
            ICollection<Book> books = await _bookRepository.GetAllAsync( b=>b.bookCopies,b => b.author, b => b.genre) ;
            return books.ToList();
        }

        public async Task<Book> GetBookByIdAsync(string bookId)
        {
            Book book = await _bookRepository.GetByIdAsync(bookId,b=>b.bookCopies, b => b.author, b => b.genre);
            return book;
        }

        public async Task<bool> IsAvailableNow(string bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId,b=>b.bookCopies);
            var bookCopies = book.bookCopies;
            foreach (var bookCopy in bookCopies)
            {
                var bookCopyFull = await _bookCopyRepository.GetByIdAsync(bookCopy.Id, bc => bc.borrowItems);
                var testThisCopy = true;
                foreach (var borrowItem in bookCopyFull.borrowItems)
                {
                    var borrowItemFull = await _borrowItemRepository.GetByIdAsync(borrowItem.Id,bi=>bi.borrowItemStatus);
                    if (borrowItemFull.borrowItemStatus.name == "Borrowed") 
                    {
                        testThisCopy = false;
                        break;
                    }
                }
                if (testThisCopy) 
                { 
                    return true; 
                }
            }
            return false;
        }
    }
}
