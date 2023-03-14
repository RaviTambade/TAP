using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
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
            string query = $"SELECT * FROM orders";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                int id = int.Parse(reader["order_id"].ToString());
                DateTime orderDate= DateTime.Parse(reader["order_date"].ToString());
                DateTime shippedDate =DateTime.Parse(reader["shipped_date"].ToString());
                int customerId = int.Parse(reader["cust_Id"].ToString());
                double total = double.Parse(reader["total"].ToString());
                string? status = reader["status"].ToString();

                Order order = new Order()
                {
                    OrderId = id,
                    OrderDate = orderDate,
                    ShippedDate = shippedDate,
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
            string query = "SELECT * FROM orders where order_id=" +id;
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                //int orderId = int.Parse(reader["order_id"].ToString());
                DateTime orderDate= DateTime.Parse(reader["order_date"].ToString());
                DateTime shippedDate =DateTime.Parse(reader["shipped_date"].ToString());
                int customerId = int.Parse(reader["cust_Id"].ToString());
                double total = double.Parse(reader["total"].ToString());
                string? status = reader["status"].ToString();

                order = new Order()
                {
                    OrderId = id,
                    OrderDate = orderDate,
                    ShippedDate = shippedDate,
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
            string query = "SELECT * FROM orders where cust_id=" +custid;
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                int orderId = int.Parse(reader["order_id"].ToString());
                DateTime orderDate= DateTime.Parse(reader["order_date"].ToString());
                DateTime shippedDate =DateTime.Parse(reader["shipped_date"].ToString());
                double total = double.Parse(reader["total"].ToString());
                string? status = reader["status"].ToString();

                order = new Order()
                {
                    OrderId = orderId,
                    CustomerId= custid,
                    OrderDate = orderDate,
                    ShippedDate = shippedDate,
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
            string query ="INSERT INTO orders(order_id,order_date,shipped_date,cust_id,total,status)"
            + "VALUES('"+order.OrderId+"','"+order.OrderDate+"','"+order.ShippedDate+"','"+order.CustomerId+"','"+order.Total+"','"+order.Status+"')";
            con.Open();
            MySqlCommand command = new MySqlCommand(query,con);
            command.ExecuteNonQuery();
            status = true;
        }
        catch(Exception e)
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
            string query ="Update orders set order_date='"+order.OrderDate+"', shipped_date='"+order.ShippedDate+"',cust_id='"+order.CustomerId+"', total ='"+order.Total+"', status ='"+order.Status+"' Where order_id =" +order.OrderId;
            con.Open();
            MySqlCommand command = new MySqlCommand(query,con);
            command.ExecuteNonQuery();
            status = true;
        }
        catch(Exception e)
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
            string query ="DELETE FROM orders where order_id =" +id;
            con.Open();
            MySqlCommand command = new MySqlCommand(query,con);
            command.ExecuteNonQuery();
            status = true;
        }
        catch(Exception e)
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