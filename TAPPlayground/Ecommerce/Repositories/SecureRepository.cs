using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace ECommerceApp.Repositories;
public class SecureRepository : ISecureRepository
{
    private IConfiguration _configuration;
    private string _conString;

    public SecureRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

    public bool RegisterCustomer(Customer customer)
    {
        bool status = false;
        MySqlConnection connection=new MySqlConnection(_conString);
        try{
            string query= $"INSERT INTO customers(first_name,last_name,email,contact_number,password,account_number)VALUES(@firstName,@lastName,@email,@contactNumber,@password,@accountNumber)";
            MySqlCommand command=new MySqlCommand(query,connection);
            command.Parameters.AddWithValue("@firstName",customer.FirstName);
            command.Parameters.AddWithValue("@lastName",customer.LastName);
            command.Parameters.AddWithValue("@email",customer.Email);
            command.Parameters.AddWithValue("@password",customer.Password);
            command.Parameters.AddWithValue("@accountNumber",customer.AccountNumber);
            connection.Open();
            command.ExecuteNonQuery();
            status=true;
        }
        
        catch(Exception e){
            throw e;
        }
        finally{
            connection.Close();
        }
      return status;      
 
    }

    public bool ValidateUser(Credential user)
    {
        bool status = false;
         MySqlConnection connection=new MySqlConnection(_conString);
        try{
            MySqlCommand command=new MySqlCommand();
            command.CommandText="SELECT EXISTS(SELECT * FROM users where email=@email and password=@password)";
            command.Connection=connection;
            command.Parameters.AddWithValue("@email",user.Email);
            command.Parameters.AddWithValue("@password",user.Password);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader(); 
            reader.Read();
            if ((Int64)reader[0] == 1)
            {
                status = true;
            }
            reader.Close();
        }
        catch(Exception e)
        {
            throw e;
        }
        finally
        {
            connection.Close();
        }
      return status;      
    
    }

    public  bool ChangePassword(ChangedCredential user){
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString=_conString;
    try{
        
        string query = $"Update users SET password =@newPassword WHERE email=@email and password=@oldPassword";
        MySqlCommand cmd=new MySqlCommand(query,con);
        cmd.Parameters.AddWithValue("@newPassword",user.NewPassword);
        cmd.Parameters.AddWithValue("@email",user.Email);
        cmd.Parameters.AddWithValue("@oldPassword",user.OldPassword);
        con.Open();
        int rowsAffected= cmd.ExecuteNonQuery();
        if(rowsAffected>=1)
        {
            status= true;
        }
        }
    catch(Exception e )
        {
        throw e;
        }
        finally {
        con.Close();
        }
        return status;
   }
   
}

    