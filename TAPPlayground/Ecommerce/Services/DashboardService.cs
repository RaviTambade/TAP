using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;
public class DashboardService:IDashboardService{

    private  readonly IDashboardRepository _repo;

    public DashboardService(IDashboardRepository repo)
    {
        _repo = repo;
    }

    public List<object> GetProductsData(List<Product> products) => _repo.GetProductsData(products);
}
