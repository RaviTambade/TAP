using ShoppingCartService.Models;

namespace ShoppingCartService.Repositories.Interfaces;
public interface ICartRepository
{
    Task<List<Cart>> GetAllCarts();
    Task<Cart> GetCart(int id);
    Task<bool> AddItem(int cartId, Item item);
    Task<bool> UpdateItem(int cartId, Item item);
    Task<bool> RemoveItem(int cartId, Item item);
    Task<bool> CreateOrder(int cartId);
}
