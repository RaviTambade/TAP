using ShoppingCartService.Models;
using ShoppingCartService.Repositories.Interfaces;
using ShoppingCartService.Services.Interfaces;

namespace ShoppingCartService.Services;
public class CartService : ICartService
{
    private readonly ICartRepository _repo;
    public CartService(ICartRepository repo)
    {
        this._repo = repo;
    }

    public async Task<List<Cart>> GetAllCarts()
    {
        return await _repo.GetAllCarts();
    }
    public async Task<Cart> GetCart(int id)
    {
        return await _repo.GetCart(id);
    }
    public async Task<bool> AddItem(int cartId, Item item)
    {
        return await _repo.AddItem(cartId, item);
    }
    public async Task<bool> UpdateItem(int cartId, Item item)
    {
        return await _repo.UpdateItem(cartId, item);
    }
    public async Task<bool> RemoveItem(int cartId, Item item)
    {
        return await _repo.RemoveItem(cartId, item);
    }
    public async Task<bool> CreateOrder(int cartId)
    {
        return await _repo.CreateOrder(cartId);
    }
}