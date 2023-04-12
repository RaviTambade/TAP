using System;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BankingService.Models;
using Newtonsoft.Json;
class Program
{
    private static readonly HttpClient client = new HttpClient();
    static async Task Main(string[] args)
    {
        await FetchAccountsFromRESTAPI();
        await FetchAccountDetails();
        await InsertAccount();
        await UpdateAccount();
    }

    private static async Task FetchAccountDetails()
    {
        Console.WriteLine("Enter the account ID:");
        int accountId = Convert.ToInt32(Console.ReadLine());
        Account account = new Account();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5181/api/accounts/getaccountdetails/" + accountId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                account = JsonConvert.DeserializeObject<Account>(apiResponse);
                Console.WriteLine(account.AccountId + " ," + account.AccountNumber + " ," + account.IFSCCode + " ," + account.RegisterDate + " ," + account.Balance);
            }
        }
    }

    public static async Task FetchAccountsFromRESTAPI()
    {
        //consume REST API 
        List<Account> accounts = new List<Account>();
        //access data from rest api using asynchronous
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5181/api/accounts/getallaccounts"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                accounts = JsonConvert.DeserializeObject<List<Account>>(apiResponse);

                foreach (var account in accounts)
                    Console.WriteLine(account.AccountId + " ," + account.AccountNumber + " ," + account.IFSCCode + " ," + account.RegisterDate + " ," + account.Balance);

            }
        }
    }

    public static async Task InsertAccount()
    {

        Console.WriteLine("Enter AccountNumber ");
        long accountNumber = long.Parse(Console.ReadLine());
        Console.WriteLine("Enter IFSC Code ");
        string ifscCode = Console.ReadLine();
        Console.WriteLine("Enter Register Date");
        string registerDate = Console.ReadLine();
        Console.WriteLine("Enter Balance");
        double balance = double.Parse(Console.ReadLine());

        Account account = new Account()
        {
            AccountNumber = accountNumber,
            IFSCCode = ifscCode,
            RegisterDate = registerDate,
            Balance = balance,
        };

        string jsonAccount = System.Text.Json.JsonSerializer.Serialize(account);
        var requestContent = new StringContent(jsonAccount, Encoding.UTF8, "application/json");
        using (var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:5181/api/accounts/addaccount";
            using (var response = await httpClient.PostAsync(apiUrl, requestContent))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }
        }
    }
    public static async Task UpdateAccount()
    {
        Console.WriteLine("Update Account");
        await FetchAccountDetails();
         int accountId = Convert.ToInt32(Console.ReadLine());
         Console.WriteLine("Enter AccountNumber ");
        long accountNumber = long.Parse(Console.ReadLine());
        Console.WriteLine("Enter IFSC Code ");
        string ifscCode = Console.ReadLine();
        Console.WriteLine("Enter Register Date");
        string registerDate = Console.ReadLine();
        Console.WriteLine("Enter Balance");
        double balance = double.Parse(Console.ReadLine());
          Account account = new Account()
        {
            AccountNumber = accountNumber,
            IFSCCode = ifscCode,
            RegisterDate = registerDate,
            Balance = balance,
        };
         string jsonAccount = System.Text.Json.JsonSerializer.Serialize(account);
        var requestContent = new StringContent(jsonAccount, Encoding.UTF8, "application/json");
        using (var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:5181/api/accounts/update/"+accountId;
            using (var response = await httpClient.PutAsync(apiUrl, requestContent))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }
        }
    }

    //     string jsonAccount = System.Text.Json.JsonSerializer.Serialize(account);
    //     var requestContent = new StringContent(jsonAccount, Encoding.UTF8, "application/json");
    //     using (var httpClient = new HttpClient())
    //     {
    //         string apiUrl = "http://localhost:5181/api/accounts/update/"+accountId;
    //         using (var response = await httpClient.PostAsync(apiUrl, requestContent))
    //         {
    //             response.EnsureSuccessStatusCode();
    //             var content = await response.Content.ReadAsStringAsync();
    //         }
    //     }
}


