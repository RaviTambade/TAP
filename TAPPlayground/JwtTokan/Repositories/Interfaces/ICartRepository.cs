using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;
public interface ICartRepository{

    List<Cart> GetAll();
    Cart Get(int id);
    bool AddToCart(Cart cart);
    //bool RemoveFromCart(Item item);
    bool Update(Cart cart);

}
