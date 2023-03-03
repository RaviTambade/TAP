using MySql.Data.MySqlClient;
using SessionManagement.Models;

namespace SessionManagement.Repositories;
public class AddressRepository : IAddressRepository
{

    public static string conString = "server=localhost;port=3306;user=root;password=Password;database=simpledb";
    
    public bool InsertAddress(Address address)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "INSERT INTO address(custId,houseNo,landmark,city,state,pincode,country)" +
                            "VALUES('" + address.CustId + "','" + address.HouseNo + "','" + address.Landmark + "','" + address.City + "','" + address.State + "','" + address.Pincode + "','" + address.Country + "')";

            MySqlCommand command = new MySqlCommand(query, con);
            con.Open();
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