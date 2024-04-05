
using LIbrary.Models;
using LIbrary.Repository.Specific;

namespace LIbrary.Services.ReturnBook
{

    public class BorrowBookService : IBorrowBookService
    {
        private readonly IReaderRepository _readerRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IBorrowItemStatusRepository _borrowItemStatusRepository;
        private readonly IBorrowItemRepository _borrowItemRepository;

        public BorrowBookService(IReaderRepository readerRepository, IBookRepository bookRepository, IBorrowItemStatusRepository borrowItemStatusRepository, IBorrowItemRepository borrowItemRepository)
        {
            _readerRepository = readerRepository;
            _bookRepository = bookRepository;
            _borrowItemStatusRepository = borrowItemStatusRepository;
            _borrowItemRepository = borrowItemRepository;
        }

        public async Task BorrowBook(string readerId, string bookId)
        {
            Reader reader = await _readerRepository.GetByIdAsync(readerId);
            Book book = await _bookRepository.GetEagerBookByIdAsync(bookId);
            BookCopy bookCopy = book.bookCopies.FirstOrDefault(bc => !bc.borrowItems.Any(bi => bi.borrowItemStatusId == "1"));
            if (bookCopy == null)
            {
                throw new Exception();
            }
            else
            {
                var BorrowedborrowItemStatus = await _borrowItemStatusRepository.GetByIdAsync("1");
                BorrowItem borrowItem = new BorrowItem() { bookCopy = bookCopy, reader = reader, borrowItemStatus = BorrowedborrowItemStatus };
                await _borrowItemRepository.AddAsync(borrowItem);
            }
        }
    }
}
