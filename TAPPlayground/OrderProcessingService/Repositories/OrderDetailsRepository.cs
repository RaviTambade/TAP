using OrderProcessingService.Models;
using OrderProcessingService.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data;
namespace OrderProcessingService.Repositories;
public class OrderDetailsRepository : IOrderDetailsRepository
{
    private IConfiguration _configuration;
    private string _conString;
    public OrderDetailsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }
    public async Task<IEnumerable<OrderDetails>> GetAll()
    {
        await Task.Delay(3000);
        List<OrderDetails> orderDetails = new List<OrderDetails>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "select * from orderdetails";
            MySqlCommand command = new MySqlCommand(query, con);
            await con.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int id = Int32.Parse(reader["orderdetails_id"].ToString());
                int orderId = Int32.Parse(reader["order_id"].ToString());
                int productId = Int32.Parse(reader["product_id"].ToString());
                int quantity = Int32.Parse(reader["quantity"].ToString());
                double discount = double.Parse(reader["discount"].ToString());

                OrderDetails orderDetail = new OrderDetails()
                {
                    OrderDetailsId = id,
                    OrderId = orderId,
                    ProductId = productId,
                    Quantity = quantity,
                    Discount = discount
                };
                orderDetails.Add(orderDetail);
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
        return orderDetails;
    }

    public async Task<OrderDetails> GetById(int orderDetailsId)
    {
        OrderDetails orderDetail = new OrderDetails();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "select * from orderdetails where orderdetails_id=@orderDetailsId";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@orderDetailsId", orderDetailsId);
            await con.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            if (await reader.ReadAsync())
            {
                int orderId = Int32.Parse(reader["order_id"].ToString());
                int productId = Int32.Parse(reader["product_id"].ToString());
                int quantity = Int32.Parse(reader["quantity"].ToString());
                double discount = double.Parse(reader["discount"].ToString());
                orderDetail = new OrderDetails()
                {
                    OrderDetailsId = orderDetailsId,
                    OrderId = orderId,
                    ProductId = productId,
                    Quantity = quantity,
                    Discount = discount
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
        return orderDetail;
    }

    public async Task<IEnumerable<OrderDetailsOrder>> GetOrderDetailsByOrder(int orderId)
    {
        List<OrderDetailsOrder> products = new List<OrderDetailsOrder>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT orderdetails.order_id,products.product_title,products.unit_price, orderdetails.quantity ," +
                          " (products.unit_price*orderdetails.quantity) AS total_amount FROM orderdetails, products " +
                          " WHERE  products.product_id =orderdetails.product_id AND order_id=@orderId";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@orderId", orderId);
            await con.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();

            while (await reader.ReadAsync())
            {
                string prodctTitle = reader["product_title"].ToString();
                int quantity = Int32.Parse(reader["quantity"].ToString());
                double unitPrice = double.Parse(reader["unit_price"].ToString());
                double totalAmount = double.Parse(reader["total_amount"].ToString());

                OrderDetailsOrder product = new OrderDetailsOrder()
                {
                    OrderId = orderId,
                    ProductTitle = prodctTitle,
                    Quantity = quantity,
                    //UnitPrice=unitPrice,
                    TotalAmount = totalAmount
                };
                products.Add(product);
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
        return products;
    }

    public async Task<bool> Insert(OrderDetails orderDetails)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "INSERT INTO orderdetails(order_id,product_id,quantity,discount)VALUES(@orderId,@productId,@quantity,@discount)";
            Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@orderId", orderDetails.OrderId);
            command.Parameters.AddWithValue("@productId", orderDetails.ProductId);
            command.Parameters.AddWithValue("@quantity", orderDetails.Quantity);
            command.Parameters.AddWithValue("@discount", orderDetails.Discount);
            await con.OpenAsync();
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                status = true;
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
        return status;
    }

    public async Task<bool> Update(OrderDetails orderDetails)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "Update orderdetails SET order_id=@orderId,product_id =@productId,quantity =@quantity,discount=@discount WHERE orderdetails_id=@orderDetailsId ";
            Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@orderDetailsId", orderDetails.OrderDetailsId);
            command.Parameters.AddWithValue("@orderId", orderDetails.OrderId);
            command.Parameters.AddWithValue("@productId", orderDetails.ProductId);
            command.Parameters.AddWithValue("@quantity", orderDetails.Quantity);
            command.Parameters.AddWithValue("@discount", orderDetails.Discount);
            await con.OpenAsync();
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                status = true;
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
        return status;
    }
    public async Task<bool> DeleteByOrderDetailsId(int orderDetailsId)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "DELETE FROM orderdetails WHERE orderdetails_id=@orderDetailsId";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@orderDetailsId", orderDetailsId);
            await con.OpenAsync();
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                status = true;
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
        return status;
    }

    public async Task<IEnumerable<OrderHistory>> GetOrderHistory(int customerId)
    {
        List<OrderHistory> orderHistories = new List<OrderHistory>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = $"SELECT products.product_id,products.product_title , products.unit_price, orderdetails.quantity,customers.cust_id,orders.order_id,orders.order_date FROM products,customers, orders INNER JOIN orderdetails on orderdetails.order_id=orders.order_id WHERE  products.product_id=orderdetails.product_id AND customers.cust_id=orders.cust_id AND customers.cust_id=@customerId order by orders.order_id;";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@customerId", customerId);
            await con.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int productId=int.Parse(reader["product_id"].ToString());
                string? title = reader["product_title"].ToString();
                double unitPrice = double.Parse(reader["unit_price"].ToString());
                int quantity = int.Parse(reader["quantity"].ToString());
                DateTime date = Convert.ToDateTime(reader["order_date"].ToString());
                OrderHistory orderhistory = new OrderHistory
                {
                    ProductId=productId,
                    Title = title,
                    UnitPrice = unitPrice,
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
            con.Close();
        }
        return orderHistories;
    }
}