using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace ECommerceApp.Repositories;

public class TransactionRepository : ITransactionRepository
{
    public static string conString="server=localhost;port=3306;user=root;password=Rohit@7378;database=Ecommerce";

    public List<Transaction> GetAllTransaction()
    {
        List<Transaction> transactions = new List<Transaction>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;
        try
        {
            string query = "SELECT * FROM transactions";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = int.Parse(reader["transaction_id"].ToString());
                long fromAccountNumber = long.Parse(reader["from_account_number"].ToString());
                long toAccountNumber = long.Parse(reader["to_account_number"].ToString());
                DateTime transactionDate = DateTime.Parse(reader["transaction_date"].ToString());
                double amount = double.Parse(reader["amount"].ToString());

                Transaction transaction = new Transaction
                {
                    TransactionId = id,
                    FromAccountNumber = fromAccountNumber,
                    ToAccountNumber = toAccountNumber,
                    TransactionDate = transactionDate.ToShortDateString(),
                    Amount = amount
                };
                transactions.Add(transaction);
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
        return transactions;
    }

    public Transaction GetTransactionById(int id)
    {
        Transaction transaction = new Transaction();
        MySqlConnection connection = new MySqlConnection(conString);
        try
        {
            string query = "SELECT * FROM transactions WHERE transaction_id=" + id;
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
               int transactionId = int.Parse(reader["transaction_id"].ToString());
                long fromAccountNumber = long.Parse(reader["from_account_number"].ToString());
                long toAccountNumber = long.Parse(reader["to_account_number"].ToString());
                DateTime transactionDate = DateTime.Parse(reader["transaction_date"].ToString());
                double amount = double.Parse(reader["amount"].ToString());

                transaction = new Transaction()
                {
                    TransactionId = transactionId,
                    FromAccountNumber = fromAccountNumber,
                    ToAccountNumber = toAccountNumber,
                    TransactionDate = transactionDate.ToShortDateString(),
                    Amount = amount
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
        return transaction;
    }

    public bool InsertTransaction(Transaction transaction)
    {
        Console.WriteLine("Printing emp Object");
        Console.WriteLine(transaction.FromAccountNumber);
        Console.WriteLine(transaction.ToAccountNumber);
        Console.WriteLine(transaction.TransactionDate);
        Console.WriteLine(transaction.Amount);
        bool status=false;
        MySqlConnection connection=new MySqlConnection();
        connection.ConnectionString=conString;
        try{
            string query=$"INSERT INTO transactions(from_account_number,to_account_number,transaction_date,amount)VALUES"+
                        "('"+transaction.FromAccountNumber+"','"+ transaction.ToAccountNumber+ "','" +transaction.TransactionDate + "'," + transaction.Amount+")";
            Console.WriteLine(query);            
            connection.Open();
            MySqlCommand command=new MySqlCommand(query ,connection);
            command.ExecuteNonQuery();
            status=true;
        }
        catch(Exception e){
             throw e;
        }
        finally{
          connection.Close();
        }
        return status;
    }

    public bool UpdateTransaction(Transaction transaction)
    {   
        Console.WriteLine(transaction.Amount);
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;
        try
        {
            string query = "UPDATE transactions SET from_account_number='" + transaction.FromAccountNumber + "', to_account_number='" + transaction.ToAccountNumber + "', transaction_date='" + transaction.TransactionDate +"', amount='" + transaction.Amount +"' WHERE transaction_id=" +transaction.TransactionId;
            Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            status = true;
        }
        catch (Exception e)
        {
            throw e;

        }
        finally
        {
            connection.Close();
        }
        return status;
    }

      public bool DeleteTransaction(int id)
    {
       bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "DELETE FROM transactions WHERE transaction_id="+id;
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
