using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace ECommerceApp.Repositories;
public class CartRepository : ICartRepository
{

    private IConfiguration _configuration;
    private string _conString;

    public CartRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

    // public List<Cart> GetAll()
    // {
    //    List<Cart> carts = new List<Cart>();
    //     MySqlConnection con = new MySqlConnection();
    //     con.ConnectionString = _conString;
    //     try
    //     {
    //         string query = "select * from carts";
    //         MySqlCommand command = new MySqlCommand(query, con);
    //         con.Open();
    //         MySqlDataReader reader = command.ExecuteReader();
    //         while (reader.Read())
    //         {
    //             int id = int.Parse(reader["category_id"].ToString());
    //             string? categoryTitle = reader["category_title"].ToString();
    //             string? description = reader["description"].ToString();
    //             string? imageUrl = reader["image"].ToString();
              
    //           Category category=new Category()
    //             {
    //               CategoryId=id,
    //               CategoryTitle=categoryTitle,
    //               Description=description,
    //               ImageUrl=imageUrl
    //             };
    //             categories.Add(category);
    //         }
    //         reader.Close();
    //     }
    //     catch (Exception e)
    //     {
    //         throw e;
    //     }
    //     finally
    //     {
    //         con.Close();
    //     }
    //     return categories;

    // }

      public Cart Get(int id)
    {
        Cart cart = new Cart();
        List<Item> items = new List<Item>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT * FROM cart_items where cart_id=@cartId";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@cartId",id);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int productId = int.Parse(reader["product_id"].ToString());
                int quantity = int.Parse(reader["quantity"].ToString());
            Item item = new Item(){
                ProductId = productId,
                Quantity = quantity
            };
            items.Add(item);
            }
            reader.Close();
             cart = new Cart
                {
                    CartId = id,
                    Items = items

                };
            

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
        return cart;
    }



    public bool Insert() {
        return false;
    }
    public bool update() {
        return false;
    }
    public bool Delete(int cartId){
        return false;
    }
}

