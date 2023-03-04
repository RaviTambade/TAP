using MySql.Data.MySqlClient;
using SessionManagement.Models;

namespace SessionManagement.Repositories;
public class ProductRepository : IProductRepository
{

    public static string conString = "server=localhost;port=3306;user=root;password=Password;database=Ecommerce";

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
                int id = Int32.Parse(reader["product_id"].ToString());
                string? title = reader["title"].ToString();
                string? description = reader["description"].ToString();
                int stockAvailable= Int32.Parse(reader["stock_available"].ToString());
                double unitPrice = double.Parse(reader["unit_price"].ToString());
                string? image = reader["image"].ToString();

                Product product = new Product
                {
                    Id = id,
                    Title = title,
                    Description = description,
                    StockAvailable = stockAvailable,
                    UnitPrice = unitPrice,
                    Image = image
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
            string query = "SELECT * FROM products where product_id=" + id;
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int productId = Int32.Parse(reader["product_id"].ToString());
                string? title = reader["title"].ToString();
                string? description = reader["description"].ToString();
                int stockAvailable= Int32.Parse(reader["stock_available"].ToString());
                double unitPrice = double.Parse(reader["unit_price"].ToString());
                string? image = reader["image"].ToString();


              product = new Product
                {
                    Id = productId,
                    Title = title,
                    Description = description,
                    StockAvailable = stockAvailable,
                    UnitPrice = unitPrice,
                    Image = image
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
    /*public List<Product> GetProductsDetails()
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

*/
