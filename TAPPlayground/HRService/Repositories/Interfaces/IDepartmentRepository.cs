using HRService.Models;
namespace HRService.Repositories.Interfaces;
public interface IDepartmentRepository
{
    List<Department> GetAll();
    Department GetById(int deptId);
    bool Insert(Department dept);
    bool Update(Department dept);
    bool Delete(int deptId);
}