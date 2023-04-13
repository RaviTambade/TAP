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
        Console.WriteLine("Enter the account ID:");
        int accountId = Convert.ToInt32(Console.ReadLine());
        await FetchAccountDetails(accountId);
        await InsertAccount();
        await UpdateAccount();
        await DeleteAccount();

        Console.WriteLine("Enter Transaction Id");
        int transactionId=Convert.ToInt32(Console.ReadLine());
         await FetchTransactionDetails(transactionId);
        await FetchTransactionsFromRESTAPI();
       await InsertTransactoin();
      await UpdateTransaction();
      await DeleteTransaction();


   }

    private static async Task FetchAccountDetails(int accountId)
    {
        Console.WriteLine("**********Account Details********** ");
        Account account = new Account();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5181/api/accounts/getaccountdetails/" + accountId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                account = JsonConvert.DeserializeObject<Account>(apiResponse);
                // Console.WriteLine("AccountId"=account.AccountId + " ," +"AccountNumber"= account.AccountNumber + " ," +"IfscCode"= account.IFSCCode + " ," +"RegisterDate"= account.RegisterDate + " ," +"Balance"= account.Balance);
                Console.WriteLine("AccountId=" + account.AccountId);
                Console.WriteLine("AccountNumber=" + account.AccountNumber);
                Console.WriteLine("IfscCode=" + account.RegisterDate);
                Console.WriteLine("RegisterDate=" + account.RegisterDate);
                Console.WriteLine("Balance=" + account.Balance);
                Console.WriteLine();
            }

        }
    }


    public static async Task FetchAccountsFromRESTAPI()

    {
        Console.WriteLine("*****************Account List***********");
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
                    Console.WriteLine("AccountId="+","+account.AccountId + " ," +"AccountNumber="+","+ account.AccountNumber + " ," +"IFSCCode="+","+ account.IFSCCode + " ," +"RegisterDate="+","+ account.RegisterDate + " ," +"Balance="+","+ account.Balance);

            }
        }
    }

    public static async Task InsertAccount()
    {
        Console.WriteLine("************Insert new Account******************");
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
                  string res = JsonConvert.DeserializeObject<string>(content);
                Console.WriteLine(res);
                if (res == "true")
                {
                    Console.WriteLine("Account Insert Sucessfully");
                }
                else
                {
                    Console.WriteLine("Account is not Inserted ");
                }
            }
        }
    }
    public static async Task UpdateAccount()
    {
        Console.WriteLine("****************Update Account**************");
        Console.WriteLine("Enter AccountId");
        int accountId = int.Parse(Console.ReadLine());
        // int accountId = Convert.ToInt32(Console.ReadLine());
        await FetchAccountDetails(accountId);

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
            AccountId = accountId,
            AccountNumber = accountNumber,
            IFSCCode = ifscCode,
            RegisterDate = registerDate,
            Balance = balance,
        };
        string jsonAccount = System.Text.Json.JsonSerializer.Serialize(account);
        var requestContent = new StringContent(jsonAccount, Encoding.UTF8, "application/json");
        using (var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:5181/api/accounts/update/" + accountId;
            using (var response = await httpClient.PutAsync(apiUrl, requestContent))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                string res = JsonConvert.DeserializeObject<string>(content);
                Console.WriteLine(res);
                if (res == "true")
                {
                    Console.WriteLine("Account Updated Sucessfully");
                }
                else
                {
                    Console.WriteLine("Account Does not Exist");
                }
            }
        }
    }
    public static async Task DeleteAccount()
    {
        Console.WriteLine("***********Delete Account********");
        Console.WriteLine("Enter AccountId You Want TO Delete");
        int accountId = int.Parse(Console.ReadLine());

        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.DeleteAsync("http://localhost:5181/api/accounts/delete/" + accountId))
            {
                response.EnsureSuccessStatusCode();
                response.Content.ReadAsStringAsync();
                Console.WriteLine("Account Is Deleted ");


            }


        }


Console.WriteLine("**********************************************************************");

    }

 private static async Task FetchTransactionDetails(int transactionId)
    {
        Transaction transaction = new Transaction();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5181/api/transaction/gettransactiondetails/" + transactionId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                transaction = JsonConvert.DeserializeObject<Transaction>(apiResponse);
                Console.WriteLine("FromAccountNumber=" + transaction.FromAccountNumber);
                Console.WriteLine("ToAccountNumber=" + transaction.ToAccountNumber);
                Console.WriteLine("TransactionDate=" + transaction.TransactionDate);
                Console.WriteLine("Amount=" + transaction.Amount);
                Console.WriteLine();
            }

        }
    }

     public static async Task FetchTransactionsFromRESTAPI()    {
        Console.Write("****Transaction Details********");
        //consume REST API 
        List<Transaction> transactions = new List<Transaction>();

        //access data from rest api using asynchronous
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5181/api/transaction/gettransactions"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                transactions = JsonConvert.DeserializeObject<List<Transaction>>(apiResponse);
                    
                foreach (var transaction in transactions)
                 Console.WriteLine(transaction.TransactionId + " ," + transaction.FromAccountNumber + " ," + transaction.ToAccountNumber + " ," + transaction.TransactionDate + " ," + transaction.Amount);
            
            }
        }
    }

     public static async Task InsertTransactoin()
    {
        Console.WriteLine("Insert new Transaction");
        Console.WriteLine("Enter FromAccountNumber ");
        long fromAccountNumber = long.Parse(Console.ReadLine());
        Console.WriteLine("Enter ToAccountNumber ");
        long toAccountNumber=long.Parse(Console.ReadLine());
        Console.WriteLine("Enter Transaction Date");
        string transactionDate = Console.ReadLine();
        Console.WriteLine("Enter Amount");
        double amount = double.Parse(Console.ReadLine());

        Transaction transaction = new Transaction()
        {

            
            FromAccountNumber=fromAccountNumber,
            ToAccountNumber = toAccountNumber,
            TransactionDate = transactionDate,
            Amount = amount,
        };

        string jsonTransaction = System.Text.Json.JsonSerializer.Serialize(transaction);
        var requestContent = new StringContent(jsonTransaction, Encoding.UTF8, "application/json");
        using (var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:5181/api/transaction/addtransaction";
            using (var response = await httpClient.PostAsync(apiUrl, requestContent))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }
        }
    }
    public static async Task UpdateTransaction()
    {
        Console.WriteLine("Update Transaction");
        Console.WriteLine("Enter TransactionId");
        int transactionId = int.Parse(Console.ReadLine());
       await FetchTransactionDetails(transactionId);
        
        //  Console.WriteLine("Enter FromAccountNumber ");
        // long fromAccountNumber =long.Parse(Console.ReadLine());
        Console.WriteLine("Enter ToAccountNumber ");
        long toAccountNumber = long.Parse(Console.ReadLine());
        Console.WriteLine("Enter Transaction Date");
        string transactionDate = Console.ReadLine();
        Console.WriteLine("Enter Amount");
        double amount = double.Parse(Console.ReadLine());
        Transaction transaction = new Transaction()
        {
            TransactionId= transactionId,
           // FromAccountNumber=fromAccountNumber,
            ToAccountNumber = toAccountNumber,
            TransactionDate = transactionDate,
            Amount = amount,
        };
        string jsonTransaction = System.Text.Json.JsonSerializer.Serialize(transaction);
        var requestContent = new StringContent(jsonTransaction, Encoding.UTF8, "application/json");
        using (var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:5181/api/transaction/update/" + transactionId;
            using (var response = await httpClient.PutAsync(apiUrl, requestContent))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                string res = JsonConvert.DeserializeObject<string>(content);
                Console.WriteLine(res);
                if (res == "true")
                {
                    Console.WriteLine("Transaction Updated Sucessfully");
                }
                else
                {
                    Console.WriteLine("Transaction Does not Exist");
                }
            }
        }
    }


    public static async Task DeleteTransaction()
    {
        Console.WriteLine("Enter TransactionId You Want TO Delete");
        int transactionId = int.Parse(Console.ReadLine());

        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.DeleteAsync("http://localhost:5181/api/transaction/delete/" + transactionId))
            {
                response.EnsureSuccessStatusCode();
                response.Content.ReadAsStringAsync();
                Console.WriteLine("Transaction Is Deleted ");


            }


        }

        
Console.WriteLine("**********************************************************************");

    }


 }






