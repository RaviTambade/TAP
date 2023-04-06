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

    public List<Cart> GetAll()
    {
        List<Cart> carts = new List<Cart>();
        MySqlConnection con = new MySqlConnection();
        try
        {
            con.ConnectionString =  _conString;
            string query = "select DISTINCT(cart_id) from cart_items";
            Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, con);
            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int cartId = int.Parse(reader["cart_id"].ToString());
                Cart theCart=new Cart();
                theCart.CartId=cartId;
                carts.Add(theCart);
            }
            reader.Close();
        
            int count=carts.Count;
            foreach( Cart theCart in carts){
                string secondQuery = "select * from cart_items WHERE cart_id="+ theCart.CartId;
                Console.WriteLine(secondQuery);
                MySqlCommand command2 = new MySqlCommand(secondQuery, con);
                MySqlDataReader readerItems = command2.ExecuteReader();
                
                while (readerItems.Read())
                {
                    int productId = int.Parse(readerItems["product_id"].ToString());
                    int quantity = int.Parse(readerItems["quantity"].ToString());    
                    Item item = new Item(){
                        ProductId = productId,
                        Quantity = quantity
                    };
                    theCart.Items.Add(item);
                }
                readerItems.Close();
                
                }
            }  
            catch (Exception e)
            {
                throw e;
            }
            finally{
                con.Close();
            }
            return carts;
    }

    public Cart Get(int cartId)
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
            command.Parameters.AddWithValue("@cartId",cartId);
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
                    CartId = cartId,
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



    public bool AddToCart(Cart cart) 
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try{
            string query ="INSERT into cart_items(cart_id,product_id,quantity) VALUES (@cartId, @productId,@quantity)";
            con.Open();
            foreach(Item item in cart.Items){
            MySqlCommand command = new MySqlCommand(query,con);
            command.Parameters.AddWithValue("@cartId",cart.CartId);
            command.Parameters.AddWithValue("@productId",item.ProductId);
            command.Parameters.AddWithValue("@quantity",item.Quantity);
            command.ExecuteNonQuery();
            status = true;
            }
        }
        catch(Exception e){
            throw e;
        }
        finally{
            con.Close();
        }
        return status;
    }
    
    
    public bool update() {
        return false;
    }
    public bool Delete(int cartId){
        return false;
    }
}

