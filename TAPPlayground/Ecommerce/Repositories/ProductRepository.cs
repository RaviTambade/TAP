using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace ECommerceApp.Repositories;
public class ProductRepository : IProductRepository
{
    public static string conString = "server=localhost;port=3306;user=root;password=password;database=Ecommerce";

    public List<Product> GetAllProducts()
    {
        List<Product> products = new List<Product>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;
        try
        {
            string query = "SELECT * FROM products";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = Int32.Parse(reader["product_id"].ToString());
                string? title = reader["title"].ToString();
                string? description = reader["description"].ToString();
                double price = double.Parse(reader["unit_price"].ToString());
                string? imgUrl = reader["image"].ToString();

                Product product = new Product
                {
                    ProductId = id,
                    Title = title,
                    Description = description,
                    UnitPrice = price,
                    ImageUrl = imgUrl
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
            connection.Close();
        }
        return products;
    }

    public Product GetProduct(int id)
    {
        Product product = new Product();

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            string query = "SELECT * FROM products where product_id=" + id;
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                // int id = Int32.Parse(reader["productId"].ToString());
                string? name = reader["title"].ToString();
                string? description = reader["description"].ToString();
                double price = double.Parse(reader["unit_price"].ToString());
                string? imgUrl = reader["image"].ToString();

                product = new Product
                {
                    ProductId = id,
                    Title = name,
                    Description = description,
                    UnitPrice = price,
                    ImageUrl = imgUrl
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
}