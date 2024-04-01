using LIbrary.Models;
using LIbrary.Services.ShoppingCart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LIbrary.Controllers
{
    public class CartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        public CartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }
        [Authorize(Roles ="Reader")]
        public async Task<IActionResult> Index()
        {
            string Id = User.FindFirstValue("Id");
            List<ShoppingCartItem> shoppingCartItems = await _shoppingCartService.GetShoppingCartItemsByReaderIdAsync(Id);
            return View(shoppingCartItems);
        }
        [Authorize(Roles ="Reader")]
        public async Task<IActionResult> CheckOut()
        {
            string Id = User.FindFirstValue("Id");
            List<ShoppingCartItem> shoppingCartItems = await _shoppingCartService.GetShoppingCartItemsByReaderIdAsync(Id);
            return View(shoppingCartItems);
        }
    }
}
