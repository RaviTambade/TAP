using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace ECommerceApp.Repositories;
public class AddressRepository : IAddressRepository
{
    public static string conString="server=localhost;port=3306;user=root;password=password;database=Ecommerce";

    public List<Address> GetAddresses(int id)
    {
          List<Address> addresses = new List<Address>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "SELECT * FROM addresses where cust_id="+id;
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
               
                string? houseNumber = reader["house_number"].ToString();
                string? landmark = reader["landmark"].ToString();
                string? city = reader["city"].ToString();
                string? state = reader["state"].ToString();
                string? country = reader["country"].ToString();
                string? pincode = reader["pincode"].ToString();

                Address address=new Address
                {
                   HouseNumber=houseNumber,
                   Landmark=landmark,
                   City=city,
                   State=state,
                   Country=country,
                   PinCode=pincode
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

     public bool InsertAddress(Address address)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query =$"INSERT INTO addresses(cust_id,address_mode,house_number,landmark,city,state,country,pincode)VALUES('{address.CustomerId}','{address.AddressMode}','{address.HouseNumber}','{address.Landmark}','{address.City}','{address.State}','{address.Country}','{address.PinCode}')";
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