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
        public async Task<IActionResult> ReturnBook(string borrowItemId)
        {
            return View();
        }
        public async Task<IActionResult> ConfirmReturnBook(string borrowItemId)
        {
            return View();
        }
    }
}
