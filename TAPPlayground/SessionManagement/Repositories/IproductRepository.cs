using SessionManagement.Models;

namespace SessionManagement.Repositories;
public interface IproductRepository{

    List<Product> GetAllProducts();

    Product GetProductById(int id);

}