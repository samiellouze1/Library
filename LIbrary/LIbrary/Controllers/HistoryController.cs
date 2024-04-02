using LIbrary.Services.HistoryService;
using Microsoft.AspNetCore.Mvc;

namespace LIbrary.Controllers
{
    public class HistoryController:Controller
    {
        private readonly IHistoryService _historyService;
        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }
        public async Task<IActionResult> MyBooks(string searchString)
        {
            return View();
        }
        public async Task<IActionResult> MyBorrowedBooks(string searchString)
        {
            return View();
        }
        public async Task<IActionResult> MyReturnedBooks(string searchString)
        {
            return View();
        }
    }
}
