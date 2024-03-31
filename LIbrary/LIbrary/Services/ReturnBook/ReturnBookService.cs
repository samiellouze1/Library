
using LIbrary.Models;
using LIbrary.Repository.Specific;

namespace LIbrary.Services.ReturnBook
{
    public class ReturnBookService : IReturnBookService
    {
        private readonly IBorrowItemRepository _borrowItemRepository;
        private readonly IBorrowItemStatusRepository _borrowItemStatusRepository;
        private readonly IBookCopyStatusRepository _bookCopyStatusRepository;
        private readonly IBookCopyRepository _bookCopyRepository;
        private readonly ILibrarianRepository _librarianRepository;
        //private readonly IBookCopyRepository _bookCopyRepository;
        public ReturnBookService(IBorrowItemRepository borrowItemRepository,
            IBorrowItemStatusRepository borrowItemStatusRepository,
            IBookCopyStatusRepository bookCopyStatusRepository,
            IBookCopyRepository bookCopyRepository,
            ILibrarianRepository librarianRepository)
        {
            _borrowItemStatusRepository = borrowItemStatusRepository;
            _borrowItemRepository = borrowItemRepository;
            _bookCopyStatusRepository = bookCopyStatusRepository;
            _bookCopyRepository = bookCopyRepository;
            _librarianRepository = librarianRepository;
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
