using HRService.Models;
using HRService.Repositories.Interfaces;
using HRService.Services.Interfaces;

namespace HRService.Services;
public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repo;
    public EmployeeService(IEmployeeRepository repo)
    {
        _repo = repo;
    }
    public List<Employee> GetAll() => _repo.GetAll();
    public Employee GetById(int empId)=> _repo.GetById(empId);
    public bool Insert (Employee employee) => _repo.Insert(employee);
    public bool Update(Employee emp)=> _repo.Update(emp);
    public bool Delete(int id)=>_repo.Delete(id);
}



//Departments Table
//deptId pk
//name
//location


//Employees
//deptId foreign key