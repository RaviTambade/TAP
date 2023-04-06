using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;
public interface ICartRepository{

    List<Cart> GetAll();
    Cart Get(int id);
    //bool AddToCart(Item item);
    //bool RemoveFromCart(Item item);

}
