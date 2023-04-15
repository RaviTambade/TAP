using PaymentProcessing;
using System.Text;
using Newtonsoft.Json;


namespace ConsoleUsersClientApp
{

    class Program
    {
         private static readonly HttpClient client = new HttpClient();
        

        static async  Task Main(string[] args)
        {

           await DeletePayment();
           Console.WriteLine("All Payment Details");
        }


        public static async  Task  FetchPaymentsFromRESTAPI(){
        
        //consume REST API 
        IEnumerable<Payment> reservationList = new List<Payment>();
        //access data from rest api using asynchronous
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5054/api/payments/getallpayments"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                   
                    reservationList = JsonConvert.DeserializeObject<IEnumerable<Payment>>(apiResponse);

                  foreach (var repo in reservationList){
                        Console.WriteLine(repo.PaymentId + " ," + repo.PaymentDate +" ,"+repo.PaymentMode+" ,"+repo.TransactionId+" ,"+repo.OrderId );
                  }
                }
        }
        }



        public  static async Task InsertPayment(){

            Console.WriteLine("Insert new Payment=>");
            Console.WriteLine("Insert payment date=>");
            DateTime paymentDate=DateTime.Parse(Console.ReadLine());


            Console.WriteLine("Insert paymentMode=>");
            string paymentMode= Console.ReadLine();

            Console.WriteLine("Insert transactionId=>");
            int transactionId= int.Parse(Console.ReadLine());

            Console.WriteLine("Insert OrderId=>");
            int orderId= int.Parse(Console.ReadLine());



            Payment payment = new Payment(){

                 PaymentDate=paymentDate,
                 PaymentMode=paymentMode,
                 TransactionId=transactionId,
                 OrderId=orderId
                 };

             string jsonPayment=System.Text.Json.JsonSerializer.Serialize(payment);
             var requestContent=new StringContent(jsonPayment,Encoding.UTF8,"application/json");
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




        public static async Task UpdatePayment(){

         Console.WriteLine("Update payment by Id=>");
         int paymentId= int.Parse(Console.ReadLine());

         Payment payment =new Payment();

         using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5054/api/payments/getpaymentdetails/"+paymentId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                   
                    payment = JsonConvert.DeserializeObject<Payment>(apiResponse);
                }
               }

            Console.WriteLine("Insert payment date=>");
             payment.PaymentDate=DateTime.Parse(Console.ReadLine());


            Console.WriteLine("Insert paymentMode=>");
             payment.PaymentMode= Console.ReadLine();

            Console.WriteLine("Insert transactionId=>");
            payment.TransactionId= int.Parse(Console.ReadLine());

            Console.WriteLine("Insert OrderId=>");
            payment.OrderId= int.Parse(Console.ReadLine());
            

            string jsonPayment=System.Text.Json.JsonSerializer.Serialize(payment);
             var requestContent=new StringContent(jsonPayment,Encoding.UTF8,"application/json");
             using(var httpClient=new HttpClient())
             {
                string apiUrl="http://localhost:5054/api/payments/update/"+payment.PaymentId;
                using( var response= await httpClient.PutAsync(apiUrl,requestContent))
                {
                    response.EnsureSuccessStatusCode();
                    var Content= await response.Content.ReadAsStringAsync();
                }
             }

           Console.WriteLine("Payment updated succesfully");


        }



        private static async Task DeletePayment(){
             Console.WriteLine(" Delete payment by Id=>");
             int paymentId= int.Parse(Console.ReadLine());

             using(var httpClient=new HttpClient())
             {
                string apiUrl="http://localhost:5054/api/payments/delete/"+paymentId;
                using( var response= await httpClient.DeleteAsync(apiUrl))
                {
                    response.EnsureSuccessStatusCode();
                    var Content= await response.Content.ReadAsStringAsync();
                }
             }

           Console.WriteLine("Payment Deleted succesfully");

 
        }
    }
}
