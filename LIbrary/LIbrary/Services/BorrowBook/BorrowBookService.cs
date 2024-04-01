
using LIbrary.Models;
using LIbrary.Repository.Specific;

namespace LIbrary.Services.ReturnBook
{
    public class BorrowBookService : IBorrowBookService
    {
        private readonly IBorrowItemRepository _borrowItemRepository;
        private readonly IBorrowItemStatusRepository _borrowItemStatusRepository;
        private readonly IBookCopyStatusRepository _bookCopyStatusRepository;
        private readonly IBookCopyRepository _bookCopyRepository;
        private readonly ILibrarianRepository _librarianRepository;
        private readonly IReaderRepository _readerRepository;
        private readonly IBorrowRepository _borrowRepository;
        public BorrowBookService(IBorrowItemRepository borrowItemRepository,
            IBorrowItemStatusRepository borrowItemStatusRepository,
            IBookCopyStatusRepository bookCopyStatusRepository,
            IBookCopyRepository bookCopyRepository,
            ILibrarianRepository librarianRepository,
            IReaderRepository readerRepository,
            IBorrowRepository borrowRepository)
        {
            _borrowItemStatusRepository = borrowItemStatusRepository;
            _borrowItemRepository = borrowItemRepository;
            _bookCopyStatusRepository = bookCopyStatusRepository;
            _bookCopyRepository = bookCopyRepository;
            _librarianRepository = librarianRepository;
            _readerRepository = readerRepository;
            _borrowRepository = borrowRepository;
        }

        public async Task BorrowBooks(string readerId, List<string> bookCopyIds)
        {
            Reader reader = await _readerRepository.GetByIdAsync(readerId);
            Borrow borrow = new Borrow();
            await _borrowRepository.AddAsync(borrow);
            BorrowItemStatus borrowedBorrowItemStatus = await _borrowItemStatusRepository.GetByIdAsync("1");
            BookCopyStatus unavailableBookCopyStatus = await _bookCopyStatusRepository.GetByIdAsync("2");
            foreach (string bookCopyId in bookCopyIds)
            {
                BookCopy bookCopy = await _bookCopyRepository.GetByIdAsync(bookCopyId);
                bookCopy.bookCopyStatus = unavailableBookCopyStatus;
                await _bookCopyRepository.UpdateAsync(bookCopyId,bookCopy);
                BorrowItem borrowItem= new BorrowItem() { bookCopy=bookCopy,borrowItemStatus=borrowedBorrowItemStatus};
                await _borrowItemRepository.AddAsync(borrowItem);
                borrow.borrowItems.Add(borrowItem);
            }
            await _borrowRepository.AddAsync(borrow);
        }

        public async Task ConfirmReturnBook(string librarianId, string borrowItemId)
        {
            BorrowItem borrowItem = await _borrowItemRepository.GetByIdAsync(borrowItemId,bi=>bi.bookCopy.bookCopyStatus);
            if (borrowItem == null)
            {
                throw new Exception("Borrow Item not found");
            }
            else
            {
                try
                {
                    borrowItem.bookCopy.bookCopyStatus = await _bookCopyStatusRepository.GetByIdAsync("1");
                    await _bookCopyRepository.UpdateAsync(borrowItem.bookCopyId, borrowItem.bookCopy);
                    borrowItem.borrowItemStatus = await _borrowItemStatusRepository.GetByIdAsync("2");
                    borrowItem.librarian= await _librarianRepository.GetByIdAsync(librarianId);
                    await _borrowItemRepository.UpdateAsync(borrowItemId, borrowItem);
                }
                catch (Exception ex)
                {
                    throw new Exception("There has been an error");
                }
            }
        }

        public async Task ReturnBook( string borrowItemId)
        {
            BorrowItem borrowItem = await _borrowItemRepository.GetByIdAsync(borrowItemId,bi=>bi.bookCopy);
            BookCopy bookCopy = borrowItem.bookCopy;
            bookCopy.bookCopyStatus = await _bookCopyStatusRepository.GetByIdAsync("3");
            await _bookCopyRepository.UpdateAsync(bookCopy.Id, bookCopy);
            //lezemeni gestion des erreurs
        }
    }
}
