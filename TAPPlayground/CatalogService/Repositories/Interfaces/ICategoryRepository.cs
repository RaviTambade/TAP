using CatalogService.Models;
namespace CatalogService.Repositories.Interfaces;
public interface ICategoryRepository
{
    List<Category> GetAll();
    Category GetDetails(int categoryId);
    bool Insert(Category category);
    bool Update(Category category);
    bool Delete(int categoryId);
}
