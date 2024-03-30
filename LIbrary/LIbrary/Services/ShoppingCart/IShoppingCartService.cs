using LIbrary.Models;

namespace LIbrary.Services.ShoppingCart
{
    public interface IShoppingCartService
    {
        public Task<List<ShoppingCartItem>> GetShoppingCartItemsByReaderIdAsync(string readerId);
        //total price
        public Task AddItemToShoppingCartByReaderIdAsync(string readerId,string bookCopyId);
        public Task RemoveItemFromShoppingCartByReaderIdAsync(string readerId,string bookCopyId);
    }
}
