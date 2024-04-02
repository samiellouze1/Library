using AutoMapper;
using LIbrary.Models;
using LIbrary.Services.BookCatalogue;
using LIbrary.ViewModels.BookVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LIbrary.Controllers
{
    public class BookCatalogueController : Controller
    {
        private readonly IBookCatalogueService _bookCatalogueService;
        private readonly IMapper _mapper;
        public BookCatalogueController(IBookCatalogueService bookCatalogueService, IMapper mapper)
        {
            _bookCatalogueService = bookCatalogueService;
            _mapper = mapper;
        }
        public async Task<IActionResult> AllBooks(string searchString)
        {
            return View();
        }

        public async Task<IActionResult> AvailableBooks(string searchString)
        {
            return View();
        }
        public async Task<IActionResult> Book(string bookId)
        {
            return View();
        }
    }
}
