using CatalogService.Models;
using Newtonsoft.Json;
class Program
{
    private static readonly HttpClient client = new HttpClient();
    static async Task Main(string[] args)
    {
        await FetchProductsFromRESTAPI();
        await FetchProductsDetails();
        
    }

    private static async Task FetchProductsDetails()
    {
        Console.WriteLine("Enter the product ID:");
        int productId = Convert.ToInt32(Console.ReadLine());
        Product product = new Product();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:4001/api/products/getproductdetails/" + productId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                product = JsonConvert.DeserializeObject<Product>(apiResponse);
                Console.WriteLine(product.ProductId + " ," + product.ProductTitle + " ," + product.Description + " ," + product.StockAvailable + " ," + product.UnitPrice + " ," + product.ImageUrl + " ," + product.CategoryId + " ," + product.SupplierId);
            }
        }
    }

    public static async Task FetchProductsFromRESTAPI()
    {
        //consume REST API 
        List<Product> products = new List<Product>();
        //access data from rest api using asynchronous
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:4001/api/products/getallproducts"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                products = JsonConvert.DeserializeObject<List<Product>>(apiResponse);

                foreach (var product in products)
                    Console.WriteLine(product.ProductId + " ," + product.ProductTitle + " ," + product.Description + " ," + product.StockAvailable + " ," + product.UnitPrice + " ," + product.ImageUrl + " ," + product.CategoryId + " ," + product.SupplierId);

            }
        }
    }
}

