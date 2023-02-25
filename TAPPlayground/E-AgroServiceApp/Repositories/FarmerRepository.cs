using MySql.Data.MySqlClient;
using E_AgroServiceDemo.Repositories.Interfaces;
using E_AgroServiceDemo.Models;
using Mysqlx.Crud;

namespace E_AgroServiceDemo.Repositories;

public class FarmerRepository : IFarmerRepository
{
    public static string conString = "server=localhost;port=3306;user=root;password=password;database=eagroservicesdb";

    public List<Farmer> GetAllFarmers()
    {
        List<Farmer> farmers = new List<Farmer>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "SELECT * FROM farmers";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = Int32.Parse(reader["farmerId"].ToString());
                string name = reader["farmerName"].ToString();
                string mobileNumber = reader["contactNumber"].ToString();
                string location = reader["location"].ToString();
                string password = reader["password"].ToString();
                long creditedAmount = long.Parse(reader["creditBalance"].ToString());
                long debitedAmount = long.Parse(reader["debitBalance"].ToString());
                long balance = long.Parse(reader["balance"].ToString());
                Farmer farmer = new Farmer()
                {
                    FarmerId = id,
                    FarmerName = name,
                    ContactNumber = mobileNumber,
                    Location = location,
                    Password = password,
                    CreditedAmount = creditedAmount,
                    DebitedAmount = debitedAmount,
                    Balance = balance
                };

                farmers.Add(farmer);
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
        return farmers;

    }

    public Farmer GetFarmerById(int id)
    {
        Farmer farmer = null;
        
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "SELECT * FROM farmers where farmerId=" + id;
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {   int newid =int.Parse(reader["farmerId"].ToString());
                string name = reader["farmerName"].ToString();
                string mobileNumber = reader["contactNumber"].ToString();
                string location = reader["location"].ToString();
                string password = reader["password"].ToString();
                long creditedAmount = long.Parse(reader["creditBalance"].ToString());
                long debitedAmount = long.Parse(reader["debitBalance"].ToString());
                long balance = long.Parse(reader["balance"].ToString());
                farmer = new Farmer()
                {
                    FarmerId = newid,
                    FarmerName = name,
                    ContactNumber = mobileNumber,
                    Location = location,
                    Password = password,
                    CreditedAmount = creditedAmount,
                    DebitedAmount = debitedAmount,
                    Balance = balance
                };

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

        return farmer;
    }

    public bool InsertFarmer(Farmer farmer)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "INSERT INTO farmers(farmerName,contactNumber,password,location)Values('" + farmer.FarmerName + "','" + farmer.ContactNumber + "','" + farmer.Password + "','" + farmer.Location + "')";

            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
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
        return status;
    }


    
    public bool UpdateFarmer(Farmer farmer)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;
        try
        {
            string query = "UPDATE farmers SET farmerName='" + farmer.FarmerName+ "', contactNumber='" + farmer.ContactNumber + "' , password='" + farmer.Password + "' , location='" + farmer.Location + "' WHERE farmerId=" +farmer.FarmerId ;   
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            status = true;
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

 public bool DeleteFarmer(int id)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;
        try
        {
            string query = "DELETE FROM farmers WHERE farmerId="+id  ;
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            status = true;
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