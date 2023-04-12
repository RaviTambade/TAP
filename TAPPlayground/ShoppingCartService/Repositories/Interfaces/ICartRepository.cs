using ShoppingCartService.Models;

namespace ShoppingCartService.Repositories.Interfaces;
public interface ICartRepository{

    Task<List<Cart>> GetAllCarts();
    Task <Cart> GetCart(int id);
    Task <bool> AddItem(Cart cart, Item item);
    Task <bool> UpdateItem(Cart cart, Item item);
    Task <bool> RemoveItem(Cart cart, Item item);
    Task <bool> CreateOrder(int cartId);


}
