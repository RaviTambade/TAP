using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System.Globalization;
using Microsoft.Extensions.Configuration;
namespace ECommerceApp.Repositories;
public class OrderRepository : IOrderRepository
{
    private IConfiguration _configuration;

    private string _conString;

    public OrderRepository(IConfiguration configuration)
    {
        _configuration=configuration;
        _conString=this._configuration.GetConnectionString("DefaultConnection");
    }

    public List<Order> GetAll()
    {
        List<Order> orders = new List<Order>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM orders";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = int.Parse(reader["order_id"].ToString());
                DateTime orderDate = DateTime.Parse(reader["order_date"].ToString());
                DateTime shippedDate = DateTime.Parse(reader["shipped_date"].ToString());
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

    public Order GetById(int id)
    {
        Order order = new Order();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM orders where order_id=@orderId";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@orderId",id);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //int orderId = int.Parse(reader["order_id"].ToString());
                DateTime orderDate = DateTime.Parse(reader["order_date"].ToString());
                DateTime shippedDate = DateTime.Parse(reader["shipped_date"].ToString());
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

    public int GetOrderId(int id)
    {
        int orderId = 0;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = $"SELECT MAX(order_id) as order_id from orders where cust_id=@customerId";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@customerId",id);
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

    public bool InsertOrder(int id)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = $"INSERT INTO orders(cust_id)VALUES(@customerId)";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@customerId", id);
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
    public Order GetOrderByCustId(int id)
    {
        Order order = new Order();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM orders where cust_id=@customerId";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@customerId",id);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int orderId = int.Parse(reader["order_id"].ToString());
                DateTime orderDate = DateTime.Parse(reader["order_date"].ToString());
                DateTime shippedDate = DateTime.Parse(reader["shipped_date"].ToString());
                double total = double.Parse(reader["total"].ToString());
                string? status = reader["status"].ToString();

                order = new Order()
                {
                    OrderId = orderId,
                    CustomerId = id,
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
    public bool Insert(Order order)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = $"INSERT INTO orders(order_date,shipped_date,cust_id,total,status)VALUES(@orderDate,@shippedDate,@customerId,@total,@status)";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@orderDate",order.OrderDate);
            command.Parameters.AddWithValue("@shippedDate",order.ShippedDate);
            command.Parameters.AddWithValue("@customerId",order.CustomerId);
            command.Parameters.AddWithValue("@total",order.Total);
            command.Parameters.AddWithValue("@status",order.Status);
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

    public bool Update(Order order)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "Update orders set order_date=@orderDate, shipped_date=@shippedDate,cust_id=@customerId, total =@total, status =@status Where order_id =@orderId";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@orderId",order.OrderId);
            command.Parameters.AddWithValue("@orderDate",order.OrderDate);
            command.Parameters.AddWithValue("@shippedDate",order.ShippedDate);
            command.Parameters.AddWithValue("@customerId",order.CustomerId);
            command.Parameters.AddWithValue("@total",order.Total);
            command.Parameters.AddWithValue("@status",order.Status);
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
    public bool Delete(int id)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "DELETE FROM orders where order_id =@orderId";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@orderId",id);
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

    public List<Order> GetAllCancelled()
    {
        List<Order> orders = new List<Order>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
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
                DateTime orderDate = DateTime.Parse(reader["order_date"].ToString());
                DateTime shippedDate = DateTime.Parse(reader["shipped_date"].ToString());
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


    public List<Order> GetAllDelivered()
    {
        List<Order> orders = new List<Order>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
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
                DateTime orderDate = DateTime.Parse(reader["order_date"].ToString());
                DateTime shippedDate = DateTime.Parse(reader["shipped_date"].ToString());
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