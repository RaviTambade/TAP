using System;
using LMSService.Models;
namespace LMSService.Repositories.Interfaces;
public interface IStudentRepository{
    public List<Student> GetAll();
    Student GetById(int id);

    bool Insert(Student student);
    bool Update(Student student);
    bool Delete(int id);

}