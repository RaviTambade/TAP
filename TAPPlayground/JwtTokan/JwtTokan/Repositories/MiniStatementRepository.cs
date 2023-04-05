using ECommerceApp.Models;
using MySql.Data.MySqlClient;
using ECommerceApp.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
namespace ECommerceApp.Repositories;

public class MiniStatementRepository : IMiniStatementRepository
{
    private IConfiguration _configuration;
    private string _conString;
    public MiniStatementRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }
    public List<MiniStatement> GetMiniStatement(int custId)
    {
        List<MiniStatement> miniStatements = new List<MiniStatement>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "SELECT customers.cust_id, customers.first_name, customers.last_name, transactions.amount,transactions.transaction_date,CASE WHEN transactions.from_account_number=customers.account_number THEN 'debit' WHEN transactions.to_account_number=customers.account_number THEN 'credit' END AS MODETYPE FROM transactions,customers WHERE ( transactions.from_account_number=(SELECT account_number FROM customers WHERE cust_id=@customerid) AND customers.cust_id=@customerid) OR  (transactions.to_account_number=(SELECT account_number FROM customers WHERE cust_id=@customerid)  AND customers.cust_id=@customerid";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerid",custId);
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