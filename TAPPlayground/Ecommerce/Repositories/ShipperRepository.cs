using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace ECommerceApp.Repositories;
public class ShipperRepository : IShipperRepository
{
      

    public static string conString = "server=localhost;port=3306;user=root;password=Password;database=Ecommerce";


    public List<Shipper> GetAllShippers()
    {
        List<Shipper> shippers = new List<Shipper>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;
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
                    AcountNumber = accountNo
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
}

    