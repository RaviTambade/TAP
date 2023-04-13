using LMSService.Models;
using LMSService.Repositories.Interfaces;
using MySql.Data.MySqlClient;

using Microsoft.Extensions.Configuration;  // set namespace 
namespace LMSService.Repositories;
public class StudentRepository : IStudentRepository
{

    //IConfiguration interface help us to 
    //read settings available in appsettings.json file
    
    private readonly IConfiguration _configuration;
    private readonly string _conString;
  
    //Parameterized Constructor
    public StudentRepository(IConfiguration configuration){
        _configuration=configuration;
        _conString= this._configuration.GetConnectionString("DefaultConnection");
    }

    public List<Student> GetAll()
    {
        List<Student> students = new List<Student>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        MySqlCommand command=new MySqlCommand();
        command.CommandText="SELECT * FROM students";
        command.Connection= connection;
        
        try{
        connection.Open();
        MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = Int32.Parse(reader["id"].ToString());
                string studentname = reader["student_name"].ToString();
                DateTime birthdate = Convert.ToDateTime(reader["date_of_birth"].ToString());
                int classes = Int32.Parse(reader["class"].ToString());
                string email = reader["email"].ToString();
                string sex = reader["sex"].ToString();
                string phoneno =reader["phone_number"].ToString();

                Student student = new Student
                {
                   StudentId=id,
                   StudentName=studentname,
                   DateOfBirth=birthdate,
                   Class=classes,
                   Email=email,
                   Sex=sex,
                   PhoneNo=phoneno 
                };
                students.Add(student);
            }
        }

        catch(Exception e){
            Console.WriteLine(e.Message);

            throw e;
        }
        finally{
            connection.Close();
        }
      return students; 
    }
    

    public Student GetById(int id)
    {
         Student student=null;
        MySqlConnection connection=new MySqlConnection(_conString);
        try{
            MySqlCommand command=new MySqlCommand();
            command.CommandText="SELECT * FROM students WHERE id="+id;
            command.Connection= connection;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int sid = Int32.Parse(reader["id"].ToString());
                string studentname = reader["student_name"].ToString();
                DateTime birthdate = Convert.ToDateTime(reader["date_of_birth"].ToString());
                int classes = Int32.Parse(reader["class"].ToString());
                string email = reader["email"].ToString();
                string sex = reader["sex"].ToString();
                string phoneno =reader["phone_number"].ToString();
                 student = new Student
                {
                   StudentId=sid,
                   StudentName=studentname,
                   DateOfBirth=birthdate,
                   Class=classes,
                   Email=email,
                   Sex=sex,
                   PhoneNo=phoneno 
                };    
            }
            reader.Close();
        }
        catch(Exception e){
            Console.WriteLine(e.Message);

            throw e;
        }
        finally{
            connection.Close();
        }
      return student; 
        
         
    }


   public bool Insert(Student Student){
        bool status=false;
       /* MySqlConnection connection=new MySqlConnection();
        connection.ConnectionString=_conString;
        try{
            string query=$"INSERT INTO shippers(company_name,contact_number,email,password,account_number)VALUES(@companyName, @contactNumber,@email,@password, @accountNumber)";
            Console.WriteLine(query);
          
            MySqlCommand command=new MySqlCommand(query ,connection);
            command.Parameters.AddWithValue("@companyName",Student.CompanyName);
            command.Parameters.AddWithValue("@contactNumber",Student.ContactNumber);
            command.Parameters.AddWithValue("@email",Student.Email);
            command.Parameters.AddWithValue("@password",Student.Password);
            command.Parameters.AddWithValue("@accountNumber",Student.AccountNumber);
            connection.Open();
              int rowsAffected=command.ExecuteNonQuery();
            if(rowsAffected >0){
             status=true;
            }
          }
        catch(Exception e){
             throw e;
        }
        finally{
          connection.Close();
        }

        */
        return status;
    }

 public bool Update(Student Student)
    {
        bool status = false;
       /* MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "UPDATE shippers SET company_name=@companyname, contact_number=@contactNumber,email=@email,password=@password,account_number=@accountNumber WHERE shipper_id =@shipperId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@shipperId",Student.ShipperId);
            command.Parameters.AddWithValue("@companyName",Student.CompanyName);
            command.Parameters.AddWithValue("@contactNumber",Student.ContactNumber);
            command.Parameters.AddWithValue("@email",Student.Email);
            command.Parameters.AddWithValue("@password",Student.Password);
            command.Parameters.AddWithValue("@accountNumber",Student.AccountNumber);
            connection.Open();
            int rowsAffected=command.ExecuteNonQuery();
            if(rowsAffected >0){
             status=true;
            }
        }
        catch (Exception e)
        {
            throw e;

        }
        finally
        {
            connection.Close();
        }

        */

        return status;

    }

    public bool Delete(int id)
    {
        bool status = false;
       /* MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "DELETE FROM shippers WHERE shipper_id=@shipperId";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@shipperId", id);
            command.ExecuteNonQuery();
            status = true;
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }

        */
        return status;
    }

}