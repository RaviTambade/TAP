

using SessionManagement.Models;
using SessionManagement.Repositories;
using SessionManagement.Services;


namespace SessionManagement.Services;

public class ProductService : IproductService
{

private readonly IproductRepository _repo;

    public ProductService(IproductRepository repo)
    {
        _repo = repo;
    }

    public List<Product> GetAllProducts()
    {
       return _repo.GetAllProducts();
    }

    public Product GetProductById(int id)
    {
        return _repo.GetProductById(id);
    }
}