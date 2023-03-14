using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace ECommerceApp.Repositories;
public class PaymentRepository : IPaymentRepository
{
      
    public static string conString = "server=localhost;port=3306;user=root;password=Password;database=Ecommerce";

    public List<Payment> GetAllPayments()
    {
        List<Payment> payments = new List<Payment>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;
        try
        {
            string query = "SELECT * FROM payments";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int paymentId =int.Parse(reader["payment_id"].ToString());
                DateTime date= DateTime.Parse(reader["payment_date"].ToString());
                string? payment_mode = reader["payment_mode"].ToString();
                int transactionId =int.Parse(reader["transection_id"].ToString());
                int orderId =int.Parse(reader["order_id"].ToString());

                Payment payment = new Payment
                {
                    PaymentId=paymentId,
                    PaymentDate= date,
                    PaymentMode = payment_mode,
                    TransactionId = transactionId,
                    OrderId = orderId
                };

                payments.Add(payment);
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
        return payments;
    }



    public Payment GetPaymentById(int paymentId)
    {
        Payment payment = new Payment();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;
        try
        {
            string query = "SELECT * FROM payments where payment_id=" + paymentId;
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //paymentId =int.Parse(reader["payment_id"].ToString());
                DateTime date= DateTime.Parse(reader["payment_date"].ToString());
                string? payment_mode = reader["payment_mode"].ToString();
                int transactionId =int.Parse(reader["transection_id"].ToString());
                int orderId =int.Parse(reader["order_id"].ToString());

                payment = new Payment()
                {
                    PaymentId=paymentId,
                    PaymentDate= date,
                    PaymentMode = payment_mode,
                    TransactionId = transactionId,
                    OrderId = orderId
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
            connection.Close();
        }
        return payment;
    }


    public Payment GetPaymentByOrderId(int OrderId)
    {
        Payment payment = new Payment();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;
        try
        {
            string query = "SELECT * FROM payments where order_id=" + OrderId;
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int paymentId =int.Parse(reader["payment_id"].ToString());
                DateTime date= DateTime.Parse(reader["payment_date"].ToString());
                string? payment_mode = reader["payment_mode"].ToString();
                int transactionId =int.Parse(reader["transection_id"].ToString());
                OrderId =int.Parse(reader["order_id"].ToString());

                payment = new Payment()
                {
                    PaymentId=paymentId,
                    PaymentDate= date,
                    PaymentMode = payment_mode,
                    TransactionId = transactionId,
                    OrderId = OrderId
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
            connection.Close();
        }
        return payment;
    }
}



    