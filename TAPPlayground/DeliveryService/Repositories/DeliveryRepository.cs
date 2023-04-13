using DeliveryService.Models;
using DeliveryService.Repositories.Interfaces;
using MySql.Data.MySqlClient;

using Microsoft.Extensions.Configuration;  // set namespace 
namespace DeliveryService.Repositories;
public class DeliveryRepository : IDeliveryRepository
{

    //IConfiguration interface help us to 
    //read settings available in appsettings.json file
    
    private readonly IConfiguration _configuration;
    private readonly string _conString;
  
    //Parameterized Constructor
    public DeliveryRepository(IConfiguration configuration){
        _configuration=configuration;
        _conString= this._configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<Delivery>>  GetAll()
    {
        await Task.Delay(10000);
        List<Delivery> deliveries = new List<Delivery>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM shippers";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                    int id = int.Parse(reader["shipper_id"].ToString());
                    string? companyName = reader["company_name"].ToString();
                    string? email = reader["email"].ToString();
                    string? contactNumber = reader["contact_number"].ToString();
                    string? password = reader["password"].ToString();
                    long accountNo = long.Parse(reader["account_number"].ToString());

                Delivery delivery = new Delivery
                {
                    ShipperId = id,
                    CompanyName = companyName,
                    ContactNumber = contactNumber,
                    Email = email,
                    Password=password,
                    AccountNumber = accountNo
                };
                deliveries.Add(delivery);
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
        return deliveries;
    }
    

    public async Task<Delivery>  GetById(int id)
    {
        Delivery delivery = new Delivery();
        MySqlConnection connection = new MySqlConnection(_conString);
        try
        {
            string query = "SELECT * FROM shippers WHERE shipper_id= @shipperId";
            await connection.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@shipperId", id);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                    id = int.Parse(reader["shipper_id"].ToString());
                    string companyName = reader["company_name"].ToString();
                    string contactNumber = reader["contact_number"].ToString();
                    string email = reader["email"].ToString();
                    string? password = reader["password"].ToString();
                    long accountNumber = long.Parse(reader["account_number"].ToString());

                delivery = new Delivery()
                {
                    ShipperId = id,
                    CompanyName = companyName,
                    ContactNumber = contactNumber,
                    Email = email,
                    Password=password,
                    AccountNumber = accountNumber
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
            connection.Close();
        }
        return delivery;
    }


   public async Task<bool>  Insert(Delivery delivery){
        bool status=false;
        MySqlConnection connection=new MySqlConnection();
        connection.ConnectionString=_conString;
        try{
            string query=$"INSERT INTO shippers(company_name,contact_number,email,password,account_number)VALUES(@companyName, @contactNumber,@email,@password, @accountNumber)";
            Console.WriteLine(query);
          
            MySqlCommand command=new MySqlCommand(query ,connection);
            command.Parameters.AddWithValue("@companyName",delivery.CompanyName);
            command.Parameters.AddWithValue("@contactNumber",delivery.ContactNumber);
            command.Parameters.AddWithValue("@email",delivery.Email);
            command.Parameters.AddWithValue("@password",delivery.Password);
            command.Parameters.AddWithValue("@accountNumber",delivery.AccountNumber);
             await connection.OpenAsync();
              int rowsAffected=command.ExecuteNonQuery();
            if(rowsAffected >0){
             status=true;
            }
          }
        catch(Exception e){
             throw e;
        }
        finally{
          connection.Close();
        }
        return status;
    }

 public async Task<bool> Update(Delivery delivery)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "UPDATE shippers SET company_name=@companyname, contact_number=@contactNumber,email=@email,password=@password,account_number=@accountNumber WHERE shipper_id =@shipperId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@shipperId",delivery.ShipperId);
            command.Parameters.AddWithValue("@companyName",delivery.CompanyName);
            command.Parameters.AddWithValue("@contactNumber",delivery.ContactNumber);
            command.Parameters.AddWithValue("@email",delivery.Email);
            command.Parameters.AddWithValue("@password",delivery.Password);
            command.Parameters.AddWithValue("@accountNumber",delivery.AccountNumber);
            await connection.OpenAsync();
            int rowsAffected=command.ExecuteNonQuery();
            if(rowsAffected >0){
             status=true;
            }
        }
        catch (Exception e)
        {
            throw e;

        }
        finally
        {
            connection.Close();
        }
        return status;

    }

    public async Task<bool> Delete(int id)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "DELETE FROM shippers WHERE shipper_id=@shipperId";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@shipperId", id);
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

    