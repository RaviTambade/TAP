using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace ECommerceApp.Repositories;
public class CustomerRepository : ICustomerRepository
{

    private IConfiguration _configuration;
    private string _conString;

    public CustomerRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

    public List<Customer> GetAll(){

        List<Customer> customers=new List<Customer>();

        Customer customer=new Customer();
        MySqlConnection connection=new MySqlConnection(_conString);
        try{
            MySqlCommand command=new MySqlCommand();
            command.CommandText=$"SELECT * FROM customers";
            command.Connection=connection;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                 int id = Int32.Parse(reader["cust_id"].ToString());
                string? firstname = reader["first_name"].ToString();
                string? lastname = reader["last_name"].ToString();
                string? email = reader["email"].ToString();
                string? contact=reader["contact_number"].ToString();
                long accountnumber= long.Parse(reader["account_number"].ToString());
                string password= reader["password"].ToString();
                customer = new Customer
                {
                   CustomerId=id,
                   FirstName=firstname,
                   LastName=lastname,
                   Email=email,
                   ContactNumber=contact,
                   AccountNumber=accountnumber,
                   Password= password  
                };
                customers.Add(customer);
            }
        }
        catch(Exception e){
            throw e;
        }
        finally{
            connection.Close();
        }
      return customers; 


    }

    public Customer GetByContactNumber(string contact)
    {
        Customer customer=new Customer();
        MySqlConnection connection=new MySqlConnection(_conString);
        try{
            MySqlCommand command=new MySqlCommand();
            command.CommandText=$"SELECT * FROM customers where contact_number=@contact";
            command.Connection=connection;
            command.Parameters.AddWithValue("@contactNumber",contact);
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


    public Customer GetById(int custId)
    {
        Customer customer=new Customer();
        MySqlConnection connection=new MySqlConnection(_conString);
        try{
            MySqlCommand command=new MySqlCommand();
            command.CommandText=$"SELECT * FROM customers where cust_id=@customerId";
            command.Connection=connection;
            command.Parameters.AddWithValue("@customerId",custId);
            connection.Open();
           MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int id = Int32.Parse(reader["cust_id"].ToString());
                string? firstname = reader["first_name"].ToString();
                string? lastname = reader["last_name"].ToString();
                string? email = reader["email"].ToString();
                string? contact=reader["contact_number"].ToString();
                long accountnumber = long.Parse(reader["account_number"].ToString());
                string password = reader["password"].ToString();

                customer = new Customer
                {
                   CustomerId=id,
                   FirstName=firstname,
                   LastName=lastname,
                   Email=email,
                   ContactNumber=contact,
                   AccountNumber=accountnumber,
                   Password=password   
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

    public bool Insert(Customer customer){
        bool status=false;
        MySqlConnection connection=new MySqlConnection(_conString);
        try{
            MySqlCommand command=new MySqlCommand();
            command.CommandText=$"INSERT INTO customers(first_name,last_name,email,contact_number,password,account_number)VALUES(@firstName,@lastName,@email,@contactNumber,@password,@accountNumber)";
        Console.WriteLine(customer.ToString());
           Console.WriteLine(command.CommandText);
            command.Connection=connection;
            command.Parameters.AddWithValue("@firstName",customer.FirstName);
            command.Parameters.AddWithValue("@lastName",customer.LastName);
            command.Parameters.AddWithValue("@email",customer.Email);
            command.Parameters.AddWithValue("@contactNumber",customer.ContactNumber);
            command.Parameters.AddWithValue("@password",customer.Password);
            command.Parameters.AddWithValue("@accountNumber",customer.AccountNumber);
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

       public  bool Update(Customer customer){
          bool status = false;
          MySqlConnection con = new MySqlConnection();
          con.ConnectionString=_conString;
        try{
            
            string query = $"Update customers SET first_name =@firstName,last_name =@lastName,email=@email,contact_number=@contactNumber,password =@password,account_number=@accountNumber WHERE cust_id=@customerId ";
            Console.WriteLine(query);
            MySqlCommand cmd=new MySqlCommand(query,con);
            cmd.Parameters.AddWithValue("@customerId",customer.CustomerId);
            cmd.Parameters.AddWithValue("@firstName",customer.FirstName);
            cmd.Parameters.AddWithValue("@lastName",customer.LastName);
            cmd.Parameters.AddWithValue("@email",customer.Email);
            cmd.Parameters.AddWithValue("@contactNumber",customer.ContactNumber);
            cmd.Parameters.AddWithValue("@password",customer.Password);
            cmd.Parameters.AddWithValue("@accountNumber",customer.AccountNumber);
            con.Open();
            cmd.ExecuteNonQuery();               
            status=true;
          }
        catch(Exception e )
          {
            throw e;
          }
          finally {
            con.Close();
          }
          return status;
   }
   
   public  bool Delete(int customerId){
          bool status = false;
          MySqlConnection con = new MySqlConnection();
          con.ConnectionString=_conString;
          try{
            
            string query = "DELETE FROM customers WHERE cust_id=@customerId";
            MySqlCommand cmd=new MySqlCommand(query,con) ;
            cmd.Parameters.AddWithValue("@customerId",customerId);
            con.Open();
            cmd.ExecuteNonQuery();  
            status=true;            

          }catch(Exception e )
          {
            throw e;
          }
          finally {
            con.Close();
          }
          return status;
   }

}