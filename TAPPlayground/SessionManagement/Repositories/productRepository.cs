using MySql.Data.MySqlClient;
using SessionManagement.Models;

namespace SessionManagement.Repositories;
public class ProductRepository : IProductRepository
{

    public static string conString = "server=localhost;port=3306;user=root;password=password;database=simpledb";

    public List<Product> GetAllProducts()
    {
        List<Product> products = new List<Product>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "SELECT * FROM products";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = Int32.Parse(reader["productId"].ToString());
                string? name = reader["name"].ToString();
                string? description = reader["description"].ToString();
                double price = double.Parse(reader["price"].ToString());

                Product product = new Product
                {
                    Id = id,
                    Name = name,
                    Description = description,
                    Price = price
                };

                products.Add(product);
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
        return products;

    }

    public Product GetProductById(int id)
    {
        Product product = new Product();

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "SELECT * FROM products where productId=" + id;
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                // int id = Int32.Parse(reader["productId"].ToString());
                string? name = reader["name"].ToString();
                string? description = reader["description"].ToString();
                double price = double.Parse(reader["price"].ToString());
              product = new Product
                {
                    Id = id,
                    Name = name,
                    Description = description,
                    Price = price
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

        return product;
    }
    public List<Product> GetProductsDetails()
    {
        List<Product> products = new List<Product>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "SELECT * FROM products";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string? name = reader["name"].ToString();
                int totalQuantity = Int32.Parse(reader["totalQuantity"].ToString());
                int availableQuantity = Int32.Parse(reader["availableQuantity"].ToString());
                int sellQuantity = Int32.Parse(reader["soldQuantity"].ToString());

                Product product = new Product
                {
                    Name = name,
                    TotalQuantity = totalQuantity,
                    AvailableQuantity = availableQuantity,
                    SoldQuantity = sellQuantity
                };

                products.Add(product);
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
        return products;
    }

}