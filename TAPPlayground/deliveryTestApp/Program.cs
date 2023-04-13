using DeliveryService.Models;
using Newtonsoft.Json;
class Program
{
    private static readonly HttpClient client = new HttpClient();
    static async Task Main(string[] args)
    {
        await FetchShippersFromRESTAPI();
        await FetchShipperDetails();
        await InsertShipper();
        await UpdateDelivery();
        await DeleteDelivery();
    }
    private static async Task FetchShipperDetails()
    {

        int shipperId = Convert.ToInt32(Console.ReadLine());
        Delivery delivery = new Delivery();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5222/api/delivery/getdeliverydetails/" + shipperId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                delivery = JsonConvert.DeserializeObject<Delivery>(apiResponse);
                Console.WriteLine(delivery.ShipperId + " ," + delivery.Email + " ," + delivery.ContactNumber + " ," + delivery.CompanyName + " ," + delivery.Password + " ," + delivery.AccountNumber);
            }
        }
    }
    public static async Task FetchShippersFromRESTAPI()
    {

        List<Delivery> deliveries = new List<Delivery>();

        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5222/api/delivery/getalldeliveries"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                deliveries = JsonConvert.DeserializeObject<List<Delivery>>(apiResponse);

                foreach (var delivery in deliveries)
                    Console.WriteLine(delivery.AccountNumber + " ," + delivery.Email + " ," + delivery.ContactNumber + " ," + delivery.CompanyName + " ," + delivery.Password + " ," + delivery.AccountNumber);


            }
        }
    }

    public static async Task InsertShipper()
    {
        Console.WriteLine("Inserting new shipper=>");

        Console.WriteLine("Enter the company name:");
        string companyName = Console.ReadLine();

        Console.WriteLine("Enter the contact number:");
        string contactNumber = Console.ReadLine();

        Console.WriteLine("Enter the email:");
        string email = Console.ReadLine();

        Console.WriteLine("Enter the password :");
        string password = Console.ReadLine();

        Console.WriteLine("Enter the account number:");
        long accountNumber = long.Parse(Console.ReadLine());


        Delivery delivery = new Delivery()
        {

            CompanyName = companyName,
            ContactNumber = contactNumber,
            Email = email,
            Password = password,
            AccountNumber = accountNumber
        };

        string jsonShipper = System.Text.Json.JsonSerializer.Serialize(delivery);
        var requestContent = new StringContent(jsonShipper, System.Text.Encoding.UTF8, "application/json");
        using (var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:5222/api/delivery/addDelivery";
            using (var response = await httpClient.PostAsync(apiUrl, requestContent))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }

        }
    }

    public static async Task UpdateDelivery()
    {
        Console.WriteLine("Enter the Shipper ID:");
        int shipperId = Convert.ToInt32(Console.ReadLine());
        Delivery delivery = new Delivery();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5222/api/delivery/getdeliverydetails/{id}" + shipperId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                delivery = JsonConvert.DeserializeObject<Delivery>(apiResponse);
            }
        }

        Console.WriteLine("Enter the company name:");
        delivery.CompanyName = Console.ReadLine();

        Console.WriteLine("Enter the contact number:");
        delivery.ContactNumber = Console.ReadLine();

        Console.WriteLine("Enter the email:");
        delivery.Email = Console.ReadLine();

        Console.WriteLine("Enter the password :");
        delivery.Password = Console.ReadLine();

        Console.WriteLine("Enter the account number:");
        delivery.AccountNumber = long.Parse(Console.ReadLine());



        string jsonShipper = System.Text.Json.JsonSerializer.Serialize(delivery);
        var requestContent = new StringContent(jsonShipper, System.Text.Encoding.UTF8, "application/json");
        using (var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:5222/api/delivery/updateDelivery/{id}" + delivery.ShipperId;
            using (var response = await httpClient.PutAsync(apiUrl, requestContent))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }

        }
    }
    private static async Task DeleteDelivery()
    {
        Console.WriteLine("Enter the shipperID:");
        int shipperId = Convert.ToInt32(Console.ReadLine());
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.DeleteAsync("http://localhost:5222/api/delivery/deleteDelivery/" + shipperId))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }
        }
    }
}





