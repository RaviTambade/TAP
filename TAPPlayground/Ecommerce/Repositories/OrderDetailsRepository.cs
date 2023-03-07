using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace ECommerceApp.Repositories;
public class OrderDetailsRepository : IOrderDetailsRepository
{
    public static string conString = "server=localhost;port=3306;user=root;password=password;database=Ecommerce";
    public bool InsertOrderdetails(int orderId, int productId, int quantity)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = $"INSERT INTO orderdetails(order_id,product_id,quantity)VALUES('{orderId}','{productId}','{quantity}')";
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
    public List<Product> GetOrderdProducts(int orderId)
    {
        List<Product> products = new List<Product>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;
        try
        {
            string query = $"SELECT orderdetails.product_id,products.title,products.description,products.unit_price," +
                            "products.image,orderdetails.order_id,orderdetails.quantity," +
                            "(products.unit_price*orderdetails.quantity) as totalprice from products INNER JOIN " +
                            "orderdetails ON products.product_id = orderdetails.product_id " +
                            "WHERE orderdetails.order_id=" + orderId;
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = Int32.Parse(reader["product_id"].ToString());
                string? title = reader["title"].ToString();
                string? description = reader["description"].ToString();
                double price = double.Parse(reader["unit_price"].ToString());
                string? imgUrl = reader["image"].ToString();
                int quantity = Int32.Parse(reader["quantity"].ToString());
                double totalprice = double.Parse(reader["totalprice"].ToString());

                Product product = new Product
                {
                    ProductId = id,
                    Title = title,
                    Description = description,
                    UnitPrice = price,
                    ImageUrl = imgUrl,
                    BuyQuantity = quantity
                };

                products.Add(product);
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
        return products;
    }

    public List<OrderHistory> OrderHistory(int customerId)
    {
        List<OrderHistory> orderHistories = new List<OrderHistory>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;
        try
        {
            string query = $"SELECT products.product_id,products.title , products.unit_price, orderdetails.quantity,customers.cust_id,orders.order_id,orders.order_date FROM products,customers, orders INNER JOIN orderdetails on orderdetails.order_id=orders.order_id WHERE  products.product_id=orderdetails.product_id AND customers.cust_id=orders.cust_id AND customers.cust_id={customerId} order by orders.order_id;";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string? title = reader["title"].ToString();
                double unitprice = double.Parse(reader["unit_price"].ToString());
                int quantity = int.Parse(reader["quantity"].ToString());
                DateTime date = DateTime.Parse(reader["order_date"].ToString());

                OrderHistory orderhistory = new OrderHistory
                {
                    Title = title,
                    UnitPrice = unitprice,
                    Quantity = quantity,
                    OrderDate = date
                };
                orderHistories.Add(orderhistory);
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
        return orderHistories;
    }

}


