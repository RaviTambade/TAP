namespace ECommerceApp.Models;

public class Employees
{
    public int EmpId{get;set;}
    public string? EmpFirstName{get;set;}
    public string? EmpLastName{get;set;}
    public DateTime BirthDate{get;set;}
    public DateTime HireDate{get;set;}
    public string? ContactNumber{get;set;}
    public string? Email{get;set;}
    public string? Password{get;set;}
    public string? Photo{get;set;}
    public int ReportsTo{get;set;}
    public long AccountNumber{get;set;}

}