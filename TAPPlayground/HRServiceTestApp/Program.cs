using Newtonsoft.Json;
using HRService.Models;
using System.Text;
using System.Text.Json;

class Program{

    private static readonly HttpClient client=new HttpClient();
    static async Task Main(string[] args)
    {
        //await FetchEmployeesFromRESTAPI();
        //await FetchEmployeeDetails();
        //await InsertEmployee();
        //await UpdateEmployee();
        //await DeleteEmployee();

///////////////////////////////////////////////////////////////////////////////////////////////////////////

        await FetchDepartmentsFromRESTAPI();
        //await FetchDepartmentDetails();
        //await InsertDepartment();
        //await UpdateDepartment();
        //await DeleteDepartment();

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

        Console.WriteLine("Enter Employee BirthDate:");
        DateTime empBirthDate =Convert.ToDateTime(Console.ReadLine());

        Console.WriteLine("Enter Employee Hire Date:");
        DateTime empHireDate =Convert.ToDateTime(Console.ReadLine());

        Console.WriteLine("Enter Employee Contact Number:");
        string empContactNumber = Console.ReadLine();

         Console.WriteLine("Enter Employee Email:");
        string empEmail = Console.ReadLine();

         Console.WriteLine("Enter Employee Password:");
        string empPassword = Console.ReadLine();

        Console.WriteLine("Enter Employee Photo:");
        string empPhoto = Console.ReadLine();

        Console.WriteLine("Enter Employee Reports To:");
        int empReportsTo = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Employee Account Number:");
        long empAccountNumber = long.Parse(Console.ReadLine());

        Console.WriteLine("Enter Employee DeptId:");
        int empDeptId = int.Parse(Console.ReadLine());

        Employee employee = new Employee()
        {
            EmpFirstName=empFirstName,
            EmpLastName=empLastName,
            BirthDate=empBirthDate,
            HireDate=empHireDate,
            ContactNumber=empContactNumber,
            Email=empEmail,
            Password=empPassword,
            Photo=empPhoto,
            ReportsTo=empReportsTo,
            AccountNumber=empAccountNumber,
            DeptId=empDeptId
        };
        string jsonEmployee = System.Text.Json.JsonSerializer.Serialize(employee);
        var requestContent = new StringContent(jsonEmployee,Encoding.UTF8,"application/json");
        using (var httpClient=new HttpClient())
        {
            string apiUrl="http://localhost:5259/api/employees/AddEmployee";
            using(var response = await httpClient.PostAsync(apiUrl,requestContent))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }
        }
        Console.WriteLine("Employee Added SuccessFully");

    }

    public static async Task UpdateEmployee()
    {
           Console.WriteLine("Enter Employee Id You Want to Update");
           int empId=int.Parse(Console.ReadLine());
           Employee employee = new Employee();
           using (var httpClient= new HttpClient())
           {
           using(var response = await httpClient.GetAsync("http://localhost:5259/api/employees/GetEmployeeDetails/" + empId))
            {
                  string apiResponse= await response.Content.ReadAsStringAsync();
                  employee  = JsonConvert.DeserializeObject<Employee>(apiResponse);   
            }
           }
        Console.WriteLine("Enter Employee First Name:");
        employee.EmpFirstName = Console.ReadLine();

        Console.WriteLine("Enter Employee Last Name:");
        employee.EmpLastName = Console.ReadLine();

        Console.WriteLine("Enter Employee BirthDate:");
        employee.BirthDate =Convert.ToDateTime(Console.ReadLine());

        Console.WriteLine("Enter Employee Hire Date:");
        employee.HireDate =Convert.ToDateTime(Console.ReadLine());

        Console.WriteLine("Enter Employee Contact Number:");
        employee.ContactNumber = Console.ReadLine();

         Console.WriteLine("Enter Employee Email:");
        employee.Email = Console.ReadLine();

         Console.WriteLine("Enter Employee Password:");
        employee.Password = Console.ReadLine();

        Console.WriteLine("Enter Employee Photo:");
        employee.Photo = Console.ReadLine();

        Console.WriteLine("Enter Employee Reports To:");
        employee.ReportsTo = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Employee Account Number:");
        employee.AccountNumber = long.Parse(Console.ReadLine());

        Console.WriteLine("Enter Employee DeptId:");
        employee.DeptId = int.Parse(Console.ReadLine());

        string jsonEmployee= System.Text.Json.JsonSerializer.Serialize(employee);
        var requestContent=new StringContent(jsonEmployee, Encoding.UTF8,"application/json");
        using (var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:5259/api/employees/update/"+employee.EmpId;
            using (var response = await httpClient.PutAsync(apiUrl,requestContent))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }
        }
    }


    private static async Task DeleteEmployee()
    {
        Console.WriteLine("Enter Employee Id :");
        int empId = int.Parse(Console.ReadLine());
        using(var httpClient= new HttpClient())
        {
            using(var response = await httpClient.DeleteAsync(" http://localhost:5259/api/employees/delete/"+empId))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }
        }
        Console.WriteLine("Employee Deleted Succefully");
    }


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


       private static async Task FetchDepartmentsFromRESTAPI()
    {
        //consume Rest aapi
        List<Department> departments = new List<Department>();
        //access data from rest api using asynchronous
        using (var httpClient = new HttpClient())
        {
           using (var response =await httpClient.GetAsync("http://localhost:5259/api/departments/getalldepartments"))
           {
            string apiResponse = await response.Content.ReadAsStringAsync();

            departments = JsonConvert.DeserializeObject<List<Department>>(apiResponse);
            
            foreach(var department in departments)
            Console.WriteLine(department.DeptId+" "+department.DeptName+" "+department.Location);
           }
        }
    }

       private static async Task FetchDepartmentDetails()
    {
        Console.WriteLine("Enter The Department Id:");
        int deptId = Convert.ToInt32(Console.ReadLine());
        Department department = new Department();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5259/api/departments/getdepartmentdetails/"+deptId))
            {
                  string apiResponse = await response.Content.ReadAsStringAsync();
                  department = JsonConvert.DeserializeObject<Department>(apiResponse);
                  Console.WriteLine(department.DeptId+" "+department.DeptName+" "+department.Location);            
            }
        }
    }


     private static async Task InsertDepartment()
    {
        Console.WriteLine("Insert new Department =>");
        Console.WriteLine("Enter Department Name:");
        string deptName = Console.ReadLine();

        Console.WriteLine("Enter Department Location :");
        string deptLocation = Console.ReadLine();

        Department department = new Department()
        {
            DeptName=deptName,
            Location=deptLocation
        };
        string jsonEmployee = System.Text.Json.JsonSerializer.Serialize(department);
        var requestContent = new StringContent(jsonEmployee,Encoding.UTF8,"application/json");
        using (var httpClient=new HttpClient())
        {
            string apiUrl="http://localhost:5259/api/departments/adddepartment";
            using(var response = await httpClient.PostAsync(apiUrl,requestContent))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }
        }
        Console.WriteLine("Department Added SuccessFully");

    }

    public static async Task UpdateDepartment()
    {
           Console.WriteLine("Enter Department Id You Want to Update");
           int deptId=int.Parse(Console.ReadLine());
           Department department = new Department();
           using (var httpClient= new HttpClient())
           {
           using(var response = await httpClient.GetAsync("http://localhost:5259/api/departments/getdepartmentdetails/" + deptId))
            {
                  string apiResponse= await response.Content.ReadAsStringAsync();
                  department  = JsonConvert.DeserializeObject<Department>(apiResponse);   
            }
           }
        Console.WriteLine("Enter Department Name:");
        department.DeptName = Console.ReadLine();

        Console.WriteLine("Enter Department Location:");
        department.Location = Console.ReadLine();


        string jsonDepartment= System.Text.Json.JsonSerializer.Serialize(department);
        var requestContent=new StringContent(jsonDepartment, Encoding.UTF8,"application/json");
        using (var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:5259/api/departments/update/"+department.DeptId;
            using (var response = await httpClient.PutAsync(apiUrl,requestContent))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }
        }
        Console.WriteLine("Departments Updated Succefully");
    }

      private static async Task DeleteDepartment()
    {
        Console.WriteLine("Enter Department Id :");
        int deptId = int.Parse(Console.ReadLine());
        using(var httpClient= new HttpClient())
        {
            using(var response = await httpClient.DeleteAsync(" http://localhost:5259/api/departments/delete/"+ deptId))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }
        }
        Console.WriteLine("Departments Deleted Succefully");
    }



}