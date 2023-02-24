using MySql.Data.MySqlClient;
using E_AgroServiceDemo.Repositories.Interfaces;
using E_AgroServiceDemo.Models;
using System.ComponentModel;

namespace E_AgroServiceDemo.Repositories;

public class UserRepository:IUserRepository{
        public static string conString = "server=localhost;port=3306;user=root;password=password;database=eagroservicesdb";

    public bool ValidateAdmin(User user)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "SELECT EXISTS(SELECT * FROM users where ContactNumber='" + user.ContactNumber + "' and Password='" + user.Password +"'and role='Admin')";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
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
            con.Close();
        }

        return status;

    }

    public bool ValidateFarmer(User user)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "SELECT EXISTS(SELECT * FROM users where ContactNumber='" + user.ContactNumber + "' and Password='" + user.Password +"'and role='farmer')";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
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
            con.Close();
        }

        return status;

    }

}