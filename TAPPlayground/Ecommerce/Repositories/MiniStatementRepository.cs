using ECommerceApp.Models;
using MySql.Data.MySqlClient;
using ECommerceApp.Repositories.Interfaces;

namespace ECommerceApp.Repositories;

public class MiniStatementRepository : IMiniStatementRepository
{
     public static string conString = "server=localhost;port=3306;user=root;password=Password;database=Ecommerce";
    public List<MiniStatement> GetMiniStatement(int custId)
    {
        List<MiniStatement> miniStatements = new List<MiniStatement>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;
        try
        {
            string query = "SELECT customers.cust_id, customers.first_name, customers.last_name, transactions.amount,transactions.transaction_date,CASE WHEN transactions.from_account_number=customers.account_number THEN 'debit' WHEN transactions.to_account_number=customers.account_number THEN 'credit' END AS MODETYPE FROM transactions,customers WHERE ( transactions.from_account_number=(SELECT account_number FROM customers WHERE cust_id='"+ custId +"') AND customers.cust_id='"+ custId +"') OR  (transactions.to_account_number=(SELECT account_number FROM customers WHERE cust_id='"+ custId +"')  AND customers.cust_id='"+ custId +"')";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = Int32.Parse(reader["cust_id"].ToString());
                string? firstName = reader["first_name"].ToString();
                string? lastName = reader["last_name"].ToString();
                double amount = double.Parse(reader["amount"].ToString());
                DateTime transactionDate = DateTime.Parse(reader["transaction_date"].ToString());
                string modeType = reader["MODETYPE"].ToString();

                MiniStatement miniStatement = new MiniStatement
                {
                    CustomerId = id,
                    CustomerFirstName = firstName,
                    CustomerLastName = lastName,
                    Amount = amount,
                    TransactionDate = transactionDate,
                    ModeType = modeType
                };
                miniStatements.Add(miniStatement);
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
        return miniStatements;
    }
}