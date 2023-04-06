using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
namespace ECommerceApp.Repositories;
public class AddressRepository : IAddressRepository
{
    private IConfiguration _configuration;

    private string _conString;

    public AddressRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }


    public List<Address> GetAll()
    {
        List<Address> addresses = new List<Address>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM addresses";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int addressId=int.Parse(reader["address_id"].ToString());
                int custId=int.Parse(reader["cust_id"].ToString());
                string? houseNumber = reader["house_number"].ToString();
                string? addressMode = reader["address_mode"].ToString();
                string? landmark = reader["landmark"].ToString();
                string? city = reader["city"].ToString();
                string? state = reader["state"].ToString();
                string? country = reader["country"].ToString();
                string? pincode = reader["pincode"].ToString();

                Address address = new Address
                {
                    AddressId = addressId,
                    CustomerId=custId,
                    AddressMode=addressMode,
                    HouseNumber = houseNumber,
                    Landmark = landmark,
                    City = city,
                    State = state,
                    Country = country,
                    PinCode = pincode
                };

                addresses.Add(address);
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
        return addresses;
    }

    public bool Insert(Address address)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = $"INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode)VALUES(@customerId,@addressMode,@houseNumber,@landmark,@city,@state,@country,@pincode)";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@customerId",address.CustomerId);
            command.Parameters.AddWithValue("@addressMode",address.AddressMode);
            command.Parameters.AddWithValue("@houseNumber",address.HouseNumber);
            command.Parameters.AddWithValue("@landmark",address.Landmark);
            command.Parameters.AddWithValue("@city",address.City);
            command.Parameters.AddWithValue("@state",address.State);
            command.Parameters.AddWithValue("@country",address.Country);
            command.Parameters.AddWithValue("@pincode",address.PinCode);
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

      public Address GetById(int addressId)
    {
        Address address= new Address();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM addresses where address_id=@addressId";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@addressId",addressId);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string? houseNumber = reader["house_number"].ToString();
                int custId=int.Parse(reader["cust_id"].ToString());
                string? addressMode = reader["address_mode"].ToString();
                string? landmark = reader["landmark"].ToString();
                string? city = reader["city"].ToString();
                string? state = reader["state"].ToString();
                string? country = reader["country"].ToString();
                string? pincode = reader["pincode"].ToString();

                 address = new Address
                {
                    AddressId = addressId,
                    CustomerId = custId,
                    HouseNumber = houseNumber,
                    AddressMode =addressMode,
                    Landmark = landmark,
                    City = city,
                    State = state,
                    Country = country,
                    PinCode = pincode
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
        return address;
    }
          public  bool Update(Address address){
          bool status = false;
          MySqlConnection con = new MySqlConnection();
          con.ConnectionString=_conString;
        try{
            
            string query = $"Update addresses SET cust_id=@customerId, address_mode =@addressMode,house_number=@houseNumber,landmark=@landmark,city=@city,state=@state,country=@country,pincode=@pincode WHERE address_id=@addressId ";
            Console.WriteLine(query);
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@addressId",address.AddressId);
            command.Parameters.AddWithValue("@customerId",address.CustomerId);
            command.Parameters.AddWithValue("@addressMode",address.AddressMode);
            command.Parameters.AddWithValue("@houseNumber",address.HouseNumber);
            command.Parameters.AddWithValue("@landmark",address.Landmark);
            command.Parameters.AddWithValue("@city",address.City);
            command.Parameters.AddWithValue("@state",address.State);
            command.Parameters.AddWithValue("@country",address.Country);
            command.Parameters.AddWithValue("@pincode",address.PinCode);
            command.ExecuteNonQuery();
            status = true;
            
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
   
   public  bool Delete(int addressId){
          bool status = false;
          MySqlConnection con = new MySqlConnection();
          con.ConnectionString=_conString;
          try{
            
            string query = "DELETE FROM addresses WHERE address_id=@addressId";
            MySqlCommand cmd=new MySqlCommand(query,con) ;
            cmd.Parameters.AddWithValue("@addressId",addressId);
            con.Open();
            cmd.ExecuteNonQuery();  
            status=true;            

          }catch(Exception e )
          {
            throw e;
          }
          finally {
            con.Close();
          }
          return status;
   }

}