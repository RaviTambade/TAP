using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;
public interface ICartRepository{

    List<Cart> GetAllCarts();
    Cart GetCart(int id);
    bool AddItem(Cart cart, Item item);
    bool UpdateItem(Cart cart, Item item);
    bool RemoveItem(Cart cart, Item item);

    bool CreateOrder(int cartId);


}
