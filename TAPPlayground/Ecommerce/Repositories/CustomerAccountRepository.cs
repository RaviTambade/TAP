using System.Collections.Generic;
using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace ECommerceApp.Repositories;
public class CustomerAccountRepository : ICustomerAccountRepository
{
    private IConfiguration _configuration;
    private string _conString;

    public CustomerAccountRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

    public List<CustomerAccount> GetAll()
    {
        List<CustomerAccount> customeraccounts = new List<CustomerAccount>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "select customers.cust_id,customers.first_name,customers.last_name,customers.email,customers.contact_number,accounts.account_number,accounts.ifsc_code,accounts.balance FROM customers  INNER JOIN  accounts ON accounts.account_number=customers.account_number";
            MySqlCommand command = new MySqlCommand(query, con);
            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = Int32.Parse(reader["cust_id"].ToString());
                string? firstname = reader["first_name"].ToString();
                string? lastname = reader["last_name"].ToString();
                string? email = reader["email"].ToString();
                string? contact = reader["contact_number"].ToString();
                long accountNumber = long.Parse(reader["account_number"].ToString());
                string? ifscCode = reader["ifsc_code"].ToString();
                double balance = double.Parse(reader["balance"].ToString());
                CustomerAccount customeraccount = new CustomerAccount

                {
                    CustomerId = id,
                    FirstName = firstname,
                    LastName = lastname,
                    Email = email,
                    ContactNumber = contact,
                    AccountNumber = accountNumber,
                    IFSCCode = ifscCode,
                    AccountBalance = balance

                };
                customeraccounts.Add(customeraccount);
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
        return customeraccounts;

    }
}