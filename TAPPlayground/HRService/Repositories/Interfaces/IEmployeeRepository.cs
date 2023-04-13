using HRService.Models;
namespace HRService.Repositories.Interfaces;
public interface IEmployeeRepository
{
    Task<List<Employee>> GetAll();
    Task<Employee> GetById(int empId);
    List<Employee> GetEmployeesByDepartmentId(int deptId);
    Task<bool> Insert(Employee emp);
    Task<bool> Update(Employee emp);
    Task<bool> Delete(int empId);
}