using System.Diagnostics.CodeAnalysis;
using ShoppingCartService.Models;
using ShoppingCartService.Repositories.Interfaces;
using ShoppingCartService.Services.Interfaces;

namespace ShoppingCartService.Services;
public class CartService:ICartService{
    private readonly ICartRepository _repo;
    public CartService(ICartRepository repo){
        this._repo=repo;
    }

    public async Task<List<Cart>> GetAllCarts(){
      return await _repo.GetAllCarts();
     }
    public async Task<Cart> GetCart(int id)
    {
        return await _repo.GetCart(id);
    }
    public async Task<bool> AddItem(Cart cart, Item item)
    {
        return await _repo.AddItem(cart,item);
    }
    

    public async Task<bool> UpdateItem(Cart cart, Item item)
    {
        return await _repo.UpdateItem(cart,item);
    }
    public async Task<bool> RemoveItem(Cart cart, Item item)
    {
        return await _repo.RemoveItem(cart,item);
    }

    public async Task<bool> CreateOrder(int cartId){
       return await _repo.CreateOrder(cartId);
    }

}

    
