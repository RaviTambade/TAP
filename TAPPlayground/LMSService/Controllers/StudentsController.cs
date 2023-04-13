using Microsoft.AspNetCore.Mvc;
using MySql.Data;
using MySql.Data.MySqlClient;
using LMSService.Models;
using LMSService.Services.Interfaces;
using LMSService.Services;

namespace LMSService.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class StudentsController : ControllerBase
{
    public string  constring="server=localhost;port=3306;user=root;password=99224226;database=school";
    private readonly ILogger<StudentsController> _logger;
     private readonly IStudentService _studentSrv;
    public StudentsController(ILogger<StudentsController> logger, IStudentService srv)
    {
        _logger = logger;
        _studentSrv=srv;
    }

   [Route("/api/students/GetAllStudents")]
    public IEnumerable<Student> GetAll()
    { 
      List<Student> students=new List<Student>();
     // students=_studentSrv.GetAll();
      _logger.LogInformation("Get All method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
      return students; 
    }

    [Route("/api/students/GetStudentDetails/{id}")]
    public  Student GetById(int id)
    { 

      Student student=_studentSrv.GetById(id);
      _logger.LogInformation("Get By ID method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
      return student; 
    }


    [HttpPut]
     [Route("/api/students/update/{id}")]
    public  IActionResult UpdateStudentDetails(Student studentToUpdate)
    {   
        _logger.LogInformation("student update is invoked");
       
        return NoContent();
    }


    [HttpPost]
    [Route("/api/students/insert/")]
    public IActionResult Insert(Student studentToUpdate)
    {   
        _logger.LogInformation("student data  is inserted");     
        return NoContent();
    }


    [HttpDelete]
    [Route("/api/students/delete/{id}")]
    public IActionResult RemoveStudent(int id)
    {
       _logger.LogInformation("student data  is deketed");     
        return NoContent();
    }



    
}
