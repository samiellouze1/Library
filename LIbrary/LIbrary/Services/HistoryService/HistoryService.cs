using LIbrary.Models;
using LIbrary.Repository.Specific;

namespace LIbrary.Services.HistoryService
{
    public class HistoryService : IHistoryService
    {
        private readonly IReaderRepository _readerRepository;

        public HistoryService(IReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
        }

        public async Task<List<Book>> GetBorrowedBooksByReaderIdAsync(string id)
        {
            var reader = await _readerRepository.GetEagerReaderByIdAsync(id);
            var books = reader.borrowItems.Where(bi => bi.borrowItemStatusId == "1").Select(r => r.bookCopy).Select(bc => bc.book);
            return books.ToList();
        }

        public async Task<List<Book>> GetHistoryBooksByReaderIdAsync(string id)
        {
            var reader = await _readerRepository.GetEagerReaderByIdAsync(id);
            var books = reader.borrowItems.Select(r => r.bookCopy).Select(bc=>bc.book);
            return books.ToList();
        }

        public async Task<List<Book>> GetReturnedBooksByReaderIdAsync(string id)
        {
            var reader = await _readerRepository.GetEagerReaderByIdAsync(id);
            var books = reader.borrowItems.Where(bi=>bi.borrowItemStatusId=="2").Select(r => r.bookCopy).Select(bc => bc.book);
            return books.ToList();
        }
    }
}
