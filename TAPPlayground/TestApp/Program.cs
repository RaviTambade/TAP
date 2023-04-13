using ECommerceApp.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

List<Cart> carts = new List<Cart>();
MySqlConnection con = new MySqlConnection();
try
{
    con.ConnectionString = "server=localhost; database=Ecommerce; user=root; password=Password";
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
    con.Close();

    int count=carts.Count;
    Console.WriteLine("Number of carts in system ="+ count);
    foreach( Cart theCart in carts){
        string secondQuery = "select * from cart_items WHERE cart_id="+ theCart.CartId;
        Console.WriteLine(secondQuery);
        con.Open();
        MySqlCommand command2 = new MySqlCommand(secondQuery, con);
        MySqlDataReader readerItems = command2.ExecuteReader();
        
        while (readerItems.Read())
        {
            Console.WriteLine("Inside Query result 2");
            int productId = int.Parse(readerItems["product_id"].ToString());
            int quantity = int.Parse(readerItems["quantity"].ToString());    
            Item item = new Item(){
                ProductId = productId,
                Quantity = quantity
            };
            theCart.Items.Add(item);
        }
         readerItems.Close();
         con.Close();
    }
}  
catch (Exception e)
{
    Console.WriteLine(e.Message);
    throw e;
}
 
foreach(Cart theCart in carts){
    Console.WriteLine("\n");
    Console.WriteLine(theCart.CartId);
    foreach(Item theItem in theCart.Items){
        Console.WriteLine( theItem.ProductId +  " "+ theItem.Quantity);
    }
}

    // MySqlConnection con = new MySqlConnection();
    // try
    // {
       
    // con.ConnectionString = "server=localhost; database=Ecommerce; user=root; password=Password";
    // string query ="Update cart_items set order_date=@orderDate, shipped_date=@shippedDate,cust_id=@customerId, total =@total, status =@status Where order_id =@orderId""
    // }
