using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace ECommerceApp.Repositories;
public class OrderDetailsRepository : IOrderDetailsRepository
{
    public static string conString = "server=localhost;port=3306;user=root;password=password;database=Ecommerce";

   
    public bool InsertOrderdetails(int orderId,int productId,int quantity)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query =$"INSERT INTO orderdetails(order_id,product_id,quantity)VALUES('{orderId}','{productId}','{quantity}')";
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