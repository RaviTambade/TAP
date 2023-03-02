using MySql.Data.MySqlClient;
using SessionManagement.Models;

namespace SessionManagement.Repositories;
public class ProductRepository : IProductRepository
{

    public static string conString = "server=localhost;port=3306;user=root;password=Rohit@7378;database=OTBA";

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
                int availableQuantity=Int32.Parse(reader["availableQuantity"].ToString());
                int soldQuantity=Int32.Parse(reader["soldQuantity"].ToString());

              product = new Product
                {
                    Id = id,
                    Name = name,
                    Description = description,
                    Price = price,
                    AvailableQuantity=availableQuantity,
                    SoldQuantity=soldQuantity
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
                int soldQuantity = Int32.Parse(reader["soldQuantity"].ToString());

                Product product = new Product
                {
                    Name = name,
                    TotalQuantity = totalQuantity,
                    AvailableQuantity = availableQuantity,
                    SoldQuantity = soldQuantity
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

     public bool UpdateProduct(Product product){
        bool status=false;
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=conString;
        try{
            product.AvailableQuantity-=product.Count;
            product.SoldQuantity+=product.Count;
           
            string query=$"Update products set availableQuantity={product.AvailableQuantity} ,soldQuantity={product.SoldQuantity} where productId={product.Id}";
            MySqlCommand command=new MySqlCommand(query,con);
            con.Open();
            command.ExecuteNonQuery();
            status=true;

        }
        catch(Exception e){
            throw e;
        }
        finally{
            con.Close();
        }
        return status;

    }

}