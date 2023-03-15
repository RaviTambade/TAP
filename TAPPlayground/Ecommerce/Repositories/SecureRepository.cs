using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace ECommerceApp.Repositories;
public class SecureRepository : ISecureRepository
{
    public static string conString = "server=localhost;port=3306;user=root;password=1234512345;database=Ecommerce";

    public bool RegisterCustomer(Customer customer)
    {
        bool status = false;
         MySqlConnection connection=new MySqlConnection(conString);
        try{
            MySqlCommand command=new MySqlCommand();
            command.CommandText=$"INSERT INTO customers(first_name,last_name,email,contact_number,password,account_number)VALUES('{customer.FirstName}','{customer.LastName}','{customer.Email}','{customer.ContactNumber}','{customer.Password}','{customer.AccountNumber}')";
            command.Connection=connection;
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
         MySqlConnection connection=new MySqlConnection(conString);
        try{
            MySqlCommand command=new MySqlCommand();
            command.CommandText="SELECT EXISTS(SELECT * FROM users where email='" + user.Email + "' and password='" + user.Password+ "')";
            command.Connection=connection;
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
        con.ConnectionString=conString;
    try{
        
        string query = $"Update users SET password ='{user.NewPassword}' WHERE email='{user.Email}' and password='{user.OldPassword}' ";
        MySqlCommand cmd=new MySqlCommand(query,con) ;
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

    