using CatalogService.Models;
using CatalogService.Repositories.Interfaces;
using CatalogService.Services.Interfaces;

namespace CatalogService.Services;
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repo;
    public CategoryService(ICategoryRepository repo)
    {
        this._repo = repo;
    }
    public List<Category> GetAll() => _repo.GetAll();
    public Category GetDetails(int categoryId) => _repo.GetDetails(categoryId);
    public bool Insert(Category category) => _repo.Insert(category);
    public bool Update(Category category) => _repo.Update(category);
    public bool Delete(int categoryId) => _repo.Delete(categoryId);
}