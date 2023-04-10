using System;
using LMSService.Models;

public interface IStudentRepository{
    public List<Student> GetAll();
    Student GetById(int id);

    bool Insert(Student student);
    bool Update(Student student);
    bool Delete(int id);

}