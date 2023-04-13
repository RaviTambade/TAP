using System.Text;
using Newtonsoft.Json;
using ShoppingCartService.Models;
class Program
{
    private static readonly HttpClient client = new HttpClient();
    static async Task Main(string[] args)
    {
        int choice;
        do
        {

            Console.WriteLine("***************************************************************");
            Console.WriteLine("1.ShowAll Carts");
            Console.WriteLine("2.Show Cart Details");
            Console.WriteLine("3.Add Item To Cart");
            Console.WriteLine("4.Update Item of Cart");
            Console.WriteLine("5.Remove Item from Cart");
            Console.WriteLine("0.Exit");
            Console.WriteLine("***************************************************************");
            choice = Convert.ToInt32(Console.ReadLine());


            switch (choice)
            {

                case 1:
                    await FetchAllCarts();
                    break;
                case 2:
                    Console.WriteLine("Enter the cart ID:");
                    int cartId = Convert.ToInt32(Console.ReadLine());
                    await FetchCartDetails(cartId);
                    break;
                case 3:
                    await AddItem();
                    break;
                case 4:
                    await UpdateItem();
                    break;
                case 5:
                    await RemoveItem();
                    break;
                case 0:
                    Console.WriteLine("Exiting");
                    break;

                default:
                    Console.WriteLine("Please choose correct option");
                    break;
            }
        } while (choice != 0);

    }
    private static async Task FetchAllCarts()
    {

        List<Cart> cartItems = new List<Cart>();

        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5023/api/Cart/getallcartitems"))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                cartItems = JsonConvert.DeserializeObject<List<Cart>>(apiResponse);

                foreach (var cart in cartItems)
                {
                    Console.WriteLine("CartId=" + cart.CartId);
                    Console.WriteLine();
                    foreach (var item in cart.Items)
                    {
                        Console.WriteLine("ProductId=" + item.ProductId);
                        Console.WriteLine("ProductTitle=" + item.ProductTitle);
                        Console.WriteLine("ImageURL=" + item.ImageURL);
                        Console.WriteLine("Quantity=" + item.Quantity);
                        Console.WriteLine("UnitPrice=" + item.UnitPrice);
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }

            }
        }
    }

    private static async Task FetchCartDetails(int cartId)
    {

        Cart cart = new Cart();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5023/api/cart/getcartdetails/" + cartId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                cart = JsonConvert.DeserializeObject<Cart>(apiResponse);

                Console.WriteLine("CartId=" + cart.CartId);
                Console.WriteLine();
                foreach (var item in cart.Items)
                {
                    Console.WriteLine("ProductId=" + item.ProductId);
                    Console.WriteLine("ProductTitle=" + item.ProductTitle);
                    Console.WriteLine("ImageURL=" + item.ImageURL);
                    Console.WriteLine("Quantity=" + item.Quantity);
                    Console.WriteLine("UnitPrice=" + item.UnitPrice);
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }

    private static async Task AddItem()
    {
        Console.WriteLine("Add Item to Cart ");
        Console.WriteLine("Enter  cartId :");
        int cartId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter  productId :");
        int productId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the product Quantity:");
        int quantity = Convert.ToInt32(Console.ReadLine());

        Item item = new Item()
        {
            ProductId = productId,
            Quantity = quantity
        };
        string jsonItem = System.Text.Json.JsonSerializer.Serialize(item);
        var requestContent = new StringContent(jsonItem, Encoding.UTF8, "application/json");
        using (var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:5023/api/cart/addtocart/" + cartId;
            using (var response = await httpClient.PostAsync(apiUrl, requestContent))
            {
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                string res = JsonConvert.DeserializeObject<string>(content);
                Console.WriteLine(res);
                if (res == "true")
                {
                    Console.WriteLine("Item Added Sucessfully");
                }
                else
                {
                    Console.WriteLine("Item you Want to add might not Exist");
                }
            }

        }
    }

    private static async Task UpdateItem()
    {

        Console.WriteLine("Update Item of Cart ");
        Console.WriteLine("Enter  cartId :");
        int cartId = Convert.ToInt32(Console.ReadLine());
        await FetchCartDetails(cartId);
        Console.WriteLine("Enter  productId :");
        int productId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the product Quantity:");
        int quantity = Convert.ToInt32(Console.ReadLine());

        Item item = new Item()
        {
            ProductId = productId,
            Quantity = quantity
        };
        string jsonItem = System.Text.Json.JsonSerializer.Serialize(item);
        var requestContent = new StringContent(jsonItem, Encoding.UTF8, "application/json");
        using (var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:5023/api/cart/update/" + cartId;
            using (var response = await httpClient.PutAsync(apiUrl, requestContent))
            {
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                string res = JsonConvert.DeserializeObject<string>(content);
                Console.WriteLine(res);
                if (res == "true")
                {
                    Console.WriteLine("Item Updated Sucessfully");
                }
                else
                {
                    Console.WriteLine("Item Does not Exist");
                }
            }
        }
    }

    private static async Task RemoveItem()
    {

        Console.WriteLine("Delete Item of Cart ");
        Console.WriteLine("Enter  cartId :");
        int cartId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter  productId :");
        int productId = Convert.ToInt32(Console.ReadLine());

        Item item = new Item()
        {
            ProductId = productId
        };
        string jsonItem = System.Text.Json.JsonSerializer.Serialize(item);
        var requestContent = new StringContent(jsonItem, Encoding.UTF8, "application/json");
        using (var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:5023/api/cart/delete/" + cartId;
            using (var response = await httpClient.PostAsync(apiUrl, requestContent))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                string res = JsonConvert.DeserializeObject<string>(content);
                Console.WriteLine(res);

                if (res == "true")
                {
                    Console.WriteLine("Item Deleted Sucessfully");
                }
                else
                {
                    Console.WriteLine("Item Does not Exist");
                }
            }
        }
    }
}

