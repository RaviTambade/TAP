using HRService.Models;
namespace HRService.Repositories.Interfaces;
public interface IDepartmentRepository
{
    Task<List<Department>> GetAll();
    Task<Department> GetById(int deptId);
    Task<bool> Insert(Department dept);
    Task<bool> Update(Department dept);
    Task<bool> Delete(int deptId);
}