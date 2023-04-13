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
    public async Task<IEnumerable<Category>> GetAll() =>await _repo.GetAll();
    public async Task<Category> GetDetails(int categoryId) =>await _repo.GetDetails(categoryId);
    public async Task<bool> Insert(Category category) =>await _repo.Insert(category);
    public async Task<bool> Update(Category category) =>await _repo.Update(category);
    public async Task<bool> Delete(int categoryId) =>await _repo.Delete(categoryId);
}