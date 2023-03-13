using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using  MySql.Data.MySqlClient;

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
                string accountNumber = (reader["account_number"].ToString());
                string ifcCode = (reader["ifsc_code"].ToString());
                DateTime registerDate = DateTime.Parse(reader["register_date"].ToString());
                double accountBalance = double.Parse(reader["balance"].ToString());
                Account account = new Account
                {
                    AccountId = accountId,
                    AccountNumber = accountNumber,
                    IFCCode = ifcCode,
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
        Account account= new Account();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "SELECT * FROM accounts where account_Id ="+id;
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {

                int accountId = int.Parse(reader["account_id"].ToString());
                string accountNumber = (reader["account_number"].ToString());
                string ifcCode = (reader["ifsc_code"].ToString());
                DateTime registerDate = DateTime.Parse(reader["register_date"].ToString());
                double accountBalance = double.Parse(reader["balance"].ToString());
                 account = new Account
                {
                    AccountId = accountId,
                    AccountNumber = accountNumber,
                    IFCCode = ifcCode,
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


}

