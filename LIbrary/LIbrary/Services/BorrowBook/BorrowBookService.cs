
using LIbrary.Models;
using LIbrary.Repository.Specific;

namespace LIbrary.Services.ReturnBook
{

    public class BorrowBookService : IBorrowBookService
    {
        private readonly IReaderRepository _readerRepository;
        private readonly IBookRepository _bookRepository;

        public BorrowBookService(IReaderRepository readerRepository, IBookRepository bookRepository)
        {
            _readerRepository = readerRepository;
            _bookRepository = bookRepository;
        }

        public Task BorrowBookCopy(string readerId, string bookCopyId)
        {
            throw new NotImplementedException();
        }
        public Task<List<Book>> GetBorrowedBooksByReaderIdAsync(string id)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> IsAlreadyBorrowed(string readerId, string bookId)
        {
            Reader reader = await _readerRepository.GetByIdAsync(readerId, r => r.borrowItems);
            Book book = await _bookRepository.GetByIdAsync(bookId,b=>b.bookCopies);
            var readerBookCopyIds = reader.borrowItems.Where(bi => bi.borrowItemStatusId == "1").Select(bi => bi.bookCopyId).ToList() ;
            var bookBookCopyIds = book.bookCopies.Select(bc=>bc.Id).ToList() ;
            return readerBookCopyIds.Intersect(readerBookCopyIds).Any();
        }
    }
}
