using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace ECommerceApp.Repositories;
public class OrderDetailsRepository : IOrderDetailsRepository
{

    private IConfiguration _configuration;
    private string _conString;

    public OrderDetailsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }
    public List<OrderDetails> AllOrderDetails()
    {
        List<OrderDetails> orderDetails = new List<OrderDetails>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "select * from orderdetails";
            MySqlCommand command = new MySqlCommand(query, con);
            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = Int32.Parse(reader["orderdetails_id"].ToString());
                int orderId = Int32.Parse(reader["order_id"].ToString());
                int productId = Int32.Parse(reader["product_id"].ToString());
                int supplierId = Int32.Parse(reader["supplier_id"].ToString());
                int quantity = Int32.Parse(reader["quantity"].ToString());
                double discount = double.Parse(reader["discount"].ToString());

                OrderDetails orderDetail = new OrderDetails()
                {
                    OrderDetailsId = id,
                    OrderId = orderId,
                    ProductId = productId,
                    SupplierId = supplierId,
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

    public OrderDetails GetById(int id)
    {
        OrderDetails orderDetail = new OrderDetails();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "select * from orderdetails where orderdetails_id=@orderDetailsId";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@orderDetailsId", id);
            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int orderDetailsId = Int32.Parse(reader["orderdetails_id"].ToString());
                int orderId = Int32.Parse(reader["order_id"].ToString());
                int productId = Int32.Parse(reader["product_id"].ToString());
                int supplierId = Int32.Parse(reader["supplier_id"].ToString());
                int quantity = Int32.Parse(reader["quantity"].ToString());
                double discount = double.Parse(reader["discount"].ToString());

                orderDetail = new OrderDetails()
                {
                    OrderDetailsId = orderDetailsId,
                    OrderId = orderId,
                    ProductId = productId,
                    SupplierId = supplierId,
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





    public List<OrderDetailsOrder> GetProductsOfOrder(int orderId)
    {
        List<OrderDetailsOrder> products = new List<OrderDetailsOrder>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT orderdetails.order_id,products.product_title, orderdetails.quantity ," +
                          " (products.unit_price*orderdetails.quantity) AS total_amount FROM orderdetails, products " +
                          " WHERE  products.product_id =orderdetails.product_id AND order_id=@orderId";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@orderId", orderId);
            con.Open();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string prodctTitle = reader["product_title"].ToString();
                int quantity = Int32.Parse(reader["quantity"].ToString());
                double totalAmount = double.Parse(reader["total_amount"].ToString());

                OrderDetailsOrder product = new OrderDetailsOrder()
                {
                    OrderId = orderId,
                    ProductTitle = prodctTitle,
                    Quantity = quantity,
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


    public bool Insert(OrderDetails orderDetails)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "INSERT INTO orderdetails(order_id,product_id,quantity,discount,supplier_id)VALUES(@orderId,@productId,@quantity,@discount,@supplierId)";
            Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@orderId", orderDetails.OrderId);
            command.Parameters.AddWithValue("@productId", orderDetails.ProductId);
            command.Parameters.AddWithValue("@quantity", orderDetails.Quantity);
            command.Parameters.AddWithValue("@discount", orderDetails.Discount);
            command.Parameters.AddWithValue("@supplierId", orderDetails.SupplierId);
            con.Open();
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

    public bool Update(OrderDetails orderDetails)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "Update orderdetails SET order_id=@orderId,product_id =@productId,quantity =@quantity,discount=@discount,supplier_id=@supplierId WHERE orderdetails_id=@orderDetailsId ";
            Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@orderDetailsId", orderDetails.OrderDetailsId);
            command.Parameters.AddWithValue("@orderId", orderDetails.OrderId);
            command.Parameters.AddWithValue("@productId", orderDetails.ProductId);
            command.Parameters.AddWithValue("@quantity", orderDetails.Quantity);
            command.Parameters.AddWithValue("@discount", orderDetails.Discount);
            command.Parameters.AddWithValue("@supplierId", orderDetails.SupplierId);
            con.Open();
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

    public bool Delete(int id)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "DELETE FROM orderdetails WHERE orderdetails_id=@orderDetailsId";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@orderDetailsId", id);
            con.Open();
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

<<<<<<< HEAD
    public bool InsertOrderdetails(int orderId, int productId, int quantity)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetOrderdProducts(int orderId)
    {
        throw new NotImplementedException();
    }

    public List<OrderHistory> OrderHistory(int customerId)
    {
        throw new NotImplementedException();
    }

    //     public List<Product> GetOrderdProducts(int orderId)
    //     {
    //         List<Product> products = new List<Product>();
    //         MySqlConnection connection = new MySqlConnection();
    //         connection.ConnectionString = conString;
    //         try
    //         {
    //             string query = $"SELECT orderdetails.product_id,products.title,products.description,products.unit_price," +
    //                             "products.image,orderdetails.order_id,orderdetails.quantity," +
    //                             "(products.unit_price*orderdetails.quantity) as totalprice from products INNER JOIN " +
    //                             "orderdetails ON products.product_id = orderdetails.product_id " +
    //                             "WHERE orderdetails.order_id=" + orderId;
    //             connection.Open();
    //             MySqlCommand command = new MySqlCommand(query, connection);
    //             MySqlDataReader reader = command.ExecuteReader();
    //             while (reader.Read())
    //             {
    //                 int id = Int32.Parse(reader["product_id"].ToString());
    //                 string? title = reader["title"].ToString();
    //                 string? description = reader["description"].ToString();
    //                 double price = double.Parse(reader["unit_price"].ToString());
    //                 string? imgUrl = reader["image"].ToString();
    //                 int quantity = Int32.Parse(reader["quantity"].ToString());
    //                 double totalprice = double.Parse(reader["totalprice"].ToString());

    //                 Product product = new Product
    //                 {
    //                     ProductId = id,
    //                     Title = title,
    //                     Description = description,
    //                     UnitPrice = price,
    //                     ImageUrl = imgUrl,
    //                     BuyQuantity = quantity
    //                 };

    //                 products.Add(product);
    //             }
    //             reader.Close();
    //         }
    //         catch (Exception e)
    //         {
    //             throw e;
    //         }
    //         finally
    //         {
    //             connection.Close();
    //         }
    //         return products;
    //     }

    //     public List<OrderHistory> OrderHistory(int customerId)
    //     {
    //         List<OrderHistory> orderHistories = new List<OrderHistory>();
    //         MySqlConnection connection = new MySqlConnection();
    //         connection.ConnectionString = conString;
    //         try
    //         {
    //             string query = $"SELECT products.product_id,products.title , products.unit_price, orderdetails.quantity,customers.cust_id,orders.order_id,orders.order_date FROM products,customers, orders INNER JOIN orderdetails on orderdetails.order_id=orders.order_id WHERE  products.product_id=orderdetails.product_id AND customers.cust_id=orders.cust_id AND customers.cust_id={customerId} order by orders.order_id;";
    //             connection.Open();
    //             MySqlCommand command = new MySqlCommand(query, connection);
    //             MySqlDataReader reader = command.ExecuteReader();
    //             while (reader.Read())
    //             {
    //                 string? title = reader["title"].ToString();
    //                 double unitprice = double.Parse(reader["unit_price"].ToString());
    //                 int quantity = int.Parse(reader["quantity"].ToString());
    //                 DateTime date = DateTime.Parse(reader["order_date"].ToString());

    //                 OrderHistory orderhistory = new OrderHistory
    //                 {
    //                     Title = title,
    //                     UnitPrice = unitprice,
    //                     Quantity = quantity,
    //                     OrderDate = date
    //                 };
    //                 orderHistories.Add(orderhistory);
    //             }
    //         }
    //         catch (Exception e)
    //         {
    //             throw e;
    //         }
    //         finally
    //         {
    //             connection.Close();
    //         }
    //         return orderHistories;
    //     }

    //     public bool InsertOrderdetails(int orderId, int productId, int quantity)
    //     {
    //         throw new NotImplementedException();
    //     }
    // }
=======
    public List<OrderHistory> OrderHistory(int customerId)
    {
        List<OrderHistory> orderHistories = new List<OrderHistory>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = $"SELECT products.product_id,products.product_title , products.unit_price, orderdetails.quantity,customers.cust_id,orders.order_id,orders.order_date FROM products,customers, orders INNER JOIN orderdetails on orderdetails.order_id=orders.order_id WHERE  products.product_id=orderdetails.product_id AND customers.cust_id=orders.cust_id AND customers.cust_id=@customerId order by orders.order_id;";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@customerId", customerId);
            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string? title = reader["product_title"].ToString();
                double unitprice = double.Parse(reader["unit_price"].ToString());
                int quantity = int.Parse(reader["quantity"].ToString());
                DateTime date = DateTime.Parse(reader["order_date"].ToString());
>>>>>>> 59118d049f910a1baf76fb7d83c45096983c86b4

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
            con.Close();
        }
        return orderHistories;
    }
}
