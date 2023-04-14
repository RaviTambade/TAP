using PaymentProcessing;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace ConsoleUsersClientApp
{

    class Program
    {
         private static readonly HttpClient client = new HttpClient();
        

        static async  Task Main(string[] args)
        {

           await FetchPaymentsFromRESTAPI();
           Console.WriteLine("All Payment Details");
        }


        public static async  Task  FetchPaymentsFromRESTAPI(){
        
        //consume REST API 
        List<Payment> reservationList = new List<Payment>();
        //access data from rest api using asynchronous
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5054/api/payments/getallpayments"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                   
                    reservationList = JsonConvert.DeserializeObject<List<Payment>>(apiResponse);

                  foreach (var repo in reservationList)
                        Console.WriteLine(repo.PaymentId + " ," + repo.PaymentDate +" ,"+repo.PaymentMode+" ,"+repo.TransactionId+" ,"+repo.OrderId );

                }
        }
        }



        public async Task InsertPayment(){

            Console.WriteLine("Insert new Payment=>");
            Console.WriteLine("Insert payment date=>");
            string PaymentDate= Console.ReadLine();


            Console.WriteLine("Insert paymentMode=>");
            string PaymentMode= Console.ReadLine();

            Console.WriteLine("Insert transactionId=>");
            int TransactionId= int.Parse(Console.ReadLine());

            Console.WriteLine("Insert OrderId=>");
            int OrderId= int.Parse(Console.ReadLine());



            Payment payment = new Payment(){

                 PaymentDate=PaymentDate,
                 PaymentMode=PaymentMode,
                 TransactionId=TransactionId,
                 OrderId=OrderId
                 };

             string jsonPayment=System.Text.JsonSerializer.Serilize(payment);
             var requestContent=new StringContent(jsonPayment,encoding.UTF8,"application/json");
             using(var httpClient=new HttpClient())
             {
                string apiUrl="http://localhost:5054/api/payments/addpayment";
                using( var response= await httpClient.PostAsync(apiUrl,requestContent))
                {
                    response.EnsureSuccessStatusCode();
                    var Content= await response.Content.ReadAsStringAsync();
                }
             }

           Console.WriteLine("Payment Added succesfully");
        }




        public async Task UpdatePayment(){

         Console.WriteLine("Update payment by Id=>");
         int PaymentId= int.Parse(Console.ReadLine());

         

         using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5054/api/payments/getpaymentbyid"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                   
                    payment = JsonConvert.DeserializeObject<List<Payment>>(apiResponse);
                }
               }

            Console.WriteLine("Insert payment date=>");
            string PaymentDate= Console.ReadLine();


            Console.WriteLine("Insert paymentMode=>");
            string PaymentMode= Console.ReadLine();

            Console.WriteLine("Insert transactionId=>");
            int TransactionId= int.Parse(Console.ReadLine());

            Console.WriteLine("Insert OrderId=>");
            int OrderId= int.Parse(Console.ReadLine());
            

            string jsonPayment=System.Text.JsonSerializer.Serilize(payment);
             var requestContent=new StringContent(jsonPayment,encoding.UTF8,"application/json");
             using(var httpClient=new HttpClient())
             {
                string apiUrl="http://localhost:5054/api/payments/update";
                using( var response= await httpClient.PutAsync(apiUrl,requestContent))
                {
                    response.EnsureSuccessStatusCode();
                    var Content= await response.Content.ReadAsStringAsync();
                }
             }

           Console.WriteLine("Payment updated succesfully")


        }



        private static async Task DeletePayment(){
             Console.WriteLine(" Delete payment by Id=>");
             int PaymentId= int.Parse(Console.ReadLine());

             using(var httpClient=new HttpClient())
             {
                string apiUrl="http://localhost:5054/api/payments/delete";
                using( var response= await httpClient.DeleteAsync(apiUrl,requestContent))
                {
                    response.EnsureSuccessStatusCode();
                    var Content= await response.Content.ReadAsStringAsync();
                }
             }

           Console.WriteLine("Payment Deleted succesfully");

 
        }
    }
}
