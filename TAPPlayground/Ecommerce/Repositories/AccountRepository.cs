using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace ECommerceApp.Repositories;

public class AccountRepository : IAccountRepository
{
    public static string conString = "server=localhost;port=3306;user=root;password=password;database=Ecommerce";
    public List<Account> GetAllAccounts()
    {
        List<Account> accounts = new List<Account>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
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
                DateTime registerDate = DateTime.Parse(reader["register_date"].ToString());
                double accountBalance = double.Parse(reader["balance"].ToString());
                Account account = new Account
                {
                    AccountId = accountId,
                    AccountNumber = accountNumber,
                    IFSCCode = ifscCode,
                    RegisterDate = registerDate,
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
        con.ConnectionString = conString;
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
                DateTime registerDate = DateTime.Parse(reader["register_date"].ToString());
                double accountBalance = double.Parse(reader["balance"].ToString());
                account = new Account
                {
                    AccountId = accountId,
                    AccountNumber = accountNumber,
                    IFSCCode = ifscCode,
                    RegisterDate = registerDate,
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
        con.ConnectionString = conString;
        try
        {
            string query = "INSERT INTO accounts(account_number,ifsc_code,register_date,balance) VALUES()";
;
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
        con.ConnectionString = conString;
        try
        {
            string query = $"Update accounts SET account_number ='{account.AccountNumber}',ifsc_code ='{account.IFSCCode}',register_date='{account.RegisterDate}',balance'{account.Balance}' WHERE account_id='{account.AccountId}' ";

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
    public bool DeleteAccount(int id)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "DELETE account WHERE account_id=" + id;
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