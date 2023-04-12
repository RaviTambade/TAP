using ShoppingCartService.Models;
using CatalogService.Models;
using Newtonsoft.Json;
class Program
{
    private static readonly HttpClient client = new HttpClient();
    static async Task Main(string[] args)
    {
        await FetchAllCarts();
        // await FetchCartDetails();   
        // await AddItem();
        // await UpdateItem();
        // await RemoveItem();
    }
    

    private static async Task FetchAllCarts()
    {
        //consume REST API 
        List<Cart> cartitems = new List<Cart>();
        //access data from rest api using asynchronous
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5023/api/Cart/getallcartitems"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                cartitems = JsonConvert.DeserializeObject<List<Cart>>(apiResponse);
                foreach (var cart in cartitems)
                    Console.WriteLine(cart.CartId + " ," + cart.Items );
            }
        }
    }

    private static async Task FetchCartDetails()
    {
        Console.WriteLine("Enter the cart ID:");
        int cartId = Convert.ToInt32(Console.ReadLine());
        Cart cart = new Cart();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5023/api/products/getproductdetails/" + cartId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                product = JsonConvert.DeserializeObject<Product>(apiResponse);
                Console.WriteLine(cart.CartId + " ," + cart.Items );
            }
        }
    }

    private static async Task AddItem()
    {
       //add item in the cart through console app 
    }

    private static async Task UpdateItem()
    {
        //update item in the cart through console app
    }

    private static async Task RemoveItem()
    {
        //remove item from the cart 
    }


}

