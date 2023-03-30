using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System.Globalization;
using Microsoft.Extensions.Configuration;
namespace ECommerceApp.Repositories;
public class PaymentRepository : IPaymentRepository
{
    private IConfiguration _configuration;

    private string _conString;

    public PaymentRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString= this._configuration.GetConnectionString("DefaultConnection");

    }
      

    

    public List<Payment> GetAllPayments()
    {
        List<Payment> payments = new List<Payment>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM payments";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int paymentId =int.Parse(reader["payment_id"].ToString());
                DateTime paymentDate = DateTime.Parse(reader["payment_date"].ToString());
                string? payment_mode = reader["payment_mode"].ToString();
                int transactionId =int.Parse(reader["transection_id"].ToString());
                int orderId =int.Parse(reader["order_id"].ToString());

                Payment payment = new Payment
                {
                    PaymentId=paymentId,
                    PaymentDate=paymentDate.ToLongDateString(),
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



    public Payment GetPaymentById(int id)
    {
        Payment payment = new Payment();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM payments where payment_id=@paymentId";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@paymentId",id);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //paymentId =int.Parse(reader["payment_id"].ToString());
                DateTime paymentDate = DateTime.Parse(reader["payment_date"].ToString());
                string? payment_mode = reader["payment_mode"].ToString();
                int transactionId =int.Parse(reader["transection_id"].ToString());
                int orderId =int.Parse(reader["order_id"].ToString());

                payment = new Payment()
                {
                    PaymentId=id,
                    PaymentDate=paymentDate.ToLongDateString(),
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


    public Payment GetPaymentByOrderId(int id)
    {
        Payment payment = new Payment();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM payments where order_id=@orderId";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("orderId",id);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int paymentId =int.Parse(reader["payment_id"].ToString());
                DateTime date = DateTime.Parse(reader["payment_date"].ToString(), CultureInfo.InvariantCulture);
                string? payment_mode = reader["payment_mode"].ToString();
                int transactionId =int.Parse(reader["transection_id"].ToString());
                int OrderId =int.Parse(reader["order_id"].ToString());

                payment = new Payment()
                {
                    PaymentId=paymentId,
                    PaymentDate= date.ToShortDateString(),
                    PaymentMode = payment_mode,
                    TransactionId = transactionId,
                    OrderId = id
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



    public  bool InsertPayments(Payment payment){
          bool status = false;
          MySqlConnection con = new MySqlConnection();
          con.ConnectionString=_conString;
          try{
            string query = $"INSERT INTO payments(payment_date,payment_mode,transection_id,order_id) VALUES(@paymentDate,@paymentMode,@transactionId,@orderId)";
            Console.WriteLine(query);
             MySqlCommand cmd=new MySqlCommand(query,con) ;
            cmd.Parameters.AddWithValue("@paymentDate",payment.PaymentDate);
            cmd.Parameters.AddWithValue("@paymentMode",payment.PaymentMode);
            cmd.Parameters.AddWithValue("@transactionId",payment.TransactionId);
            cmd.Parameters.AddWithValue("@orderId",payment.OrderId);
             con.Open();
             cmd.ExecuteNonQuery();               
           status=true;
          }catch(Exception e )
          {
            throw e;
          }
          finally {
            con.Close();
          }
          return status;
   }
   
   public  bool UpdatePayment(Payment payment){
          bool status = false;
          MySqlConnection con = new MySqlConnection();
          con.ConnectionString=_conString;
          try{
            
            string query = "UPDATE payments set payment_date= @paymentDate,transection_id=@transactionId,order_id=@orderId where payment_id=@paymentId";
            MySqlCommand cmd=new MySqlCommand(query,con) ;
            cmd.Parameters.AddWithValue("@paymentDate",payment.PaymentDate);
            cmd.Parameters.AddWithValue("@paymentMode",payment.PaymentMode);
            cmd.Parameters.AddWithValue("@transactionId",payment.TransactionId);
            cmd.Parameters.AddWithValue("@orderId",payment.OrderId);
            cmd.Parameters.AddWithValue("@paymentId",payment.PaymentId);
            con.Open();
            int rowsAffected=cmd.ExecuteNonQuery();               
             if(rowsAffected>0){
             status=true;
             }
             
          }catch(Exception e )
          {
            throw e;
          }
          finally {
            con.Close();
          }
          return status;
   }
   
   public  bool DeletePayment(int id){
          bool status = false;
          MySqlConnection con = new MySqlConnection();
          con.ConnectionString=_conString;
          try{
            
            string query = "DELETE FROM payments WHERE payment_id=@paymentId";
             MySqlCommand cmd=new MySqlCommand(query,con) ;
             cmd.Parameters.AddWithValue("@paymentId",id);
             con.Open();
             cmd.ExecuteNonQuery();              
           status=true;
          }catch(Exception e )
          {
            throw e;
          }
          finally {
            con.Close();
          }
          return status;
   }





}



    