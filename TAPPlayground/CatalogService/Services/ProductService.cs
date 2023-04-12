using System.Collections;
using System.Threading.Tasks;
using CatalogService.Models;
using CatalogService.Repositories.Interfaces;
using CatalogService.Services.Interfaces;
namespace CatalogService.Services;
public class ProductService : IProductService
{
    private readonly IProductRepository _repo;
    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }
    public async Task<IEnumerable<Product>> GetAll(){
         var products= _repo.GetAll();
         Console.WriteLine("service");
         return await products;
    }
    public async Task<Product> GetById(int productId) =>await  _repo.GetById(productId);
    public bool Insert(Product product) => _repo.Insert(product);
    public bool Update(Product product) => _repo.Update(product);
    public bool Delete(int productId) => _repo.Delete(productId);
    public bool HikePrice(double percentage) => _repo.HikePrice(percentage);
}