using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;
public interface IDashboardRepository
{
   //  List<object> GetProductsData(List<Product> products);

   List<RevenueModel> GetProductsData();

}