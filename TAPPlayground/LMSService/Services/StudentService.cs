using LMSService.Models;
using LMSService.Services.Interfaces;
using LMSService.Repositories.Interfaces;

namespace LMSService.Services;

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
        return _repo.Insert(student);
    }

   public bool Update(Student student)
    {
        return _repo.Update(student);
    }
   public bool Delete(int id)
    {
        return _repo.Delete(id);
    }
}
