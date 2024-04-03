using LIbrary.Services.ReturnBook;
using Microsoft.AspNetCore.Mvc;

namespace LIbrary.Controllers
{
    public class BorrowBookController : Controller
    {
        private readonly IBorrowBookService _borrowBookService;
        public BorrowBookController(IBorrowBookService borrowBookService)
        {
            _borrowBookService= borrowBookService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
