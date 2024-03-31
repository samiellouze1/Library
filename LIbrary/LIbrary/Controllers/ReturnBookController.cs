using LIbrary.Services.ReturnBook;
using Microsoft.AspNetCore.Mvc;

namespace LIbrary.Controllers
{
    public class ReturnBookController : Controller
    {
        private readonly IReturnBookService _returnBookService;
        public ReturnBookController(IReturnBookService returnBookService)
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
