using LIbrary.Services.ShoppingCart;
using Microsoft.AspNetCore.Mvc;

namespace LIbrary.Controllers
{
    public class CartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        public CartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
