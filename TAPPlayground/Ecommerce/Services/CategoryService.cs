using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;
public class CategoryService:ICategoryService{
    private readonly ICategoryRepository _repo;
    public CategoryService(ICategoryRepository repo){
        this._repo=repo;
    }

    public List<Category> GetAll()=> _repo.GetAll();
}