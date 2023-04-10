using HRService.Models;
using HRService.Repositories.Interfaces;
using HRService.Services.Interfaces;

namespace HRService.Services;
public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _repo;
    public DepartmentService(IDepartmentRepository repo)
    {
        _repo = repo;
    }
    public List<Department> GetAll() => _repo.GetAll();
    public Department GetById(int deptId)=> _repo.GetById(deptId);
    public bool Insert (Department department) => _repo.Insert(department);
    public bool Update(Department dept)=> _repo.Update(dept);
    public bool Delete(int id)=>_repo.Delete(id);
}



//Departments Table
//deptId pk
//name
//location


//Employees
//deptId foreign key