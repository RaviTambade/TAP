using OrderProcessingService.Models;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
class Program
{
    private static readonly HttpClient client = new HttpClient();
    static async Task Main(string[] args)
    {
        //await FetchOrdersFromRESTAPI();
        //await FetchOrderDetails();
        //await InsertOrder();
        await UpdateOrder();
        //await DeleteOrder();
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
        Console.WriteLine("Enter OrderDate:");
        DateTime orderDate = Convert.ToDateTime(Console.ReadLine());

        Console.WriteLine("Enter ShippedDate:");
        DateTime shippedDate = Convert.ToDateTime(Console.ReadLine());

        Console.WriteLine("Enter Customer Id:");
        int customerId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Total:");
        double total = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter order Status:");
        string status = Console.ReadLine();

        Order order = new Order()
        {
            OrderDate = orderDate,
            ShippedDate = shippedDate,
            CustomerId= customerId,
            Total = total,
            Status= status
            
        };
        string jsonCustomer = System.Text.Json.JsonSerializer.Serialize(order);
        var requestContent = new StringContent(jsonCustomer, Encoding.UTF8,"application/json");
        using (var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:5158/addorder";
            using (var response = await httpClient.PostAsync(apiUrl, requestContent))
            {
               response.EnsureSuccessStatusCode();
               var content = await response.Content.ReadAsStringAsync();
            }
        }
    }
    private static async Task UpdateOrder()
    {
        Console.WriteLine("Enter your OrderId for updating");
        int orderId = Convert.ToInt32(Console.ReadLine());
        Order order = new Order();
        using(var httpClient = new HttpClient())
        {
            using(var response = await httpClient.GetAsync("http://localhost:5158/getorder/" +orderId))
            {
                string apiResponse= await response.Content.ReadAsStringAsync();
                order = JsonConvert.DeserializeObject<Order>(apiResponse);
            }
        }

        Console.WriteLine("enter new orderdate:");
        order.OrderDate = Convert.ToDateTime(Console.ReadLine());

        Console.WriteLine("enter new shippeddate:");
        order.ShippedDate = Convert.ToDateTime(Console.ReadLine());

        Console.WriteLine("enter new customerId:");
        order.CustomerId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("enter new total:");
        order.Total = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("enter new order status:");
        order.Status = Console.ReadLine();
        
        string jsonOrder = System.Text.Json.JsonSerializer.Serialize(order);
        var requestContent = new StringContent(jsonOrder,Encoding.UTF8,"application/json" );
        using(var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:5158/update/"+order.OrderId;
            using(var response = await httpClient.PutAsync(apiUrl, requestContent))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }
            
        }
    }
    private static async Task DeleteOrder()
    {
        Console.WriteLine("Enter the Order Id:");
        int orderId = int.Parse(Console.ReadLine());
        using(var httpClient = new HttpClient())
        {
            using(var response = await httpClient.DeleteAsync("http://localhost:5158/delete/" + orderId))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }
        }
    }
}

