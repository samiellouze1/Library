using LIbrary.Models;
using LIbrary.Repository.Specific;

namespace LIbrary.Services.ShoppingCart
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;
        public ShoppingCartService(IShoppingCartItemRepository shoppingCartItemRepository, IReaderRepository readerRepository)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
        }

        public async Task AddItemToShoppingCartByReaderIdAsync(string readerId,string bookCopyId)
        {
            List<ShoppingCartItem> shoppingCartItems = await GetShoppingCartItemsByReaderIdAsync(readerId);
            bool bookCopyAlreadyInShoppingCart = shoppingCartItems.Select(sc => sc.bookCopyId).Contains(bookCopyId);
            if (!bookCopyAlreadyInShoppingCart)
            {
                ShoppingCartItem newShoppingCartItem = new ShoppingCartItem() { bookCopyId=bookCopyId,readerId=readerId };
                await _shoppingCartItemRepository.AddAsync(newShoppingCartItem);
            }
            else
            {
                throw new Exception("The book is already in your cart");
            }
        }
        public async Task<List<ShoppingCartItem>> GetShoppingCartItemsByReaderIdAsync(string readerId)
        {
            ICollection<ShoppingCartItem> shoppingCartItems = await _shoppingCartItemRepository.GetAllAsync();
            List<ShoppingCartItem> myShoppingCartItems = shoppingCartItems.Where(sci=>sci.readerId==readerId).ToList();
            return myShoppingCartItems;
        }

        public async Task RemoveItemFromShoppingCartByReaderIdAsync(string readerId, string bookCopyId)
        {
            ICollection<ShoppingCartItem> allShppingCartItems = await _shoppingCartItemRepository.GetAllAsync();
            ShoppingCartItem shoppingCartItem = allShppingCartItems.FirstOrDefault(sci => sci.readerId==readerId && sci.bookCopyId==bookCopyId);
            if (shoppingCartItem!= null)
            {
                await _shoppingCartItemRepository.DeleteAsync(shoppingCartItem.Id);
            }
            {
                throw new Exception("You tried to delete a non existant book from your cart");
            }
        }
    }
}
