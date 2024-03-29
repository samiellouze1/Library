using LIbrary.Models;

namespace LIbrary.Services.ShoppingCart
{
    public interface IShoppingCartService
    {
        public Task<ICollection<ShoppingCartItem>> GetShoppingCartItemsAsync();
        //total price
    }
}
