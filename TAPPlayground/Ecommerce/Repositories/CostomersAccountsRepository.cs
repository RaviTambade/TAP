// using ECommerceApp.Models;
// using MySql.Data.MySqlClient;
// using ECommerceApp.Repositories.Interfaces;

// namespace ECommerceApp.Repositories;
// public class CustomersAccountsRepository : ICustomersAccountsRepository
// {
//     public string conString = "server=localhost;port=3306;user=root;password=root;database=Ecommerce";
//     public List<CustomerAccount> GetAllCustomersAccounts()
//     {
//         List<CustomerAccount> Customersaccounts = new List<CustomerAccount>();

//         CustomerAccount customeraccount = new CustomerAccount();

//         MySqlConnection con = new MySqlConnection();
//         con.ConnectionString = conString;
//         try
//         {
//             MySqlCommand command = new MySqlCommand();
//             command.CommandText = "select customers.first_name,customers.last_name,customers.email,customers.contact_number,accounts.account_number,accounts.ifsc_code,accounts.balance FROM customers  INNER JOIN  accounts ON accounts.account_number=customers.account_number ";
//             command.Connection =con;
//             con.Open();
//             MySqlDataReader reader = command.ExecuteReader();
//             while (reader.Read())
//             {
//                 //int id = Int32.Parse(reader["cust_id"].ToString());
//                 string? firstname = reader["first_name"].ToString();
//                 string? lastname = reader["last_name"].ToString();
//                 string? email = reader["email"].ToString();
//                 string? contact = reader["contact_number"].ToString();
//                 long accountNumber =long.Parse(reader["account_number"].ToString());
//                 string? ifscCode = reader["ifsc_code"].ToString();
//                 long? balance =long.Parse( reader["balance"].ToString());



//                 customeraccount = new CustomerAccount
//                 {
//                     // CustomerId=id,
//                     FirstName = firstname,
//                     LastName = lastname,
//                     Email = email,
//                     ContactNumber = contact,
//                     AccountNumber = accountNumber,
//                     IFSCCode = ifscCode,
//                     AccountBalance = balance

//                 };
//                // customeraccount.Add(customeraccount);
//             }
//         }
//         catch (Exception e)
//         {
//             throw e;
//         }
//         finally
//         {
//             con.Close();
//         }
//         return customeraccount;




//     }
// }

