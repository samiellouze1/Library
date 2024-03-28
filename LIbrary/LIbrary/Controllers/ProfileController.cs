using LIbrary.ViewModels.Reader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LIbrary.Controllers
{
    public class ProfileController: Controller
    {
        public async Task<IActionResult> MyProfile()
        {
            // you need to implement it all
            string Id = User.FindFirstValue("Id");

            return View();
        }
        //[Authorize("Librarian")]
        public async Task<IActionResult> AllReaders()
        {
            // you need to implement it all
            return View();
        }
        public async Task<IActionResult> ReaderMiniProfilePartial()
        {
            // need to implement some logic
            ReaderReadVM readerReadVM = new ReaderReadVM();
            return ViewComponent("ReaderMiniProfile", readerReadVM);
        }
    }
}
