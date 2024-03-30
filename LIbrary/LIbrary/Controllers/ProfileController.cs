using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LIbrary.Controllers
{
    public class ProfileController: Controller
    {
        public async Task<IActionResult> Index()
        {
            // you need to implement it all
            string Id = User.FindFirstValue("Id");

            return View();
        }
        //[Authorize("Librarian")]
        public async Task<IActionResult> Readers()
        {
            // you need to implement it all
            return View();
        }
    }
}
