using CRMService.Models;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

public class program
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task Main(string[] args)
    {
        await FetchCustomersFromRestAPI();
        await FetchCustomerDetails();
        await InsertCustomer();
        await UpdateCustomer();
        await DeleteProduct();
    }

    public static async Task FetchCustomersFromRestAPI()
    {
        List<Customer> customers = new List<Customer>();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:4002/api/customers/getallcustomers"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                customers = JsonConvert.DeserializeObject<List<Customer>>(apiResponse);

                foreach(var customer in customers)
                {
                    Console.WriteLine(customer.CustomerId + " " + customer.FirstName + " " + customer.LastName + " " + customer.Email + " " + customer.ContactNumber + " " + customer.Password + " " + customer.AccountNumber);
                }
            }
        }
    }

     private static async Task FetchCustomerDetails()
    {
        Console.WriteLine("Enter the customer ID:");
        int customerId = int.Parse(Console.ReadLine());
        Customer customer = new Customer();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:4002/api/customers/getcustomerdetails/" + customerId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                customer = JsonConvert.DeserializeObject<Customer>(apiResponse);
                Console.WriteLine(customer.CustomerId + " " + customer.FirstName + " " + customer.LastName + " " + customer.Email + " " + customer.ContactNumber + " " + customer.Password + " " + customer.AccountNumber);
            }
        }
    }

    private static async Task InsertCustomer()
    {
        Console.WriteLine("Enter customer First Name:");
        string firstName = Console.ReadLine();

        Console.WriteLine("Enter Customer Last Name");
        string lastName = Console.ReadLine();

        Console.WriteLine("Enter Customer Email");
        string email = Console.ReadLine();

        Console.WriteLine("Enter Customer Contact Number");
        string contactNumber = Console.ReadLine();

        Console.WriteLine("Enter Customer Password");
        string password = Console.ReadLine();

        Console.WriteLine("Enter Customer Account Number");
        long accountNumber = long.Parse(Console.ReadLine());

        Customer customer = new Customer()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            ContactNumber = contactNumber,
            Password = password,
            AccountNumber = accountNumber
        };
        string jsonCustomer = System.Text.Json.JsonSerializer.Serialize(customer);
        var requestContent = new StringContent(jsonCustomer, Encoding.UTF8,"application/json");
        using (var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:4002/api/customers/addcustomer";
            using (var response = await httpClient.PostAsync(apiUrl, requestContent))
            {
               response.EnsureSuccessStatusCode();
               var content = await response.Content.ReadAsStringAsync();
            }
        }
    }

    public static async Task UpdateCustomer()
    {
        Console.WriteLine("Enter Customer Id you want to update:");
        int customerId = int.Parse(Console.ReadLine());
        Customer customer = new Customer();
        using (var httpClient = new HttpClient())
        {
            using(var response = await httpClient.GetAsync("http://localhost:4002/api/customers/getcustomerdetails/" + customerId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                customer = JsonConvert.DeserializeObject<Customer>(apiResponse);
            }
        }
            
        Console.WriteLine("Enter customer First Name:");
        customer.FirstName = Console.ReadLine();

        Console.WriteLine("Enter Customer Last Name");
        customer.LastName = Console.ReadLine();

        Console.WriteLine("Enter Customer Email");
        customer.Email = Console.ReadLine();

        Console.WriteLine("Enter Customer Contact Number");
        customer.ContactNumber = Console.ReadLine();

        Console.WriteLine("Enter Customer Password");
        customer.Password = Console.ReadLine();

        Console.WriteLine("Enter Customer Account Number");
        customer.AccountNumber = long.Parse(Console.ReadLine());

        string jsonCustomer = System.Text.Json.JsonSerializer.Serialize(customer);
        var requestContent = new StringContent(jsonCustomer, Encoding.UTF8,"application/json");
        using (var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:4002/api/customers/update/"+customer.CustomerId;
            using (var response = await httpClient.PutAsync(apiUrl, requestContent))
            {
               response.EnsureSuccessStatusCode();
               var content = await response.Content.ReadAsStringAsync();
            }
        }
    }

    private static async Task DeleteProduct()
    {
        Console.WriteLine("Enter the Customer ID:");
        int custId = int.Parse(Console.ReadLine());
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.DeleteAsync("http://localhost:4002/api/customers/delete/" + custId))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }
        }
    }
}