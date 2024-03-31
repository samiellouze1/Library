﻿using LIbrary.Models;
using LIbrary.Services.BookCatalogue;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LIbrary.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookCatalogueService _bookCatalogueService;
        public BookController(IBookCatalogueService bookCatalogueService)
        {
             _bookCatalogueService = bookCatalogueService;
        }
        public async Task<IActionResult> BookDetail(string id)
        {
            Book book = await _bookCatalogueService.GetBookByIdAsync(id);
            // i need to develop some decoupling
            // i need to take care of it if it returns a null
            return View(book);
        }
        public async Task<IActionResult> Index(string searchString)
        {
            ICollection<Book> books = await _bookCatalogueService.GetAllBooksAsync();
            List<Book> booksList=books.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                booksList = booksList.Where(n => n.title.Contains(searchString)).ToList();
            }
                // i need to develop some decoupling
                // i need to take care of it if it returns a null
                return View(booksList) ;
        }
        //[Authorize("Reader")]
        public async Task<IActionResult> CurrentlyBorrowedBooks()
        {
            string Id;
            try
            {
                Id = User.FindFirstValue("Id");
            }
            catch (Exception ex) 
            {
                return RedirectToAction("Error", "Home");
            }
            ICollection<Book> books = await _bookCatalogueService.GetBorrowedBooksByReaderIdAsync(Id);
            return View("Index", books);
        }    
        public async Task<IActionResult> ReturnedBooks()
        {
            string Id;
            try
            {
                Id = User.FindFirstValue("Id");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
            ICollection<Book> books = await _bookCatalogueService.GetReturnedBooksByReaderIdAsync(Id);
            return View("Index", books);
        }
        //public async Task<IActionResult> MyBorrowedBooks()
        //{
        //    string Id = User.FindFirstValue("Id");
        //    ICollection<Book> books = await _bookCatalogueService.GetBorrowedBooksByReaderIdAsync(Id);
        //    return View("Books", books);
        //}
        //public async Task<IActionResult> MyReturnedBooks()
        //{
        //    string Id = User.FindFirstValue("Id");
        //    ICollection<Book> books = await _bookCatalogueService.GetReturnedBooksByReaderIdAsync(Id);
        //    return View("Books", books);
        //}
    }
}
