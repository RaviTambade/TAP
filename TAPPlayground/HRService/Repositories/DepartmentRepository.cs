using HRService.Models;
using HRService.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;         
namespace HRService.Repositories;
public class DepartmentRepository : IDepartmentRepository
{
  private IConfiguration _configuration;
  private string _conString;

  public DepartmentRepository(IConfiguration configuration){
      _configuration= configuration;
      _conString=this._configuration.GetConnectionString("DefaultConnection");
    }

  public async Task<List<Department>> GetAll(){
        await Task.Delay(5000);
        List<Department> departments=new List<Department>();
        MySqlConnection connection=new MySqlConnection(_conString);
        try{
            MySqlCommand command=new MySqlCommand();
            command.CommandText="SELECT * FROM departments";
            command.Connection= connection;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = Int32.Parse(reader["dept_id"].ToString());
                string deptname = reader["dept_name"].ToString();
                string location = reader["location"].ToString();
                
               Department department = new Department
                {
                    DeptId=id,
                    DeptName=deptname,
                    Location=location  
                };
                departments.Add(department);
            }
        }
        catch(Exception e){
            throw e;
        }
        finally{
            connection.Close();
        }
      return departments; 
    }
   public async Task< Department> GetById(int deptId)
   {
          Department department =new Department();
          MySqlConnection connection=new MySqlConnection(_conString);
          try{
              MySqlCommand command=new MySqlCommand();
              command.CommandText="SELECT * FROM departments where dept_id=@deptId";
              command.Connection=connection;
              command.Parameters.AddWithValue("@deptId",deptId);
              connection.Open();
              MySqlDataReader reader = command.ExecuteReader();
              if (reader.Read())
              {
                int id = Int32.Parse(reader["dept_id"].ToString());
                string deptname = reader["dept_name"].ToString();
                string location = reader["location"].ToString();
        
                department = new Department
                  {
                    DeptId=id, 
                    DeptName=deptname,
                    Location=location                     
                  };
              }
          }
          catch(Exception e){
              throw e;
          }
          finally{
              connection.Close();
          }
          return department;
   }
   public async Task< bool> Insert(Department dept)
   {    
          bool status = false;
          MySqlConnection con = new MySqlConnection();
          con.ConnectionString=_conString;
          try{
              string query =$"INSERT INTO departments(dept_name,location)VALUES"+
                                                  "(@DeptName,@Location)";
             Console.WriteLine(query);
             con.Open();
             MySqlCommand command=new MySqlCommand(query,con) ;
             command.Parameters.AddWithValue("@DeptName",dept.DeptName);             
             command.Parameters.AddWithValue("@Location",dept.Location);
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
   public async Task <bool> Update(Department dept){       
          Console.WriteLine(dept);
          bool status=false;
          MySqlConnection con = new MySqlConnection();
          con.ConnectionString=_conString;
          try{
            string query = "UPDATE departments SET dept_name=@DeptName, location=@Location WHERE dept_id=@DeptId";   
             Console.WriteLine(query);
             con.Open();
             MySqlCommand command=new MySqlCommand(query,con) ;
              command.Parameters.AddWithValue("@DeptId",dept.DeptId); 
             command.Parameters.AddWithValue("@DeptName",dept.DeptName);
             command.Parameters.AddWithValue("@Location",dept.Location);             
             
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
   public async Task<bool> Delete(int deptId){
          bool status = false;
          MySqlConnection con = new MySqlConnection();
          con.ConnectionString=_conString;
          try{
            string query = "DELETE FROM departments WHERE dept_id=@DeptId";
             MySqlCommand command=new MySqlCommand(query,con) ;
            command.Parameters.AddWithValue("@DeptId",deptId);
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