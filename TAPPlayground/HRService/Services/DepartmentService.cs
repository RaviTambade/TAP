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
    public async Task< List<Department>> GetAll(){
        var departments = _repo.GetAll();
        return await departments;
    } 

    public async Task<Department> GetById(int deptId)=>await _repo.GetById(deptId);
    public async Task<bool> Insert (Department department) =>await  _repo.Insert(department);
    public async Task<bool> Update(Department dept)=>await _repo.Update(dept);
    public async Task<bool> Delete(int id)=>await _repo.Delete(id);
}



