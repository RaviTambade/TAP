using CatalogService.Models;
namespace CatalogService.Repositories.Interfaces;
public interface ICategoryRepository
{
     Task<IEnumerable<Category>> GetAll();
     Task<Category> GetDetails(int categoryId);
     Task<bool> Insert(Category category);
     Task<bool> Update(Category category);
     Task<bool> Delete(int categoryId);
}
