using System.Net.Http.Headers;
using ECommerceApp.Models;
namespace ECommerceApp.Repositories.Interfaces;
public interface IProductRepository{
    List<Product> GetAll();
    Product GetById(int productId);
    bool Insert(Product product);
    bool Update(Product product);
    bool Delete(int ProductId);
}