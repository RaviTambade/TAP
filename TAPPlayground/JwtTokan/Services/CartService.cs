using System.Diagnostics.CodeAnalysis;
using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;
public class CartService:ICartService{
    private readonly ICartRepository _repo;
    public CartService(ICartRepository repo){
        this._repo=repo;
    }

    public List<Cart> GetAllCarts(){
      return _repo.GetAllCarts();
     }
    public Cart GetCart(int id)
    {
        return _repo.GetCart(id);
    }
    public bool AddItem(Cart cart, Item item)
    {
        return _repo.AddItem(cart,item);
    }
    

    public bool UpdateItem(Cart cart, Item item)
    {
        return _repo.UpdateItem(cart,item);
    }
    public bool RemoveItem(Cart cart, Item item)
    {
        return _repo.RemoveItem(cart,item);
    }

    public bool CreateOrder(int cartId){
       return _repo.CreateOrder(cartId);
    }

}

    
