using LIbrary.Models;
using LIbrary.Repository.Specific;

namespace LIbrary.Services.ShoppingCart
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;
        public ShoppingCartService(IShoppingCartItemRepository shoppingCartItemRepository)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
        }

        public async Task<ICollection<ShoppingCartItem>> GetShoppingCartItemsAsync()
        {
            ICollection<ShoppingCartItem> shoppingCartItems = await _shoppingCartItemRepository.GetAllAsync(s => s.BookCopy);
            return shoppingCartItems;
        }
    }
}
