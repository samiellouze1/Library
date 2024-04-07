
using LIbrary.Models;
using LIbrary.Repository.Specific;
using LIbrary.ViewModels.BorrowBook;


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

        public async Task BorrowBook(BorrowBookVM borrowBookVM, string readerId )
        {
            Reader reader = await _readerRepository.GetByIdAsync(readerId);
            Book book = await _bookRepository.GetEagerBookByIdAsync(borrowBookVM.bookReadVM.Id);
            BookCopy bookCopy = book.bookCopies.FirstOrDefault(bc => !bc.borrowItems
                                                                            .Any(bi => bi.borrowItemStatusId == "1"));
            if (bookCopy == null)
            {
                throw new Exception();
            }
            else
            {
                var BorrowedborrowItemStatus = await _borrowItemStatusRepository.GetByIdAsync("1");
                BorrowItem borrowItem = new BorrowItem() 
                { 
                    bookCopy = bookCopy,
                    reader = reader,
                    borrowItemStatus = BorrowedborrowItemStatus,
                    supposedEndDate=borrowBookVM.endDate,
                    startDate=borrowBookVM.startDate 
                };
                await _borrowItemRepository.AddAsync(borrowItem);
            }
        }
    }
}
