using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;

using Microsoft.Extensions.Configuration;  // set namespace 
namespace ECommerceApp.Repositories;
public class ShipperRepository : IShipperRepository
{
    private IConfiguration _configuration;
    private string _conString;
  

    //Parameterized Constructor
    public ShipperRepository(IConfiguration configuration){
        _configuration=configuration;
        _conString= this._configuration.GetConnectionString("DefaultConnection");
    }

    public List<Shipper> GetAllShippers()
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
    

    public Shipper GetShipperById(int id)
    {
        Shipper shipper = new Shipper();
        MySqlConnection connection = new MySqlConnection(_conString);
        try
        {
            string query = "SELECT * FROM shippers WHERE shipper_id=" + id;
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
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


   public bool InsertShipper(Shipper shipper){
        bool status=false;
        MySqlConnection connection=new MySqlConnection();
        connection.ConnectionString=_conString;
        try{
            string query=$"INSERT INTO shippers(company_name,contact_number,email,account_number)VALUES('{shipper.CompanyName}','{shipper.ContactNumber}','{shipper.Email}','{shipper.AccountNumber}')";
            Console.WriteLine(query);
            connection.Open();
            MySqlCommand command=new MySqlCommand(query ,connection);
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

 public bool UpdateShipper(Shipper shipper)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "UPDATE shippers SET company_name='" +shipper.CompanyName  + "', contact_number='" + shipper.ContactNumber +"', email='" + shipper.Email +"', account_number='" + shipper.AccountNumber  +"' WHERE shipper_id=" +shipper.ShipperId;
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

    public bool DeleteShipper(int id)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "DELETE FROM shippers WHERE shipper_id="+id;
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


}

    