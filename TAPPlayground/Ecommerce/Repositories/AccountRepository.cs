using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System.Globalization;

using Microsoft.Extensions.Configuration;

namespace ECommerceApp.Repositories;
public class AccountRepository : IAccountRepository
{
    
    private IConfiguration _configuration;
    private string _conString;
  
    public AccountRepository(IConfiguration configuration){
        _configuration=configuration;
        _conString= this._configuration.GetConnectionString("DefaultConnection");
    }
  public List<Account> GetAllAccounts()
    {
        List<Account> accounts = new List<Account>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM accounts";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                int accountId = int.Parse(reader["account_id"].ToString());
                long accountNumber = long.Parse(reader["account_number"].ToString());
                string ifscCode = reader["ifsc_code"].ToString();
                DateTime registerDate = DateTime.ParseExact(reader["register_date"].ToString(),"dd-MM-yyyy HH:mm:ss",CultureInfo.InvariantCulture);
                double accountBalance = double.Parse(reader["balance"].ToString());
                Account account = new Account
                {
                    AccountId = accountId,
                    AccountNumber = accountNumber,
                    IFSCCode = ifscCode,
                    RegisterDate = registerDate.ToLongDateString(),
                    Balance = accountBalance
                };
                accounts.Add(account);
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
        return accounts;
    }

    public Account GetAccountById(int id)
    {
        Account account = new Account();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM accounts where account_Id =" + id;
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {

                int accountId = int.Parse(reader["account_id"].ToString());
                long accountNumber = long.Parse(reader["account_number"].ToString());
                string ifscCode = reader["ifsc_code"].ToString();
                DateTime registerDate = DateTime.Parse(reader["register_date"].ToString(),System.Globalization.CultureInfo.InvariantCulture);
                double accountBalance = double.Parse(reader["balance"].ToString());
                account = new Account
                {
                    AccountId = accountId,
                    AccountNumber = accountNumber,
                    IFSCCode = ifscCode,
                    RegisterDate = registerDate.ToLongDateString(),
                    Balance = accountBalance
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
        return account;
    }

    public bool InsertAccount(Account account)
    {

        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES('"+account.AccountNumber+"','"+account.IFSCCode+ "','"+ account.RegisterDate+ "','"+ account.Balance+"')";

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
    public bool UpdateAccount(Account account)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "Update accounts SET account_number ='"+account.AccountNumber+"',ifsc_code ='"+account.IFSCCode+"',register_date='"+account.RegisterDate+"',balance='"+account.Balance+"' WHERE account_id='"+account.AccountId+"'";
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
    public bool DeleteAccount(Int32 id)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "DELETE  FROM accounts WHERE account_id=" + id;
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
