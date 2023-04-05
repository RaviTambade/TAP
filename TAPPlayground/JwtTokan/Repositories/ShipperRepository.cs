using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;

using Microsoft.Extensions.Configuration;  // set namespace 
namespace ECommerceApp.Repositories;
public class ShipperRepository : IShipperRepository
{

    //IConfiguration interface help us to 
    //read settings available in appsettings.json file
    
    private readonly IConfiguration _configuration;
    private readonly string _conString;
  
    //Parameterized Constructor
    public ShipperRepository(IConfiguration configuration){
        _configuration=configuration;
        _conString= this._configuration.GetConnectionString("DefaultConnection");
    }

    public List<Shipper> GetAll()
    {
        List<Shipper> shippers = new List<Shipper>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM shippers";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                    int id = int.Parse(reader["shipper_id"].ToString());
                    string? companyName = reader["company_name"].ToString();
                    string? email = reader["email"].ToString();
                    string? contactNumber = reader["contact_number"].ToString();
                    long accountNo = long.Parse(reader["account_number"].ToString());

                Shipper shipper = new Shipper
                {
                    ShipperId = id,
                    CompanyName = companyName,
                    ContactNumber = contactNumber,
                    Email = email,
                    AccountNumber = accountNo
                };
                shippers.Add(shipper);
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
        return shippers;
    }
    

    public Shipper GetById(int id)
    {
        Shipper shipper = new Shipper();
        MySqlConnection connection = new MySqlConnection(_conString);
        try
        {
            string query = "SELECT * FROM shippers WHERE shipper_id= @shipperId";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@shipperId", id);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                    id = int.Parse(reader["shipper_id"].ToString());
                    string companyName = reader["company_name"].ToString();
                    string contactNumber = reader["contact_number"].ToString();
                    string email = reader["email"].ToString();
                    long accountNumber = long.Parse(reader["account_number"].ToString());

                shipper = new Shipper()
                {
                    ShipperId = id,
                    CompanyName = companyName,
                    ContactNumber = contactNumber,
                    Email = email,
                    AccountNumber = accountNumber
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
            connection.Close();
        }
        return shipper;
    }


   public bool Insert(Shipper shipper){
        bool status=false;
        MySqlConnection connection=new MySqlConnection();
        connection.ConnectionString=_conString;
        try{
            string query=$"INSERT INTO shippers(company_name,contact_number,email,password,account_number)VALUES(@companyName, @contactNumber,@email,@password, @accountNumber)";
            Console.WriteLine(query);
          
            MySqlCommand command=new MySqlCommand(query ,connection);
            command.Parameters.AddWithValue("@companyName",shipper.CompanyName);
            command.Parameters.AddWithValue("@contactNumber",shipper.ContactNumber);
            command.Parameters.AddWithValue("@email",shipper.Email);
            command.Parameters.AddWithValue("@password",shipper.Password);
            command.Parameters.AddWithValue("@accountNumber",shipper.AccountNumber);
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
        return status;
    }

 public bool Update(Shipper shipper)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "UPDATE shippers SET company_name=@companyname, contact_number=@contactNumber,email=@email,password=@password,account_number=@accountNumber WHERE shipper_id =@shipperId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@shipperId",shipper.ShipperId);
            command.Parameters.AddWithValue("@companyName",shipper.CompanyName);
            command.Parameters.AddWithValue("@contactNumber",shipper.ContactNumber);
            command.Parameters.AddWithValue("@email",shipper.Email);
            command.Parameters.AddWithValue("@password",shipper.Password);
            command.Parameters.AddWithValue("@accountNumber",shipper.AccountNumber);
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
        return status;

    }

    public bool Delete(int id)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
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
        return status;
    }


}

    