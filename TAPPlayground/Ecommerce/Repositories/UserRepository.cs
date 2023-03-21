using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using ECommerceApp.Models;

namespace ECommerceApp.Repositories;
public class UserRepository:IUserRepository{
    private IConfiguration _configuration;
    private string _conString;
    public UserRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

    public List<User> GetAll()
    {
       List<User> users = new List<User>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
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
    

    public bool Validate(User user)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "SELECT EXISTS(SELECT * FROM users where contact_number=@contactNumber and password=@password)";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@contactNumber",user.ContactNumber);
            command.Parameters.AddWithValue("@password",user.Password);
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