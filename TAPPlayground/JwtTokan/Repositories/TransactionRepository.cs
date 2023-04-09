using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

                       
namespace ECommerceApp.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private IConfiguration _configuration;
    private string _conString;
    public TransactionRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

    public List<Transaction> GetAllTransactions()
    {
        List<Transaction> transactions = new List<Transaction>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
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

    public Transaction GetById(int transactionId)
    {
        Transaction transaction = new Transaction();
        MySqlConnection connection = new MySqlConnection(_conString);
        try
        {
            string query = "SELECT * FROM transactions WHERE transaction_id=@transactionId";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@transactionId",transactionId);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
               int id = int.Parse(reader["transaction_id"].ToString());
                long fromAccountNumber = long.Parse(reader["from_account_number"].ToString());
                long toAccountNumber = long.Parse(reader["to_account_number"].ToString());
                DateTime transactionDate = DateTime.Parse(reader["transaction_date"].ToString());
                double amount = double.Parse(reader["amount"].ToString());

                transaction = new Transaction()
                {
                    TransactionId = id,
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

    public bool Insert(Transaction transaction)
    {
        bool status=false;
        MySqlConnection connection=new MySqlConnection();
        connection.ConnectionString=_conString;
        try{
            string query="INSERT INTO transactions(from_account_number,to_account_number,transaction_date,amount)VALUES(@fromAccountNumber,@toAccountNumber,@transactionDate,@amount)";            
            connection.Open();
            MySqlCommand command=new MySqlCommand(query ,connection);
            command.Parameters.AddWithValue("@fromAccountNumber",transaction.FromAccountNumber);
            command.Parameters.AddWithValue("@toAccountNumber",transaction.ToAccountNumber);
            command.Parameters.AddWithValue("@transactionDate",transaction.TransactionDate);
            command.Parameters.AddWithValue("@amount",transaction.Amount);
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

    public bool Update(Transaction transaction)
    {   
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "UPDATE transactions SET from_account_number=@fromAccountNumber, to_account_number=@toAccountNumber, transaction_date=@transactionDate, amount=@amount WHERE transaction_id=@transactionId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@transactionId",transaction.TransactionId);
            command.Parameters.AddWithValue("@fromAccountNumber",transaction.FromAccountNumber);
            command.Parameters.AddWithValue("@toAccountNumber",transaction.ToAccountNumber);
            command.Parameters.AddWithValue("@transactionDate",transaction.TransactionDate);
            command.Parameters.AddWithValue("@amount",transaction.Amount);
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

    public bool Delete(int transactionId)
    {
       bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "DELETE FROM transactions WHERE transaction_id=@transactionId";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@transactionId",transactionId);
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
