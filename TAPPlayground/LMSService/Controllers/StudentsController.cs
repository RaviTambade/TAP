using Microsoft.AspNetCore.Mvc;
using MySql.Data;
using MySql.Data.MySqlClient;
using LMSService.Models;
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
      students=_studentSrv.GetAll();
      return students; 
    }

    [Route("/api/students/GetStudentDetails/{id}")]
    public  Student GetById(int id)
    { 
      Student student=_studentSrv.GetById();
      return student; 
    }


    [HttpPut]
     [Route("/api/students/update/{id}")]
    public  IActionResult UpdateStudentDetails(Student studentToUpdate)
    {   
        Console.WriteLine("student update is invoked");    
        return NoContent();
    }


    [HttpPost]
    [Route("/api/students/insert/")]
    public IActionResult Insert(Student studentToUpdate)
    {   
        Console.WriteLine("student insert is invoked");          
        return NoContent();
    }


    [HttpDelete]
    [Route("/api/students/delete/{id}")]
    public IActionResult RemoveStudent(int id)
    {
        Console.WriteLine("student delete is invoked"); 
        return NoContent();
    }



    
}
