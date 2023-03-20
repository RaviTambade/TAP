using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System.Globalization;
namespace ECommerceApp.Repositories;
public class OrderRepository : IOrderRepository
{
    public static string conString = "server=localhost;port=3306;user=root;password=Password;database=Ecommerce";

    public List<Order> GetAllOrders()
    {
        List<Order> orders = new List<Order>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "SELECT * FROM orders";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = int.Parse(reader["order_id"].ToString());
                DateTime orderDate = DateTime.ParseExact(reader["order_date"].ToString(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime shippedDate = DateTime.ParseExact(reader["shipped_date"].ToString(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                int customerId = int.Parse(reader["cust_id"].ToString());
                double total = double.Parse(reader["total"].ToString());
                string? status = reader["status"].ToString();

                Order order = new Order()
                {
                    OrderId = id,
                    OrderDate = orderDate.ToLongDateString(),
                    ShippedDate = shippedDate.ToLongDateString(),
                    CustomerId = customerId,
                    Total = total,
                    Status = status
                };

                orders.Add(order);
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
        return orders;
    }

    public Order GetOrderById(int id)
    {
        Order order = new Order();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "SELECT * FROM orders where order_id=" + id;
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //int orderId = int.Parse(reader["order_id"].ToString());
                DateTime orderDate = DateTime.ParseExact(reader["order_date"].ToString(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime shippedDate = DateTime.ParseExact(reader["shipped_date"].ToString(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                int customerId = int.Parse(reader["cust_Id"].ToString());
                double total = double.Parse(reader["total"].ToString());
                string? status = reader["status"].ToString();

                order = new Order()
                {
                    OrderId = id,
                    OrderDate = orderDate.ToShortDateString(),
                    ShippedDate = shippedDate.ToShortDateString(),
                    CustomerId = customerId,
                    Total = total,
                    Status = status
                };
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
        return order;
    }

    public int GetOrderId(int customerId)
    {
        int orderId = 0;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = $"SELECT MAX(order_id) as order_id from orders where cust_id={customerId}";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                orderId = int.Parse(reader["order_id"].ToString());
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
        return orderId;
    }

    public bool InsertOrder(int customerId)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = $"INSERT INTO orders(cust_id)VALUES('{customerId}')";
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
    public Order GetOrderByCustId(int custid)
    {
        Order order = new Order();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "SELECT * FROM orders where cust_id=" + custid;
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int orderId = int.Parse(reader["order_id"].ToString());
                DateTime orderDate = DateTime.ParseExact(reader["order_date"].ToString(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime shippedDate = DateTime.ParseExact(reader["shipped_date"].ToString(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                double total = double.Parse(reader["total"].ToString());
                string? status = reader["status"].ToString();

                order = new Order()
                {
                    OrderId = orderId,
                    CustomerId = custid,
                    OrderDate = orderDate.ToLongDateString(),
                    ShippedDate = shippedDate.ToLongDateString(),
                    Total = total,
                    Status = status
                };
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
        return order;
    }
    public bool InsertOrders(Order order)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = $"INSERT INTO orders(order_date,shipped_date,cust_id,total,status)VALUES" +
            "('" + order.OrderDate + "','" + order.ShippedDate + "'," + order.CustomerId + "," + order.Total + ",'" + order.Status + "')";
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

    public bool UpdateOrder(Order order)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "Update orders set order_date='" + order.OrderDate + "', shipped_date='" + order.ShippedDate + "',cust_id='" + order.CustomerId + "', total ='" + order.Total + "', status ='" + order.Status + "' Where order_id =" + order.OrderId;
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
    public bool DeleteOrder(int id)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "DELETE FROM orders where order_id =" + id;
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

    public List<Order> GetAllCancelledOrders()
    {
        List<Order> orders = new List<Order>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {

            string query = " SELECT * FROM orders WHERE cust_id=1 and status='cancelled' ";
            //"SELECT * FROM orders WHERE status= cancelled" ;


            Console.WriteLine(query);
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = int.Parse(reader["order_id"].ToString());
                DateTime orderDate = DateTime.ParseExact(reader["order_date"].ToString(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime shippedDate = DateTime.ParseExact(reader["shipped_date"].ToString(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                int customerId = int.Parse(reader["cust_id"].ToString());
                double total = double.Parse(reader["total"].ToString());
                string? status = reader["status"].ToString();

                Order order = new Order()
                {
                    OrderId = id,
                    OrderDate = orderDate.ToLongDateString(),
                    ShippedDate = shippedDate.ToLongDateString(),
                    CustomerId = customerId,
                    Total = total,
                    Status = status
                };

                orders.Add(order);
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
        return orders;
    }


    public List<Order> GetAllDeliveredOrders()
    {
        List<Order> orders = new List<Order>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {

            string query = " SELECT * FROM orders WHERE cust_id=1 and status='delivered' ";
            //"SELECT * FROM orders WHERE status= cancelled" ;


            Console.WriteLine(query);
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = int.Parse(reader["order_id"].ToString());
                DateTime orderDate = DateTime.ParseExact(reader["order_date"].ToString(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime shippedDate = DateTime.ParseExact(reader["shipped_date"].ToString(), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                int customerId = int.Parse(reader["cust_id"].ToString());
                double total = double.Parse(reader["total"].ToString());
                string? status = reader["status"].ToString();

                Order order = new Order()
                {
                    OrderId = id,
                    OrderDate = orderDate.ToLongDateString(),
                    ShippedDate = shippedDate.ToLongDateString(),
                    CustomerId = customerId,
                    Total = total,
                    Status = status
                };

                orders.Add(order);
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
        return orders;
    }


}