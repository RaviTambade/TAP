using System.Collections;
using System.Net.Http.Headers;
using CatalogService.Models;
namespace CatalogService.Repositories.Interfaces;
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetById(int productId);
    bool Insert(Product product);
    bool Update(Product product);
    bool Delete(int ProductId);
    bool HikePrice(double percentage);
}