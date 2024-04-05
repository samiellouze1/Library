using LIbrary.Models;

namespace LIbrary.Services.HistoryService
{
    public class HistoryService : IHistoryService
    {
        public Task<List<Book>> GetBorrowedBooksByReaderIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetHistoryBooksByReaderIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetReturnedBooksByReaderIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
