

using SessionManagement.Models;
using SessionManagement.Repositories;
using SessionManagement.Services;


namespace SessionManagement.Services;

public class ProductService : IProductService
{

private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
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

    public List<Product> GetProductsDetails()
    {
       return _repo.GetProductsDetails();
    }
}