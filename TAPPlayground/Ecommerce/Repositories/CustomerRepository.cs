using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace ECommerceApp.Repositories;
public class CustomerRepository : ICustomerRepository
{

    public static string conString="server=localhost;port=3306;user=root;password=password;database=Ecommerce";

    public Customer GetCustomer(string contact)
    {
        Customer customer=new Customer();
        MySqlConnection connection=new MySqlConnection(conString);
        try{
            MySqlCommand command=new MySqlCommand();
            command.CommandText=$"SELECT * FROM customers where contact_number='{contact}'";
            command.Connection=connection;
            connection.Open();
           MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                 int id = Int32.Parse(reader["cust_id"].ToString());
                string? firstname = reader["first_name"].ToString();
                string? lastname = reader["last_name"].ToString();
                string? email = reader["email"].ToString();
                

                 customer = new Customer
                {
                   CustomerId=id,
                   FirstName=firstname,
                   LastName=lastname,
                   Email=email,
                   ContactNumber=contact
                };
            
            }
        }
        catch(Exception e){
            throw e;
        }
        finally{
            connection.Close();
        }
      return customer; 

    }

    public bool InsertCustomer(Customer customer){
        bool status=false;
        MySqlConnection connection=new MySqlConnection(conString);
        try{
            MySqlCommand command=new MySqlCommand();
            command.CommandText=$"INSERT INTO customers(first_name,last_name,email,contact_number,password)VALUES('{customer.FirstName}','{customer.LastName}','{customer.Email}','{customer.ContactNumber}','{customer.Password}')";
            command.Connection=connection;
            connection.Open();
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
}