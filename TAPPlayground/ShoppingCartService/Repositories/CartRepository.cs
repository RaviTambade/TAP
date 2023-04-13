using System.Data;
using MySql.Data.MySqlClient;
using ShoppingCartService.Models;
using ShoppingCartService.Repositories.Interfaces;
namespace ShoppingCartService.Repositories;
public class CartRepository : ICartRepository
{
    private IConfiguration _configuration;
    private string _conString;
    public CartRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

      public async Task<List<Cart>> GetAllCarts()
    {
        List<Cart> carts = new List<Cart>();
        List<Cart> newcarts = new List<Cart>();
        MySqlConnection con = new MySqlConnection();
        try
        {
            con.ConnectionString = _conString;
            string query =" SELECT cart_items.cart_id, products.product_id,products.product_title,products.image," +
                           " products.unit_price,cart_items.quantity FROM products,cart_items " +
                           " WHERE products.product_id=cart_items.product_id order by cart_items.cart_id";
            MySqlCommand command = new MySqlCommand(query, con);
            await con.OpenAsync();
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                Cart theCart = new Cart();
                int cartId = int.Parse(reader["cart_id"].ToString());
                int productId = int.Parse(reader["product_id"].ToString());
                string productTitle = reader["product_title"].ToString();
                string imageURL = reader["image"].ToString();
                int quantity = int.Parse(reader["quantity"].ToString());
                double unitPrice = double.Parse(reader["unit_price"].ToString());
                Item item = new Item()
                {
                    ProductId = productId,
                    ProductTitle = productTitle,
                    ImageURL = imageURL,
                    Quantity = quantity,
                    UnitPrice = unitPrice
                };
                theCart.Items.Add(item);
                theCart.CartId=cartId;
                carts.Add(theCart);
            }

            await reader.CloseAsync();
            await con.CloseAsync();
            var groupedCarts = carts.GroupBy(cart => cart.CartId).ToList();
            // var groupedCarts = from cart in carts group cart by cart.CartId;
            foreach (var cartGroup in groupedCarts)
            {
                Cart cart = new Cart();
                // Console.WriteLine("CartId=" + cartGroup.Key);
                cart.CartId = cartGroup.Key;
                foreach (var cart1 in cartGroup)
                {
                    foreach (var item in cart1.Items)
                    {
                        // Console.WriteLine("productid=" + item.ProductId);
                        // Console.WriteLine("quantity=" + item.Quantity);
                        // Console.WriteLine();
                        Item item1 = new Item()
                        {
                            ProductId = item.ProductId,
                            ProductTitle = item.ProductTitle,
                            ImageURL = item.ImageURL,
                            Quantity = item.Quantity,
                            UnitPrice = item.UnitPrice
                        };
                        cart.Items.Add(item1);
                    }
                }
                newcarts.Add(cart);
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            await con.CloseAsync();
        }
        return newcarts;
    }

    // public async Task<List<Cart>> GetAllCarts()
    // {
    //     List<Cart> carts = new List<Cart>();
    //     MySqlConnection con = new MySqlConnection();
    //     try
    //     {
    //         con.ConnectionString = _conString;
    //         string query = "select DISTINCT(cart_id) from cart_items";
    //         Console.WriteLine(query);
    //         MySqlCommand command = new MySqlCommand(query, con);
    //         await con.OpenAsync();
    //         MySqlDataReader reader = command.ExecuteReader();
    //         while (await reader.ReadAsync())
    //         {
    //             int cartId = int.Parse(reader["cart_id"].ToString());
    //             Cart theCart = new Cart();
    //             theCart.CartId = cartId;
    //             carts.Add(theCart);
    //         }
    //         await reader.CloseAsync();
    //         foreach (Cart theCart in carts)
    //         {
    //             string secondQuery = "SELECT products.product_id,products.product_title,products.image," +
    //                                  " products.unit_price,cart_items.quantity" +
    //                                  " FROM products, cart_items " +
    //                                  " WHERE products.product_id=cart_items.product_id AND cart_id=@cartId";

    //             MySqlCommand command2 = new MySqlCommand(secondQuery, con);
    //             command2.Parameters.AddWithValue("@cartId", theCart.CartId);
    //             Console.WriteLine(secondQuery);
    //             MySqlDataReader readerItems = command2.ExecuteReader();
    //             while (await readerItems.ReadAsync())
    //             {
    //                 int productId = int.Parse(readerItems["product_id"].ToString());
    //                 string productTitle = readerItems["product_title"].ToString();
    //                 string imageURL = readerItems["image"].ToString();
    //                 int quantity = int.Parse(readerItems["quantity"].ToString());
    //                 double unitPrice = double.Parse(readerItems["unit_price"].ToString());
    //                 Item item = new Item()
    //                 {
    //                     ProductId = productId,
    //                     ProductTitle = productTitle,
    //                     ImageURL = imageURL,
    //                     Quantity = quantity,
    //                     UnitPrice = unitPrice
    //                 };
    //                 theCart.Items.Add(item);
    //             }
    //             await readerItems.CloseAsync();
    //         }

    //     }
    //     catch (Exception e)
    //     {
    //         throw e;
    //     }
    //     finally
    //     {
    //         await con.CloseAsync();
    //     }
    //     return carts;
    // }
    public async Task<Cart> GetCart(int cartId)
    {
        Cart cart = new Cart();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "SELECT products.product_id,products.product_title,products.image," +
                           " products.unit_price,cart_items.quantity FROM products,cart_items " +
                           " WHERE products.product_id=cart_items.product_id AND cart_id=@cartId";
            await con.OpenAsync();
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@cartId", cartId);
            MySqlDataReader reader = command.ExecuteReader();
            while (await reader.ReadAsync())
            {
                int productId = int.Parse(reader["product_id"].ToString());
                string productTitle = reader["product_title"].ToString();
                string imageURL = reader["image"].ToString();
                int quantity = int.Parse(reader["quantity"].ToString());
                double unitPrice = double.Parse(reader["unit_price"].ToString());
                Item item = new Item()
                {
                    ProductId = productId,
                    ProductTitle = productTitle,
                    ImageURL = imageURL,
                    Quantity = quantity,
                    UnitPrice = unitPrice
                };
                cart.Items.Add(item);
                cart.CartId = cartId;
            }
            await reader.CloseAsync();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            await con.CloseAsync();
        }
        return cart;
    }
    public async Task<bool> AddItem(int cartId, Item item)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        try
        {
            con.ConnectionString = _conString;
            await con.OpenAsync();
            string query = "INSERT into cart_items(cart_id,product_id,quantity) VALUES (@cartId, @productId,@quantity)";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@cartId", cartId);
            command.Parameters.AddWithValue("@productId", item.ProductId);
            command.Parameters.AddWithValue("@quantity", item.Quantity);
            int rowsAffected = await command.ExecuteNonQueryAsync();
            if (rowsAffected >= 1)
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
            await con.CloseAsync();
        }
        return status;
    }
    public async Task<bool> UpdateItem(int cartId, Item item)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        try
        {
            con.ConnectionString = _conString;
            string query = $"Update cart_items SET quantity =@quantity WHERE cart_id=@cartId AND product_id=@productId";
            Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@productId", item.ProductId);
            command.Parameters.AddWithValue("@cartId", cartId);
            command.Parameters.AddWithValue("@quantity", item.Quantity);
            await con.OpenAsync();
            int rowsAffected = await command.ExecuteNonQueryAsync();
            if (rowsAffected >= 1)
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
            await con.CloseAsync();
        }
        return status;
    }
    public async Task<bool> RemoveItem(int cartId, Item item)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        try
        {
            con.ConnectionString = _conString;
            await con.OpenAsync();
            string query = "DELETE from cart_items WHERE cart_id=@cartId AND product_id=@productId";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@cartId", cartId);
            command.Parameters.AddWithValue("@productId", item.ProductId);
            int rowsAffected = await command.ExecuteNonQueryAsync();
            if (rowsAffected >= 1)
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
            await con.CloseAsync();
        }
        return status;
    }
    public async Task<bool> CreateOrder(int cartId)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection(_conString);
        try
        {
            MySqlCommand command = new MySqlCommand("CreateOrder", con);             //create new mysqlcommand object to call the createorder stored procedure
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@cartId", cartId);     //set the cartid input parameter for the stored procedure
            await con.OpenAsync();
            await command.ExecuteNonQueryAsync();
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