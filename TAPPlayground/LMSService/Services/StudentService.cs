using StudentService.Models;
using StudentService.Repositories.Interfaces;
using StudentService.Services.Interface;
using StudentService.Models;
using StudentService.Repositories.Interfaces;
using StudentService.Services.Interface;
namespace StudentService.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repo;

    public StudentService(IStudentRepository repo)
    {
        _repo = repo;
    }

    public List<Student> GetAll() => _repo.GetAll();


    public Student GetById(int id)
    {
        return _repo.GetById(id);
    }

   public bool Insert(Student student)
    {
        return _repo.Insert(Student);
    }

   public bool Update(Student student)
    {
        return _repo.Update(Student);
    }
   public bool Delete(int id)
    {
        return _repo.Delete(id);
    }
}
