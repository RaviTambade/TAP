using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace ECommerceApp.Repositories;
public class EmployeeRepository : IEmployeeRepository
{

    public static string conString="server=localhost;port=3306;user=root;password=password;database=Ecommerce";

    public List<Employees> GetAllEmployees(){

        List<Employees> Employees=new List<Employees>();

        Employees employee=new Employees();
        MySqlConnection connection=new MySqlConnection(conString);
        try{
            MySqlCommand command=new MySqlCommand();
            command.CommandText=$"SELECT * FROM employees";
            command.Connection=connection;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                 int id = Int32.Parse(reader["employee_id"].ToString());
                string? firstname = reader["empfirst_name"].ToString();
                string? lastname = reader["emplast_name"].ToString();
                DateTime birthdate = DateTime.Parse(reader["birth_date"].ToString());
                DateTime hiredate = DateTime.Parse(reader["hire_date"].ToString());
                string? contact=reader["contact_number"].ToString();
                string? email = reader["email"].ToString();
                string? password = reader["password"].ToString();
                string? photo =reader["photo"].ToString();
                int reportsTo =Int32.Parse(reader["reports_to"].ToString());
                long accountNo = long.Parse(reader["account_number"].ToString());

                employee = new Employees
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

   public Employees GetEmployeeById(int id){
          Employees employee =new Employees();
            MySqlConnection connection=new MySqlConnection(conString);
          try{
              MySqlCommand command=new MySqlCommand();
              command.CommandText="SELECT * FROM employees where employee_id="+id;
              command.Connection=connection;
              connection.Open();
             MySqlDataReader reader = command.ExecuteReader();
              if (reader.Read())
              {
                int empid = Int32.Parse(reader["employee_id"].ToString());
                string? firstname = reader["empfirst_name"].ToString();
                string? lastname = reader["emplast_name"].ToString();
                DateTime birthdate = DateTime.Parse(reader["birth_date"].ToString());
                DateTime hiredate = DateTime.Parse(reader["hire_date"].ToString());
                string? contact=reader["contact_number"].ToString();
                string? email = reader["email"].ToString();
                string? password = reader["password"].ToString();
                string? photo =reader["photo"].ToString();
                int reportsTo =Int32.Parse(reader["reports_to"].ToString());
                long accountNo = long.Parse(reader["account_number"].ToString());
                
                  employee = new Employees
                  {
                    EmpId=empid,
                    EmpFirstName=firstname,
                    EmpLastName=lastname,
                    BirthDate=birthdate,
                    HireDate=hiredate,
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
   
   
   
   
   
   
   
   
   
   
   
   
   
   
    /*
    public Employees GetEmployeeById(int empid)
      {
          Employees employee=new Employees();
          MySqlConnection connection=new MySqlConnection(conString);
          try{
              MySqlCommand command=new MySqlCommand();
              command.CommandText="SELECT * FROM employees where employee_id="+empid;
              command.Connection=connection;
              connection.Open();
             MySqlDataReader reader = command.ExecuteReader();
              if (reader.Read())
              {
                int id = Int32.Parse(reader["employee_id"].ToString());
                string? firstname = reader["empfirst_name"].ToString();
                string? lastname = reader["emplast_name"].ToString();
                DateTime birthdate = DateTime.Parse(reader["birth_date"].ToString());
                DateTime hiredate = DateTime.Parse(reader["hire_date"].ToString());
                string? contact=reader["contact_number"].ToString();
                string? email = reader["email"].ToString();
                string? password = reader["password"].ToString();
                string? photo =reader["photo"].ToString();
                int reportsTo =Int32.Parse(reader["reports_to"].ToString());
                long accountNo = long.Parse(reader["account_number"].ToString());
                
                  employee = new Employees
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
      */

  
}