using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace ECommerceApp.Repositories;
public class SupplierRepository : ISupplierRepository

{
    public static string conString = "server=localhost;port=3306;user=root;password=password;database=ecommerce";
    public List<Supplier> GetAllSuppliers()
    {
        List<Supplier> suppliers = new List<Supplier>();
        MySqlConnection connection = new MySqlConnection(conString);
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
        MySqlConnection connection = new MySqlConnection(conString);
        try
        {
            string query = "SELECT * FROM suppliers WHERE supplier_id=" + id;
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
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

    public List<Supplier> GetSuppliersOfProduct(int ProductId)
    {
        List<Supplier> suppliers = new List<Supplier>();
        MySqlConnection connection = new MySqlConnection(conString);
        try
        {
            string query = " SELECT suppliers.supplier_id,suppliers.company_name,suppliers.supplier_name FROM suppliers INNER JOIN orderdetails ON suppliers.supplier_id=orderdetails.supplier_id WHERE product_id=" + ProductId;
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = int.Parse(reader["supplier_id"].ToString());
                string companyName = reader["company_name"].ToString();
                string supplierName = reader["supplier_name"].ToString();
                Supplier supplier = new Supplier()
                {
                    SupplierId = id,
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
        connection.ConnectionString=conString;
        try{
            string query=$"INSERT INTO suppliers(company_name,supplier_name,contact_number,email,address,city,state,account_number)VALUES('{supplier.CompanyName}','{supplier.SupplierName}','{supplier.ContactNumber}','{supplier.Email}','{supplier.Address}','{supplier.City}','{supplier.State}','{supplier.AccountNumber}')";
            connection.Open();
            MySqlCommand command=new MySqlCommand(query ,connection);
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
        connection.ConnectionString = conString;
        try
        {
            string query = "UPDATE suppliers SET company_name='" +supplier.CompanyName + "', supplier_name='" + supplier.SupplierName + "', contact_number='" + supplier.ContactNumber +"', email='" + supplier.Email +"', address='" + supplier.Address +"', city='" + supplier.City+"', state='" + supplier.State+"', account_number='" + supplier.AccountNumber +"' WHERE supplier_id=" +supplier.SupplierId;
            MySqlCommand command = new MySqlCommand(query, connection);
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
}
    