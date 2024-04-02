using LIbrary.Services.ReturnBook;
using Microsoft.AspNetCore.Mvc;

namespace LIbrary.Controllers
{
    public class BorrowBookController : Controller
    {
        private readonly IBorrowBookService _returnBookService;
        public BorrowBookController(IBorrowBookService returnBookService)
        {
            _returnBookService = returnBookService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ReturnBook(string bookId)
        {
            return View();
        }
    }
}
