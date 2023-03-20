
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace ECommerceApp.Repositories;
public class SupplierRepository : ISupplierRepository

{

    //IConfiguration interface help us to 
    //read settings available in appsettings.json file
    
    private IConfiguration _configuration;
    private string _conString;
  
    //Parameterized Constructor
    public SupplierRepository(IConfiguration configuration){
        _configuration=configuration;
        _conString= this._configuration.GetConnectionString("DefaultConnection");
    }   
    
     public List<Supplier> GetAllSuppliers()
    {
        List<Supplier> suppliers = new List<Supplier>();
        MySqlConnection connection = new MySqlConnection(_conString);
        try
        {
            string query = "SELECT * FROM suppliers";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = int.Parse(reader["supplier_id"].ToString());
                string companyName = reader["company_name"].ToString();
                string supplierName = reader["supplier_name"].ToString();
                string contactNumber = reader["contact_number"].ToString();
                string email = reader["email"].ToString();
                string address = reader["address"].ToString();
                string city = reader["city"].ToString();
                string state = reader["state"].ToString();
                long accountNumber = long.Parse(reader["account_number"].ToString());

                Supplier supplier = new Supplier()
                {
                    SupplierId = id,
                    CompanyName = companyName,
                    SupplierName = supplierName,
                    ContactNumber = contactNumber,
                    Email = email,
                    Address=address,
                    City = city,
                    State = state,
                    AccountNumber = accountNumber
                };
                suppliers.Add(supplier);
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
        return suppliers;
    }
    public Supplier GetSupplierById(int id)
    {
        Supplier supplier = new Supplier();
        MySqlConnection connection = new MySqlConnection(_conString);
        try
        {
            string query = "SELECT * FROM suppliers WHERE supplier_id=@supplierId";
            Console.WriteLine(query);
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@supplierId", id);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id = int.Parse(reader["supplier_id"].ToString());
                string companyName = reader["company_name"].ToString();
                string supplierName = reader["supplier_name"].ToString();
                string contactNumber = reader["contact_number"].ToString();
                string email = reader["email"].ToString();
                string address = reader["address"].ToString();
                string city = reader["city"].ToString();
                string state = reader["state"].ToString();
                long accountNumber = long.Parse(reader["account_number"].ToString());

                supplier = new Supplier()
                {
                    SupplierId = id,
                    CompanyName = companyName,
                    SupplierName = supplierName,
                    ContactNumber = contactNumber,
                    Email = email,
                    Address=address,
                    City = city,
                    State = state,
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
        return supplier;
    }

    public List<Supplier> GetSuppliersOfProduct(int id)
    {
        List<Supplier> suppliers = new List<Supplier>();
        MySqlConnection connection = new MySqlConnection(_conString);
        try
        {
            string query = " SELECT suppliers.supplier_id,suppliers.company_name,suppliers.supplier_name FROM suppliers INNER JOIN orderdetails ON suppliers.supplier_id=orderdetails.supplier_id WHERE product_id=@productId";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("productId",id);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int supplierid = int.Parse(reader["supplier_id"].ToString());
                string companyName = reader["company_name"].ToString();
                string supplierName = reader["supplier_name"].ToString();
                Supplier supplier = new Supplier()
                {
                    SupplierId = supplierid,
                    CompanyName = companyName,
                    SupplierName = supplierName,
                };
                suppliers.Add(supplier);
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
        return suppliers;
    }

    public bool InsertSupplier(Supplier supplier){
        bool status=false;
        MySqlConnection connection=new MySqlConnection();
        connection.ConnectionString=_conString;
        try{

            //string query=$"INSERT INTO suppliers(company_name,supplier_name,contact_number,email,address,city,state,account_number)VALUES(@companyName,@supplierName,@supplierContactName,@supplierEmail,@supplierAddress,@supplierCity,@supplierState,@supplierAccountNumber";

            string query="INSERT INTO suppliers(company_name,supplier_name,contact_number,email,address,city,state,account_number)VALUES(@companyName,@supplierName,@contactNumber,@email,@address,@city,@state,@accountNumber)";

            connection.Open();
            MySqlCommand command=new MySqlCommand(query ,connection);
            command.Parameters.AddWithValue("@companyName",supplier.CompanyName);
            command.Parameters.AddWithValue("@supplierName",supplier.SupplierName);

            command.Parameters.AddWithValue("@supplierContactName",supplier.ContactNumber);
            command.Parameters.AddWithValue("@supplierEmail",supplier.Email);
            command.Parameters.AddWithValue("@supplierAddress",supplier.Address);
            command.Parameters.AddWithValue("@supplierCity",supplier.Address);
            command.Parameters.AddWithValue("@supplierState",supplier.Address);
            command.Parameters.AddWithValue("@supplierAccountNumber",supplier.Address);

            command.Parameters.AddWithValue("@contactNumber",supplier.ContactNumber);
            command.Parameters.AddWithValue("@email",supplier.Email);
            command.Parameters.AddWithValue("@address",supplier.Address);
            command.Parameters.AddWithValue("@city",supplier.City);
            command.Parameters.AddWithValue("@state",supplier.State);
            command.Parameters.AddWithValue("@accountNumber",supplier.AccountNumber);


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

    
    public bool UpdateSupplier(Supplier supplier)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = _conString;
        try
        {
            string query = "UPDATE suppliers SET company_name=@companyName , supplier_name=@supplierName , contact_number=@contactNumber , email=@email , address=@address , city=@city , state=@state , account_number=@accountNumber WHERE supplier_id=@supplierId";
            Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@supplierId",supplier.SupplierId);
            command.Parameters.AddWithValue("@companyName",supplier.CompanyName);
            command.Parameters.AddWithValue("@supplierName",supplier.SupplierName);
            command.Parameters.AddWithValue("@contactNumber",supplier.ContactNumber);
            command.Parameters.AddWithValue("@email",supplier.Email);
            command.Parameters.AddWithValue("@address",supplier.Address);
            command.Parameters.AddWithValue("@city",supplier.City);
            command.Parameters.AddWithValue("@state",supplier.State);
            command.Parameters.AddWithValue("@accountNumber",supplier.AccountNumber);
            connection.Open();
            command.ExecuteNonQuery();
            status = true;
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
          public bool DeleteSupplier(int id)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            //Paramterized Query

            string query = "DELETE FROM suppliers WHERE supplier_id=@supplierId";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@supplierId",id);
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
    

    