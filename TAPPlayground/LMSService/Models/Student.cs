
namespace LMSService.Models;

public class Student{
    public int StudentId{get;set;}
    public string StudentName{get;set;}
    public int Class{get;set;}
    public string Sex{get;set;}
    public string Email{get;set;}
    public DateTime DateOfBirth{get;set;}
    public string PhoneNo{get;set;}
    public Student(){
        
    }
}
