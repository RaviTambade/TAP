using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace ECommerceApp.Repositories;
public class EmployeeRepository : IEmployeeRepository
{

    public static string conString="server=localhost;port=3306;user=root;password=password;database=Ecommerce";

    public List<Employee> GetAllEmployees(){

        List<Employee> Employees=new List<Employee>();

        Employee employee=new Employee();
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

   public Employee GetEmployeeById(int id){
          Employee employee =new Employee();
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
                
                  employee = new Employee
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
   
   public  bool InsertEmp(Employee emp){
          bool status = false;
          MySqlConnection con = new MySqlConnection();
          con.ConnectionString=conString;
          try{
            string query = "INSERT INTO employees(employee_id,empfirst_name,emplast_name,birth_date,hire_date,contact_number,email,password,photo,reports_to,account_number)"
                            + "VALUES("+emp.EmpId+",'"+emp.EmpFirstName+"'.'"+emp.EmpLastName+"',"+emp.BirthDate+","+emp.HireDate+",'"+emp.ContactNumber+"','"+emp.Email+"','"+emp.Password+"','"+emp.Photo+"',"+emp.ReportsTo+",'"+emp.AccountNumber+"')";

             MySqlCommand cmd=new MySqlCommand(query,con) ;
             con.Open();
             cmd.ExecuteReader();              

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