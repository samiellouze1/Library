using AutoMapper;
using LIbrary.Models;
using LIbrary.Services.BookCatalogue;
using LIbrary.Services.ReturnBook;
using LIbrary.ViewModels.BookVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace LIbrary.Controllers
{
    public class BookCatalogueController : Controller
    {
        private readonly IBookCatalogueService _bookCatalogueService;
        private readonly IBorrowBookService _borrowBookService;
        private readonly IMapper _mapper;
        public BookCatalogueController(IBookCatalogueService bookCatalogueService, IMapper mapper, IBorrowBookService borrowBookService)
        {
            _bookCatalogueService = bookCatalogueService;
            _mapper = mapper;
            _borrowBookService = borrowBookService;
        }
        public async Task<IActionResult> Books(string searchString)
        {
            List<Book> books = await _bookCatalogueService.GetAllBooksAsync();
            List<BookReadVM> bookReadVMs = _mapper.Map<List<BookReadVM>>(books);
            string Id = User.FindFirstValue("Id");
            foreach (var bookRead in bookReadVMs) 
            {
                if (!Id.IsNullOrEmpty())
                {
                    bookRead.isAlreadyBorrowed = await _borrowBookService.IsAlreadyBorrowed(Id,bookRead.Id);
                }
                bookRead.isAvailableNow= await _bookCatalogueService.IsAvailableNow(bookRead.Id);
                Console.WriteLine(bookRead);
            }
            return View(bookReadVMs);
        }
        public async Task<IActionResult> Book(string bookId)
        {
            return View();
        }
    }
}
