using SessionManagement.Models;

namespace SessionManagement.Repositories;
public interface IProductRepository{

    List<Product> GetAllProducts();

    Product GetProductById(int id);

   //List<Product> GetProductsDetails();

  // bool UpdateProduct(Product product);
}