using Newtonsoft.Json;
using HRService.Models;

class Program{

    private static readonly HttpClient client=new HttpClient();
    static async Task Main(string[] args)
    {
        await FetchEmployeesFromRESTAPI();
        await FetchEmployeeDetails();
        await InsertEmployee();
    }



    private static async Task FetchEmployeesFromRESTAPI()
    {
        //consume Rest aapi
        List<Employee> employees = new List<Employee>();
        //access data from rest api using asynchronous
        using (var httpClient = new HttpClient())
        {
           using (var response =await httpClient.GetAsync("http://localhost:5259/api/employees/GetAllEmployees"))
           {
            string apiResponse = await response.Content.ReadAsStringAsync();

            employees = JsonConvert.DeserializeObject<List<Employee>>(apiResponse);
            
            foreach(var employee in employees)
            Console.WriteLine(employee.EmpId+" "+employee.EmpFirstName+" "+employee.EmpLastName+" "+employee.BirthDate+" "+employee.HireDate+" "+employee.ContactNumber+" "+employee.Email+" "+employee.Password+" "+employee.Photo+" "+employee.ReportsTo+" "+employee.AccountNumber+" "+employee.DeptId);
           }
        }
    }

    private static async Task FetchEmployeeDetails()
    {
        Console.WriteLine("Enter The Employee Id:");
        int empId = Convert.ToInt32(Console.ReadLine());
        Employee employee = new Employee();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5259/api/employees/GetEmployeeDetails/"+empId))
            {
                  string apiResponse = await response.Content.ReadAsStringAsync();
                  employee = JsonConvert.DeserializeObject<Employee>(apiResponse);
                  Console.WriteLine(employee.EmpId+" "+employee.EmpFirstName+" "+employee.EmpLastName+" "+employee.BirthDate+" "+employee.HireDate+" "+employee.ContactNumber+" "+employee.Email+" "+employee.Password+" "+employee.Photo+" "+employee.ReportsTo+" "+employee.AccountNumber+" "+employee.DeptId);            
            }
        }
    }


    private static async Task InsertEmployee()
    {
        Console.WriteLine("Insert new Employee =>");
        Console.WriteLine("Enter Employee First Name:");
        string empFirstName = Console.ReadLine();

        Console.WriteLine("Enter Employee Last Name:");
        string empLastName = Console.ReadLine();


    }

    
}