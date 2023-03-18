using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using ECommerceApp.Models;

namespace ECommerceApp.Repositories;
public class UserRepository:IUserRepository{
      public static string conString = "server=localhost;port=3306;user=root;password=Rohit@7378;database=Ecommerce";

    public List<User> GetAllUser()
    {
       List<User> users = new List<User>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;
        try
        {
            string query = "SELECT * FROM users";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = int.Parse(reader["user_id"].ToString());
                string contactNumber = reader["contact_number"].ToString();
                string password = reader["password"].ToString();
                User user = new User
                {
                    UserId = id,
                    ContactNumber = contactNumber ,
                    Password = password,
                };
                users.Add(user);
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
        return users;
    }
    

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