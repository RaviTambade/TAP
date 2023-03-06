using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace ECommerceApp.Repositories;
public class OrderRepository : IOrderRepository
{
    public static string conString = "server=localhost;port=3306;user=root;password=password;database=Ecommerce";

   
     public bool InsertOrder(Order order)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query =$"INSERT INTO orders(cust_id,status)VALUES('{order.CustomerId}','processing')";
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