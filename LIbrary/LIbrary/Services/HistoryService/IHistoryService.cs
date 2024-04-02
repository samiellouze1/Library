using LIbrary.Models;

namespace LIbrary.Services.HistoryService
{
    public interface IHistoryService
    {
        public Task<List<Book>> GetBorrowedBooksByReaderIdAsync(string id);
        public Task<List<Book>> GetReturnedBooksByReaderIdAsync(string id);
    }
}
