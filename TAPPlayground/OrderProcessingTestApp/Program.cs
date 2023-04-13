using OrderProcessingService.Models;
using Newtonsoft.Json;
class Program
{
    private static readonly HttpClient client = new HttpClient();
    static async Task Main(string[] args)
    {
        await FetchOrdersFromRESTAPI();
        await FetchOrderDetails();
       
    }
     public static async Task FetchOrdersFromRESTAPI()
    {
        //consume REST API 
        List<Order> orders = new List<Order>();
        //access data from rest api using asynchronous
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5158/getallorders"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                orders = JsonConvert.DeserializeObject<List<Order>>(apiResponse);

                foreach (var order in orders)
                    Console.WriteLine(order.OrderId + " ," + order.OrderDate + " ," + order.ShippedDate + " ," + order.CustomerId + " ," + order.Total + " ," + order.Status);

            }
        }
    }
    private static async Task FetchOrderDetails()
    {
        Console.WriteLine("Enter the OrderId:");
        int orderId = Convert.ToInt32(Console.ReadLine());
        Order order = new Order();
        using(var httpClient = new HttpClient())
        {
            using(var response = await httpClient.GetAsync("http://localhost:5158/getorder/" +orderId))
            {
               string apiResponse = await response.Content.ReadAsStringAsync();

                order = JsonConvert.DeserializeObject<Order>(apiResponse);
                Console.WriteLine(order.OrderId + " ," + order.OrderDate + " ," + order.ShippedDate + " ," + order.CustomerId + " ," + order.Total + " ," + order.Status);
 
            }
        }
    }

    private static async Task InsertOrder()
    {
        Console.WriteLine("Enter your Orderdate:");
        string OrderDate = Console.ReadLine();

        Console.WriteLine("Enter your Shippeddate:");
        string ShippedDate = Console.ReadLine();

    }
}

