using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace ECommerceApp.Repositories;
public class EmployeeRepository : IEmployeeRepository
{

    public static string conString="server=localhost;port=3306;user=root;password=password;database=ecommerce";

    public List<Employee> GetAllEmployees(){

        List<Employee> Employees=new List<Employee>();
        MySqlConnection connection=new MySqlConnection(conString);
        try{
            MySqlCommand command=new MySqlCommand();
            command.CommandText="SELECT * FROM employees";
            command.Connection=connection;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                 int id = Int32.Parse(reader["employee_id"].ToString());
                string firstname = reader["empfirst_name"].ToString();
                string lastname = reader["emplast_name"].ToString();
                DateTime birthdate =  DateTime.Parse(reader["birth_date"].ToString(),System.Globalization.CultureInfo.InvariantCulture);
                DateTime hiredate =DateTime.Parse(reader["hire_date"].ToString(),System.Globalization.CultureInfo.InvariantCulture);
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
                id = Int32.Parse(reader["employee_id"].ToString());
                string firstname = reader["empfirst_name"].ToString();
                string lastname = reader["emplast_name"].ToString();
                DateTime birthdate =  DateTime.Parse(reader["birth_date"].ToString(),System.Globalization.CultureInfo.InvariantCulture);
                DateTime hiredate =DateTime.Parse(reader["hire_date"].ToString(),System.Globalization.CultureInfo.InvariantCulture);
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
   
   public  bool InsertEmp(Employee emp){
         
          Console.WriteLine("Printing emp Object");
          Console.WriteLine(emp);
          Console.WriteLine(emp.EmpId);
          Console.WriteLine(emp.EmpFirstName);
          Console.WriteLine(emp.EmpLastName);
          Console.WriteLine(emp.BirthDate);
          Console.WriteLine(emp.HireDate);
          Console.WriteLine(emp.ContactNumber);
          Console.WriteLine(emp.Email);
          Console.WriteLine(emp.Password);
          Console.WriteLine(emp.Photo);
          Console.WriteLine(emp.ReportsTo);
          Console.WriteLine(emp.AccountNumber);
          bool status = false;
          MySqlConnection con = new MySqlConnection();
          con.ConnectionString=conString;
          try{
            //string query =$"INSERT INTO employees(empfirst_name,emplast_name,birth_date,hire_date,contact_number,email,password,photo,reports_to,account_number)VALUES('"+emp.EmpFirstName+"','"+emp.EmpLastName+"','1998-05-19','2023-03-15','"+emp.ContactNumber+"','"+emp.Email+"','"+emp.Password+"','"+emp.Photo+"','"+emp.ReportsTo+"','"+emp.AccountNumber+"')";
              string query =$"INSERT INTO employees(empfirst_name,emplast_name,birth_date,hire_date,contact_number,email,password,photo,reports_to,account_number)VALUES"+
              "('"+emp.EmpFirstName+"','"+emp.EmpLastName+ "','1998-05-19','2023-03-15','"+ emp.ContactNumber+ "','"+
                emp.Email+"','"+emp.Password+ "','"+ emp.Photo+"',"+emp.ReportsTo+","+39025546668+")";

              Console.WriteLine(query);
        
  

             MySqlCommand cmd=new MySqlCommand(query,con) ;
             con.Open();
             cmd.ExecuteNonQuery(); 
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

   public  bool UpdateEmp(Employee emp){
          bool status = false;
          MySqlConnection con = new MySqlConnection();
          con.ConnectionString=conString;
          try{
            
            string query = "UPDATE employees SET empfirst_name='"+emp.EmpFirstName+"', emplast_name= '"+emp.EmpLastName+"',birth_date='"+emp.BirthDate+"',hire_date='"+emp.HireDate+"',contact_number='"+emp.ContactNumber+"',email='"+emp.Email+"',password='"+emp.Password+"',photo='"+emp.Photo+"',reports_to="+emp.ReportsTo+",account_number='"+emp.AccountNumber+"' WHERE employee_id=" +emp.EmpId;
             MySqlCommand cmd=new MySqlCommand(query,con) ;
             con.Open();
             cmd.ExecuteNonQuery();               
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
   
   public  bool DeleteEmp(int id){
          bool status = false;
          MySqlConnection con = new MySqlConnection();
          con.ConnectionString=conString;
          try{
            
            string query = "DELETE FROM employees WHERE employee_id="+id;
             MySqlCommand cmd=new MySqlCommand(query,con) ;
             con.Open();
             cmd.ExecuteNonQuery();              

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