using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace ECommerceApp.Repositories;
public class ProductRepository : IProductRepository
{
    private IConfiguration _configuration;
    private string _conString;
    public ProductRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }
    public List<Product> GetAll()
    {
        List<Product> products = new List<Product>();
        MySqlConnection connection = new MySqlConnection(_conString);
        try
        {
            string query = "SELECT * FROM products";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            connection.Open();
            while (reader.Read())
            {
                int id = Int32.Parse(reader["product_id"].ToString());
                string? title = reader["title"].ToString();
                string? description = reader["description"].ToString();
                int stockAvailable=Int32.Parse(reader["stock_available"].ToString());
                double price = double.Parse(reader["unit_price"].ToString());
                string? imgUrl = reader["image"].ToString();
                int categoryId = Int32.Parse(reader["category_id"].ToString());


                Product product = new Product
                {
                    ProductId = id,
                    Title = title,
                    Description = description,
                    StockAvailable=stockAvailable,
                    UnitPrice = price,
                    ImageUrl = imgUrl,
                    CategoryId=categoryId
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

    public Product GetById(int productId)
    {
        Product product = new Product();
        MySqlConnection con = new MySqlConnection(_conString);
        try
        {
            string query = "SELECT * FROM products where product_id=@productId";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@productId", productId);
            MySqlDataReader reader = command.ExecuteReader();
            con.Open();
            while (reader.Read())
            {
                string? name = reader["title"].ToString();
                string? description = reader["description"].ToString(); 
                int stockAvailable=Int32.Parse(reader["stock_available"].ToString());
                double price = double.Parse(reader["unit_price"].ToString());
                string? imgUrl = reader["image"].ToString();
                int categoryId = Int32.Parse(reader["category_id"].ToString());


                product = new Product
                {
                    ProductId = productId,
                    Title = name,
                    StockAvailable=stockAvailable,
                    Description = description,
                    UnitPrice = price,
                    ImageUrl = imgUrl,
                    CategoryId=categoryId
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
    public bool Insert(Product product)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection(_conString);
        try
        {
            string query = "INSERT INTO products(product_title,description,stock_available,unit_price,image,category_id)VALUES(@productTitle,@description,@,@stockAvailable,@unitPrice,@image,@categoryId)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@productTitle", product.Title);
            command.Parameters.AddWithValue("@description", product.Description);
            command.Parameters.AddWithValue("@stockAvailable", product.StockAvailable);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@image", product.ImageUrl);
            command.Parameters.AddWithValue("@categoryId", product.CategoryId);
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                status = true;
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
    public bool Update(Product product)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection(_conString);
        try
        {
            string query = "UPDATE products SET product_title=@productTitle , description=@description , stock_available=@stockAvailable , unitPrice=@unitPrice , image=@imageUrl, category_id=@categoryId WHERE product_id=@productId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@productId", product.ProductId);
            command.Parameters.AddWithValue("@productTitle", product.Title);
            command.Parameters.AddWithValue("@description", product.Description);
            command.Parameters.AddWithValue("@stockAvailable", product.StockAvailable);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@image", product.ImageUrl);
            command.Parameters.AddWithValue("@categoryId", product.CategoryId);
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                status = true;
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
    public bool Delete(int productId)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection(_conString);
        try
        {
            string query = "DELETE FROM products WHERE product_id=@productId";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@supplierId", productId);
            con.Open();
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                status = true;
            }
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