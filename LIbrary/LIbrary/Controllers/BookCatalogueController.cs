using AutoMapper;
using LIbrary.Models;
using LIbrary.Repository.Specific;
using LIbrary.Services.BookCatalogue;
using LIbrary.Services.ReturnBook;
using LIbrary.ViewModels.BookCatalogue;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LIbrary.Controllers
{
    public class BookCatalogueController : Controller
    {
        private readonly IBookCatalogueService _bookCatalogueService;
        private readonly IBookRepository _bookRepository;
        private readonly IBorrowBookService _borrowBookService;
        private readonly IMapper _mapper;
        public BookCatalogueController(IBookCatalogueService bookCatalogueService, IMapper mapper, IBorrowBookService borrowBookService, IBookRepository bookRepository)
        {
            _bookCatalogueService = bookCatalogueService;
            _mapper = mapper;
            _borrowBookService = borrowBookService;
            _bookRepository = bookRepository;
        }
        public async Task<IActionResult> Books(string searchString)
        {
            string Id = User.FindFirstValue("Id");
            var books = await _bookCatalogueService.GetAllBooksAsync();
            var bookReadVms = new List<BookReadVM>();
            foreach (Book book in books)
            {
                if (book.Id=="2")
                {
                    Console.WriteLine("Hello");
                }
                var readerIds = book.bookCopies.SelectMany(bc => bc.borrowItems).Where(bi => bi.borrowItemStatusId == "1").Select(bi => bi.readerId).ToList();
                var isAlreadyBorrowed = readerIds.Contains(Id);
                var bookReadVm = _mapper.Map<BookReadVM>(book);
                bookReadVm.isAlreadyBorrowed=isAlreadyBorrowed;
                bookReadVms.Add(bookReadVm);
            }
            return View(bookReadVms);
        }
        public async Task<IActionResult> Book(string bookId)
        {
            return View();
        }
    }
}
