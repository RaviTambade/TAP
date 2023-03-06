using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using ECommerceApp.Models;

namespace ECommerceApp.Repositories;
public class UserRepository:IUserRepository{
      public static string conString = "server=localhost;port=3306;user=root;password=password;database=Ecommerce";

    public bool ValidateUser(User user)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;
        try
        {
            string query = "SELECT EXISTS(SELECT * FROM users where contact_number='" + user.ContactNumber + "' and password='" + user.Password+ "')";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if ((Int64)reader[0] == 1)
            {
                status = true;
            }
            reader.Close();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            connection.Close();
        }
        return status;
    }
}