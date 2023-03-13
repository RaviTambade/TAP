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
                    TransactionDate = transactionDate,
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

}
