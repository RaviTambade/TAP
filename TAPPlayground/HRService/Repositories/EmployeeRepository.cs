using HRService.Models;
using HRService.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;         
namespace HRService.Repositories;
public class EmployeeRepository : IEmployeeRepository
{
  private IConfiguration _configuration;
  private string _conString;

  public EmployeeRepository(IConfiguration configuration){
      _configuration= configuration;
      _conString=this._configuration.GetConnectionString("DefaultConnection");
    }

  public async Task<List<Employee>> GetAll(){
        await Task.Delay(3000);
        List<Employee> Employees=new List<Employee>();
        MySqlConnection connection=new MySqlConnection(_conString);
        try{
            MySqlCommand command=new MySqlCommand();
            command.CommandText="SELECT * FROM employees";
            command.Connection= connection;
            await connection.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                 int id = Int32.Parse(reader["employee_id"].ToString());
                string firstname = reader["empfirst_name"].ToString();
                string lastname = reader["emplast_name"].ToString();
                DateTime birthdate = Convert.ToDateTime(reader["birth_date"].ToString());
                DateTime hiredate = Convert.ToDateTime(reader["hire_date"].ToString());
                string contact=reader["contact_number"].ToString();
                string email = reader["email"].ToString();
                string password = reader["password"].ToString();
                string photo =reader["photo"].ToString();
                int reportsTo =Int32.Parse(reader["reports_to"].ToString());
                long accountNo = long.Parse(reader["account_number"].ToString());
                int deptid = Int32.Parse(reader["dept_id"].ToString());

               Employee employee = new Employee
                {
                    EmpId=id,
                    EmpFirstName=firstname,
                    EmpLastName=lastname,
                    BirthDate=birthdate,
                    HireDate=hiredate,
                    ContactNumber=contact,
                    Email=email,
                    Password=password,
                    Photo=photo,
                    ReportsTo=reportsTo,
                    AccountNumber=accountNo,
                    DeptId = deptid
                   
                };
                Employees.Add(employee);
            }
            reader.Close();
        }
        catch(Exception e){
            throw e;
        }
        finally{
            connection.Close();
        }
      return Employees; 
    }
    public List<Employee> GetEmployeesByDepartmentId(int deptId){
      List<Employee> Employees=new List<Employee>();
        MySqlConnection connection=new MySqlConnection(_conString);
        try{
            MySqlCommand command=new MySqlCommand();
            //set parameterized query using @
            command.CommandText="SELECT * FROM employees WHERE dept_id=@deptId";
            command.Connection= connection;
            command.Parameters.AddWithValue("@deptId",deptId);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = Int32.Parse(reader["employee_id"].ToString());
                string firstname = reader["empfirst_name"].ToString();
                string lastname = reader["emplast_name"].ToString();
                DateTime birthdate =  Convert.ToDateTime(reader["birth_date"].ToString());
                DateTime hiredate = Convert.ToDateTime(reader["hire_date"].ToString());
                string contact=reader["contact_number"].ToString();
                string email = reader["email"].ToString();
                string password = reader["password"].ToString();
                string photo =reader["photo"].ToString();
                int reportsTo =Int32.Parse(reader["reports_to"].ToString());
                long accountNo = long.Parse(reader["account_number"].ToString());
                int deptid = Int32.Parse(reader["dept_id"].ToString());

               Employee employee = new Employee
                {
                    EmpId=id,
                    EmpFirstName=firstname,
                    EmpLastName=lastname,
                    BirthDate=birthdate,
                    HireDate=hiredate,
                    ContactNumber=contact,
                    Email=email,
                    Password=password,
                    Photo=photo,
                    ReportsTo=reportsTo,
                    AccountNumber=accountNo,
                    DeptId = deptid
                   
                };
                Employees.Add(employee);
            }
        }
        catch(Exception e){
            throw e;
        }
        finally{
            connection.Close();
        }
      return Employees;

    }
   public async Task<Employee> GetById(int empId)
   {
          Employee employee =new Employee();
          MySqlConnection connection=new MySqlConnection(_conString);
          try{
              MySqlCommand command=new MySqlCommand();
              command.CommandText="SELECT * FROM employees where employee_id=@employeeId";
              command.Connection=connection;
              command.Parameters.AddWithValue("@employeeId",empId);
              await connection.OpenAsync();
              MySqlDataReader reader = command.ExecuteReader();
              if (reader.Read())
              {
                int id = Int32.Parse(reader["employee_id"].ToString());
                string firstname = reader["empfirst_name"].ToString();
                string lastname = reader["emplast_name"].ToString();
                DateTime birthdate = Convert.ToDateTime(reader["birth_date"].ToString());
                DateTime hiredate = Convert.ToDateTime(reader["hire_date"].ToString());
                string contact=reader["contact_number"].ToString();
                string email = reader["email"].ToString();
                string password = reader["password"].ToString();
                string photo =reader["photo"].ToString();
                int reportsTo =Int32.Parse(reader["reports_to"].ToString());
                long accountNo = long.Parse(reader["account_number"].ToString());
                int deptid = Int32.Parse(reader["dept_id"].ToString());
                employee = new Employee
                  {
                    EmpId=id, 
                    EmpFirstName=firstname,
                    EmpLastName=lastname,
                    BirthDate=birthdate,
                    HireDate=hiredate,
                    ContactNumber=contact,
                    Email=email,
                    Password=password,
                    Photo=photo,
                    ReportsTo=reportsTo,
                    AccountNumber=accountNo,
                    DeptId=deptid                     
                  };
              }
              reader.Close();
          }
          catch(Exception e){
              throw e;
          }
          finally{
              connection.Close();
          }
          return employee;
   }
   public  async Task<bool> Insert(Employee emp)
   {    
          bool status = false;
          MySqlConnection con = new MySqlConnection();
          con.ConnectionString=_conString;
          try{
              string query =$"INSERT INTO employees(empfirst_name,emplast_name,birth_date,hire_date,contact_number,email,password,photo,reports_to,account_number,dept_id)VALUES"+
                                                  "(@EmpFirstName,@EmpLastName,@BirthDate,@HireDate,@ContactNumber,@Email,@Password,@Photo,@ReportsTo,@AccountNumber,@DeptId)";
             Console.WriteLine(query);
             await con.OpenAsync();
             MySqlCommand command=new MySqlCommand(query,con) ;
             command.Parameters.AddWithValue("@EmpFirstName",emp.EmpFirstName);             
             command.Parameters.AddWithValue("@EmpLastName",emp.EmpLastName);
             command.Parameters.AddWithValue("@BirthDate",emp.BirthDate);
             command.Parameters.AddWithValue("@HireDate",emp.HireDate);
             command.Parameters.AddWithValue("@ContactNumber",emp.ContactNumber);
             command.Parameters.AddWithValue("@Email",emp.Email);
             command.Parameters.AddWithValue("@Password",emp.Password);
             command.Parameters.AddWithValue("@Photo",emp.Photo);
             command.Parameters.AddWithValue("@ReportsTo",emp.ReportsTo);
             command.Parameters.AddWithValue("@AccountNumber",emp.AccountNumber);
             command.Parameters.AddWithValue("@DeptId",emp.DeptId);
             await command.ExecuteNonQueryAsync(); 
             status=true;              

          }catch(Exception e )
          {
            throw e;
          }
          finally {
               con.Close();
          } 
          return status;
   }
   public async Task<bool> Update(Employee emp){       
          Console.WriteLine(emp);
          bool status=false;
          MySqlConnection con = new MySqlConnection();
          con.ConnectionString=_conString;
          try{
            string query = "UPDATE employees SET empfirst_name=@EmpFirstName, emplast_name=@EmpLastName, birth_date=@BirthDate, hire_date=@HireDate, contact_number=@ContactNumber, email=@Email, password=@Password, photo=@Photo, reports_to=@ReportsTo, account_number=@AccountNumber, dept_id=@DeptId WHERE employee_id=@EmployeeId";   
             Console.WriteLine(query);
             await con.OpenAsync();
             MySqlCommand command=new MySqlCommand(query,con) ;
              command.Parameters.AddWithValue("@EmployeeId",emp.EmpId); 
             command.Parameters.AddWithValue("@EmpFirstName",emp.EmpFirstName);             
             command.Parameters.AddWithValue("@EmpLastName",emp.EmpLastName);
             command.Parameters.AddWithValue("@BirthDate",emp.BirthDate);
             command.Parameters.AddWithValue("@HireDate",emp.HireDate);
             command.Parameters.AddWithValue("@ContactNumber",emp.ContactNumber);
             command.Parameters.AddWithValue("@Email",emp.Email);
             command.Parameters.AddWithValue("@Password",emp.Password.ToString());
             command.Parameters.AddWithValue("@Photo",emp.Photo);
             command.Parameters.AddWithValue("@ReportsTo",emp.ReportsTo);
             command.Parameters.AddWithValue("@AccountNumber",emp.AccountNumber);
             command.Parameters.AddWithValue("@DeptId",emp.DeptId);
             await command.ExecuteNonQueryAsync();               
             status=true;
          }catch(Exception e )
          {
            throw e;
          }
          finally {
            con.Close();
          }
          return status;
   }
   public async Task<bool> Delete(int empId){
          bool status = false;
          MySqlConnection con = new MySqlConnection();
          con.ConnectionString=_conString;
          try{
            string query = "DELETE FROM employees WHERE employee_id=@employeeId";
             MySqlCommand command=new MySqlCommand(query,con) ;
            command.Parameters.AddWithValue("@employeeId",empId);
             con.Open();
             command.ExecuteNonQuery();              
             status = true;
          }catch(Exception e )
          {
            throw e;
          }
          finally {
            con.Close();
          }
          return status;
   }
}