

using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;
    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }
    public List<Product> GetAll() => _repo.GetAll();
    public Product GetById(int productId) => _repo.GetById(productId);
    public bool Insert(Product product) => _repo.Insert(product);
    public bool Update(Product product) => _repo.Update(product);
    public bool Delete(int productId) => _repo.Delete(productId);
}