
using LIbrary.Models;
using LIbrary.Repository.Specific;
using LIbrary.ViewModels.ReturnBook;

namespace LIbrary.Services.ReturnBook
{
    public class ReturnBookService : IReturnBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBorrowItemStatusRepository _borrowItemStatusRepository;
        private readonly IBorrowItemRepository _borrowItemRepository;

        public ReturnBookService(IBookRepository bookRepository, IBorrowItemStatusRepository borrowItemStatusRepository, IBorrowItemRepository borrowItemRepository)
        {
            _bookRepository = bookRepository;
            _borrowItemStatusRepository = borrowItemStatusRepository;
            _borrowItemRepository = borrowItemRepository;
        }

        public async Task ReturnBook(ReturnBookVM returnBookVM, string readerId)
        {
            var book = await _bookRepository.GetEagerBookByIdAsync(returnBookVM.bookReadVM.Id);
            var borrowItems = book.bookCopies.SelectMany(bc => bc.borrowItems).Where(bi => bi.borrowItemStatusId == "2");
            var borrowItem = borrowItems.FirstOrDefault(bi=>bi.readerId==readerId);
            if (borrowItem != null)
            {
                var returnDate = DateTime.Now;
                var returnedBorrowItemStatus = await _borrowItemStatusRepository.GetByIdAsync("2");
                borrowItem.endDate = returnDate;
                borrowItem.borrowItemStatus=returnedBorrowItemStatus;
                borrowItem.reviewRating = returnBookVM.reviewRating;
                await _borrowItemRepository.UpdateAsync(borrowItem.Id, borrowItem);
            }
            else
            {
                throw new Exception("You didn't borrow this book");
            }
        }
    }
}
