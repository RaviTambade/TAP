using System.Net.Http.Headers;
using ECommerceApp.Models;
namespace ECommerceApp.Repositories.Interfaces;
public interface IProductRepository{
    List<Product> GetAllProducts();

    Product GetProduct(int id);
}