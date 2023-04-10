namespace HRService.Models;
public class Department
{
    public int DeptId{get;set;}
    public string? DeptName{get;set;}
    public string? Location{get;set;}
    
    public override string ToString()
    {
        return DeptId+" "+DeptName+" "+Location;
    }
}