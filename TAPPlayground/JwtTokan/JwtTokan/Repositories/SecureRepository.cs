// using ECommerceApp.Models;
// using ECommerceApp.Repositories.Interfaces;
// using MySql.Data.MySqlClient;

// namespace ECommerceApp.Repositories;
// public class SecureRepository : ISecureRepository
// {
//     private IConfiguration _configuration;
//     private string _conString;

//     public SecureRepository(IConfiguration configuration)
//     {
//         _configuration = configuration;
//         _conString = this._configuration.GetConnectionString("DefaultConnection");
//     }

//     public bool ValidateUser(Credential user)
//     {
//         bool status = false;
//         MySqlConnection connection = new MySqlConnection(_conString);
//         try
//         {
//             MySqlCommand command = new MySqlCommand();
//             command.CommandText = "SELECT EXISTS(SELECT * FROM users where email=@email and password=@password)";
//             command.Connection = connection;
//             command.Parameters.AddWithValue("@email", user.Email);
//             command.Parameters.AddWithValue("@password", user.Password);
//             connection.Open();
//             MySqlDataReader reader = command.ExecuteReader();
//             reader.Read();
//             if ((Int64)reader[0] == 1)
//             {
//                 status = true;
//             }
//             reader.Close();
//         }
//         catch (Exception e)
//         {
//             throw e;
//         }
//         finally
//         {
//             connection.Close();
//         }
//         return status;

//     }

//     public bool ChangePassword(User user)
//     {
//         bool status = false;
//         MySqlConnection con = new MySqlConnection();
//         con.ConnectionString = _conString;
//         try
//         {

//             string query = $"Update users SET password =@newPassword WHERE email=@email";
//             MySqlCommand cmd = new MySqlCommand(query, con);
//             cmd.Parameters.AddWithValue("@newPassword", user.Password);
//             cmd.Parameters.AddWithValue("@email", user.Email);
//             con.Open();
//             int rowsAffected = cmd.ExecuteNonQuery();
//             if (rowsAffected >= 1)
//             {
//                 status = true;
//             }
//         }
//         catch (Exception e)
//         {
//             throw e;
//         }
//         finally
//         {
//             con.Close();
//         }
//         return status;
//     }

//     public bool Register(User user)
//     {
//         bool status = false;
//         MySqlConnection connection = new MySqlConnection(_conString);
//         try
//         {
//             user.ContactNumber = "1234567890";
//             string query = "INSERT INTO users(email,contact_number,password)VALUES(@email,@contact_number,@password)";
//             MySqlCommand command = new MySqlCommand(query, connection);
//             command.Connection = connection;
//             command.Parameters.AddWithValue("@email", user.Email);
//             command.Parameters.AddWithValue("@password", user.Password);
//             command.Parameters.AddWithValue("@contact_number", user.ContactNumber);
//             connection.Open();
//             int rowsAffected = command.ExecuteNonQuery();
//             if (rowsAffected >= 1)
//             {
//                 status = true;
//             }
//         }

//         catch (Exception e)
//         {
//             throw e;
//         }
//         finally
//         {
//             connection.Close();
//         }
//         return status;
//     }

//     public bool UpdatePassword(ChangedCredential credential)
//     {
//         bool status = false;
//         MySqlConnection con = new MySqlConnection();
//         con.ConnectionString = _conString;
//         try
//         {

//             string query = $"Update users SET password =@newPassword WHERE email=@email AND password =@oldPassword";
//             MySqlCommand cmd = new MySqlCommand(query, con);
//             cmd.Parameters.AddWithValue("@email", credential.Email);
//             cmd.Parameters.AddWithValue("@newPassword", credential.NewPassword);
//             cmd.Parameters.AddWithValue("@oldPassword", credential.OldPassword);
//             con.Open();
//             int rowsAffected = cmd.ExecuteNonQuery();
//             if (rowsAffected >= 1)
//             {
//                 status = true;
//             }
//         }
//         catch (Exception e)
//         {
//             throw e;
//         }
//         finally
//         {
//             con.Close();
//         }
//         return status;
//     }

//     public bool UpdateEmail(ChangedCredential credential)
//     {
//          bool status = false;
//         MySqlConnection con = new MySqlConnection();
//         con.ConnectionString = _conString;
//         try
//         {

//             string query = $"Update users SET email=@newemail  WHERE password =@password AND email=@email";
//             MySqlCommand cmd = new MySqlCommand(query, con);
//             cmd.Parameters.AddWithValue("@email", credential.Email);
//             cmd.Parameters.AddWithValue("@password", credential.OldPassword);
//             cmd.Parameters.AddWithValue("@newemail", credential.NewEmail);
//             con.Open();
//             int rowsAffected = cmd.ExecuteNonQuery();
//             if (rowsAffected >= 1)
//             {
//                 status = true;
//             }
//         }
//         catch (Exception e)
//         {
//             throw e;
//         }
//         finally
//         {
//             con.Close();
//         }
//         return status;
//     }
// }

