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
        public async Task<List<Book>> GetAllBooksAsync()
        {
            ICollection<Book> allBooks = await _bookRepository.GetAllAsync(
                b=>b.author,
                b=>b.genre,
                b=>b.bookCopies.Select(bc => bc.bookCopyStatus),
                b=>b.bookCopies.Select(bc=>bc.borrowItems.Select(bi=>bi.reader)));
            return allBooks.ToList();
        }

        public async Task<List<Book>> GetAvailableBooksAsync()
        {
            ICollection<Book> allBooks = await _bookRepository.GetAllAsync(
                b => b.author,
                b => b.genre,
                b => b.bookCopies.Select(bc => bc.bookCopyStatus),
                b => b.bookCopies.Select(bc => bc.borrowItems.Select(bi => bi.reader)));
            List<Book> selectedBooks = new List<Book>();
            foreach (var book in allBooks)
            {
                foreach (var bookCopy in book.bookCopies)
                {
                    if (bookCopy.bookCopyStatus.name == "Available")
                    {
                        selectedBooks.Add(book);
                        break;
                    }
                }
            }
            return selectedBooks;
        }

        public async Task<Book> GetBookByIdAsync(string id)
        {
            Book book = await _bookRepository.GetByIdAsync(id,
                b => b.author,
                b => b.genre,
                b => b.bookCopies.Select(bc => bc.bookCopyStatus),
                b => b.bookCopies.Select(bc => bc.borrowItems.Select(bi => bi.reader)));
            return book;
        }
    }
}
