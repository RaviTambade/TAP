using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;
public class CartService:ICartService{
    private readonly ICartRepository _repo;
    public CartService(ICartRepository repo){
        this._repo=repo;
    }

    public List<Cart> GetAll(){
      return _repo.GetAll();
     }
    public Cart Get(int id)
    {
        return _repo.Get(id);
    }
}

    
