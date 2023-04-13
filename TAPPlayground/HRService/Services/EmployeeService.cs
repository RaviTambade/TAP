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
    public async Task<List<Employee>> GetAll(){
        var employees = _repo.GetAll();
        Console.WriteLine("service");
        return await employees;
    } 
    public List<Employee> GetEmployeesByDepartmentId(int deptId)=>_repo.GetEmployeesByDepartmentId(deptId);
    public async Task<Employee> GetById(int empId)=>await _repo.GetById(empId);
    public async Task<bool> Insert (Employee employee) =>await _repo.Insert(employee);
    public async Task<bool> Update(Employee emp)=>await _repo.Update(emp);
    public async Task <bool> Delete(int id)=>await _repo.Delete(id);

}



//Departments Table
//deptId pk
//name
//location


//Employees
//deptId foreign key