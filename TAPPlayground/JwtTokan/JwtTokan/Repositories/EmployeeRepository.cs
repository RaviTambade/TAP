using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;         
namespace ECommerceApp.Repositories;
public class EmployeeRepository : IEmployeeRepository
{
  private IConfiguration _configuration;
  private string _conString;

  public EmployeeRepository(IConfiguration configuration){
      _configuration= configuration;
      _conString=this._configuration.GetConnectionString("DefaultConnection");
    }

  public List<Employee> GetAll(){
        List<Employee> Employees=new List<Employee>();
        MySqlConnection connection=new MySqlConnection(_conString);
        try{
            MySqlCommand command=new MySqlCommand();
            command.CommandText="SELECT * FROM employees";
            command.Connection= connection;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                 int id = Int32.Parse(reader["employee_id"].ToString());
                string firstname = reader["empfirst_name"].ToString();
                string lastname = reader["emplast_name"].ToString();
                DateTime birthdate =  DateTime.Parse(reader["birth_date"].ToString());
                DateTime hiredate =DateTime.Parse(reader["hire_date"].ToString());
                string contact=reader["contact_number"].ToString();
                string email = reader["email"].ToString();
                string password = reader["password"].ToString();
                string photo =reader["photo"].ToString();
                int reportsTo =Int32.Parse(reader["reports_to"].ToString());
                long accountNo = long.Parse(reader["account_number"].ToString());

               Employee employee = new Employee
                {
                    EmpId=id,
                    EmpFirstName=firstname,
                    EmpLastName=lastname,
                    BirthDate=birthdate.ToShortDateString(),
                    HireDate=hiredate.ToShortDateString(),
                    ContactNumber=contact,
                    Email=email,
                    Password=password,
                    Photo=photo,
                    ReportsTo=reportsTo,
                    AccountNumber=accountNo
                   
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
   public Employee GetById(int empId){
          Employee employee =new Employee();
          MySqlConnection connection=new MySqlConnection(_conString);
          try{
              MySqlCommand command=new MySqlCommand();
              command.CommandText="SELECT * FROM employees where employee_id=@employeeId";
              command.Connection=connection;
              command.Parameters.AddWithValue("@employeeId",empId);
              connection.Open();
              MySqlDataReader reader = command.ExecuteReader();
              if (reader.Read())
              {
                int id = Int32.Parse(reader["employee_id"].ToString());
                string firstname = reader["empfirst_name"].ToString();
                string lastname = reader["emplast_name"].ToString();
                DateTime birthdate =  DateTime.Parse(reader["birth_date"].ToString());
                DateTime hiredate =DateTime.Parse(reader["hire_date"].ToString());
                string contact=reader["contact_number"].ToString();
                string email = reader["email"].ToString();
                string password = reader["password"].ToString();
                string photo =reader["photo"].ToString();
                int reportsTo =Int32.Parse(reader["reports_to"].ToString());
                long accountNo = long.Parse(reader["account_number"].ToString());
                employee = new Employee
                  {
                    EmpId=id, 
                    EmpFirstName=firstname,
                    EmpLastName=lastname,
                    BirthDate=birthdate.ToShortDateString(),
                    HireDate=hiredate.ToShortDateString(),
                    ContactNumber=contact,
                    Email=email,
                    Password=password,
                    Photo=photo,
                    ReportsTo=reportsTo,
                    AccountNumber=accountNo                     
                  };
              }
          }
          catch(Exception e){
              throw e;
          }
          finally{
              connection.Close();
          }
          return employee;
   }
   public  bool Insert(Employee emp){    
          bool status = false;
          MySqlConnection con = new MySqlConnection();
          con.ConnectionString=_conString;
          try{
            

              string query =$"INSERT INTO employees(empfirst_name,emplast_name,birth_date,hire_date,contact_number,email,password,photo,reports_to,account_number)VALUES"+
                                                  "(@EmpFirstName,@EmpLastName,@BirthDate,@HireDate,@ContactNumber,@Email,@Password,@Photo,@ReportsTo,@AccountNumber)";
             Console.WriteLine(query);
             con.Open();
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
             command.ExecuteNonQuery(); 
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
   public  bool Update(Employee emp){       
          Console.WriteLine(emp);
          bool status=false;
          MySqlConnection con = new MySqlConnection();
          con.ConnectionString=_conString;
          try{
            string query = "UPDATE employees SET empfirst_name=@EmpFirstName, emplast_name=@EmpLastName, birth_date=@BirthDate, hire_date=@HireDate, contact_number=@ContactNumber, email=@Email, password=@Password, photo=@Photo, reports_to=@ReportsTo, account_number=@AccountNumber WHERE employee_id=@EmployeeId";   
             Console.WriteLine(query);
             con.Open();
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
             command.ExecuteNonQuery();               
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
   public  bool Delete(int empId){
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