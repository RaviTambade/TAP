using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;
public interface ICartRepository{

    Cart Get(int sessionId);
    bool AddToCart(Item item);
    bool RemoveFromCart(Item item);

}
