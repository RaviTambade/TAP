using System.Diagnostics;
using System.Text;
using CatalogService.Models;
using Newtonsoft.Json;
using System.Text.Json;
using System.Runtime.InteropServices;
class Program
{
    private static readonly HttpClient client = new HttpClient();
    static async Task Main(string[] args)
    {
        await FetchProductsFromRESTAPI();
        await FetchProductDetails();
        await InsertProduct();
        await UpdateProduct();
        await DeleteProduct();
        await GetAllCategories();
        await FetchCategoryDetails();
        await InsertCategory();
        await UpdateCategory();
        await DeleteCategory();
        await GetAllSuppliers();
        await FetchSupplierDetails();
        await InsertSupplier();
        await DeleteSupplier();
        await HikePrice();
    }

    private static async Task FetchProductDetails()
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
    public static async Task InsertProduct()
    {
        Console.WriteLine("Inserting new product=>");
        Console.WriteLine("Enter the product Title:");
        string productTitle = Console.ReadLine();

        Console.WriteLine("Enter the product Description:");
        string description = Console.ReadLine();

        Console.WriteLine("Enter the product StockAvailable:");
        int stockAvailable = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the product UnitPrice:");
        int unitPrice = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the product ImageUrl:");
        string imageUrl = Console.ReadLine();

        Console.WriteLine("Enter the product CategoryID:");
        int categoryId = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the product SupplierID:");
        int supplierId = int.Parse(Console.ReadLine());



        Product product = new Product()
        {

            ProductTitle = productTitle,
            Description = description,
            StockAvailable = stockAvailable,
            UnitPrice = unitPrice,
            ImageUrl = imageUrl,
            CategoryId = categoryId,
            SupplierId = supplierId
        };

        string jsonProduct = System.Text.Json.JsonSerializer.Serialize(product);
        var requestContent = new StringContent(jsonProduct, Encoding.UTF8, "application/json");
        using (var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:4001/api/products/addproduct";
            using (var response = await httpClient.PostAsync(apiUrl, requestContent))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }

        }
    }
    public static async Task UpdateProduct()
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
            }
        }
        Console.WriteLine("Enter the product Title:");
        product.ProductTitle = Console.ReadLine();

        Console.WriteLine("Enter the product Description:");
        product.Description = Console.ReadLine();

        Console.WriteLine("Enter the product StockAvailable:");
        product.StockAvailable = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the product UnitPrice:");
        product.UnitPrice = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the product ImageUrl:");
        product.ImageUrl = Console.ReadLine();

        Console.WriteLine("Enter the product CategoryID:");
        product.CategoryId = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the product SupplierID:");
        product.SupplierId = int.Parse(Console.ReadLine());

        string jsonProduct = System.Text.Json.JsonSerializer.Serialize(product);
        var requestContent = new StringContent(jsonProduct, Encoding.UTF8, "application/json");
        using (var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:4001/api/products/update/" + product.ProductId;
            using (var response = await httpClient.PutAsync(apiUrl, requestContent))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }

        }
    }
    private static async Task DeleteProduct()
    {
        Console.WriteLine("Enter the product ID:");
        int productId = Convert.ToInt32(Console.ReadLine());
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.DeleteAsync("http://localhost:4001/api/products/delete/" + productId))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }
        }
    }
    private static async Task HikePrice()
    {
        Console.WriteLine("Enter the percentage:");
        double percentage = double.Parse(Console.ReadLine());
        using (var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:4001/api/products/hikeprice/" + percentage;
            using (var response = await httpClient.PutAsync(apiUrl, null))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }
        }
    }
    private static async Task FetchCategoryDetails()
    {
        Console.WriteLine("Enter the category ID:");
        int categoryId = Convert.ToInt32(Console.ReadLine());
        Category category = new Category();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:4001/api/categories/getdetails/" + categoryId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                category = JsonConvert.DeserializeObject<Category>(apiResponse);
                Console.WriteLine(category.CategoryId + "," + category.CategoryTitle + "," + category.Description + "," + category.ImageUrl);
            }
        }
    }

    public static async Task GetAllCategories()
    {
        //consume REST API 
        List<Category> categories = new List<Category>();
        //access data from rest api using asynchronous
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:4001/api/categories/getallcategories"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                categories = JsonConvert.DeserializeObject<List<Category>>(apiResponse);

                foreach (var category in categories)
                    Console.WriteLine(category.CategoryId + "," + category.CategoryTitle + "," + category.Description + "," + category.ImageUrl);

            }
        }
    }
    public static async Task InsertCategory()
    {
        Console.WriteLine("Inserting new category=>");

        Console.WriteLine("Enter the category Title:");
        string categoryTitle = Console.ReadLine();

        Console.WriteLine("Enter the category Description:");
        string description = Console.ReadLine();

        Console.WriteLine("Enter the category ImageUrl:");
        string imageUrl = Console.ReadLine();


        Category category = new Category()
        {

            CategoryTitle = categoryTitle,
            Description = description,
            ImageUrl = imageUrl
        };

        string jsonCategory = System.Text.Json.JsonSerializer.Serialize(category);
        var requestContent = new StringContent(jsonCategory, Encoding.UTF8, "application/json");
        using (var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:4001/api/categories/insert";
            using (var response = await httpClient.PostAsync(apiUrl, requestContent))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }

        }
    }
    public static async Task UpdateCategory()
    {
        Console.WriteLine("Enter the category ID:");
        int categoryId = Convert.ToInt32(Console.ReadLine());
        Category category = new Category();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:4001/api/categories/getdetails/" + categoryId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                category = JsonConvert.DeserializeObject<Category>(apiResponse);
            }
        }
        Console.WriteLine("Enter the category Title:");
        category.CategoryTitle = Console.ReadLine();

        Console.WriteLine("Enter the category Description:");
        category.Description = Console.ReadLine();

        Console.WriteLine("Enter the category ImageUrl:");
        category.ImageUrl = Console.ReadLine();



        string jsonCategory = System.Text.Json.JsonSerializer.Serialize(category);
        var requestContent = new StringContent(jsonCategory, Encoding.UTF8, "application/json");
        using (var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:4001/api/categories/update/" + category.CategoryId;
            using (var response = await httpClient.PutAsync(apiUrl, requestContent))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }

        }
    }
    private static async Task DeleteCategory()
    {
        Console.WriteLine("Enter the category ID:");
        int categoryId = Convert.ToInt32(Console.ReadLine());
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.DeleteAsync("http://localhost:4001/api/categories/delete/" + categoryId))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }
        }
    }
    private static async Task FetchSupplierDetails()
    {
        Console.WriteLine("Enter the supplier ID:");
        int supplierId = Convert.ToInt32(Console.ReadLine());
        Supplier supplier = new Supplier();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:4001/api/suppliers/getdetails/" + supplierId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                supplier = JsonConvert.DeserializeObject<Supplier>(apiResponse);
                Console.WriteLine(supplier.SupplierId + "," + supplier.SupplierName + "," + supplier.CompanyName + "," + supplier.ContactNumber + "," + supplier.Address + "," + supplier.Email + "," + supplier.Password + "," + supplier.City + "," + supplier.State + "," + supplier.AccountNumber);
            }
        }
    }

    public static async Task GetAllSuppliers()
    {
        //consume REST API 
        List<Supplier> suppliers = new List<Supplier>();
        //access data from rest api using asynchronous
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:4001/api/suppliers/getallsuppliers"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                suppliers = JsonConvert.DeserializeObject<List<Supplier>>(apiResponse);

                foreach (var supplier in suppliers)
                    Console.WriteLine(supplier.SupplierId + "," + supplier.SupplierName + "," + supplier.CompanyName + "," + supplier.ContactNumber + "," + supplier.Address + "," + supplier.Email + "," + supplier.Password + "," + supplier.City + "," + supplier.State + "," + supplier.AccountNumber);

            }
        }
    }
    public static async Task InsertSupplier()
    {
        Console.WriteLine("Inserting new supplier=>");

        Console.WriteLine("Enter the supplier name:");
        string supplierName = Console.ReadLine();

        Console.WriteLine("Enter the company name:");
        string companyName = Console.ReadLine();

        Console.WriteLine("Enter the contact number:");
        string contactNumber = Console.ReadLine();

        Console.WriteLine("Enter the address:");
        string address = Console.ReadLine();

        Console.WriteLine("Enter the email:");
        string email = Console.ReadLine();

        Console.WriteLine("Enter the password :");
        string password = Console.ReadLine();

        Console.WriteLine("Enter the city :");
        string city = Console.ReadLine();

        Console.WriteLine("Enter the state :");
        string state = Console.ReadLine();

        Console.WriteLine("Enter the account number:");
        long accountNumber = long.Parse(Console.ReadLine());


        Supplier supplier = new Supplier()
        {
            SupplierName = supplierName,
            CompanyName = companyName,
            ContactNumber = contactNumber,
            Email = email,
            Address = address,
            Password = password,
            City = city,
            State = state,
            AccountNumber = accountNumber
        };

        string jsonSupplier = System.Text.Json.JsonSerializer.Serialize(supplier);
        var requestContent = new StringContent(jsonSupplier, Encoding.UTF8, "application/json");
        using (var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:4001/api/suppliers/insert";
            using (var response = await httpClient.PostAsync(apiUrl, requestContent))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }

        }
    }
    public static async Task UpdateSupplier()
    {
        Console.WriteLine("Enter the supplier ID:");
        int supplierId = Convert.ToInt32(Console.ReadLine());
        Supplier supplier = new Supplier();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:4001/api/suppliers/getdetails/" + supplierId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                supplier = JsonConvert.DeserializeObject<Supplier>(apiResponse);
            }
        }
        Console.WriteLine("Enter the supplier name:");
        supplier.SupplierName = Console.ReadLine();

        Console.WriteLine("Enter the company name:");
        supplier.CompanyName = Console.ReadLine();

        Console.WriteLine("Enter the contact number:");
        supplier.ContactNumber = Console.ReadLine();

        Console.WriteLine("Enter the address:");
        supplier.Address = Console.ReadLine();

        Console.WriteLine("Enter the email:");
        supplier.Email = Console.ReadLine();

        Console.WriteLine("Enter the password :");
        supplier.Password = Console.ReadLine();

        Console.WriteLine("Enter the city :");
        supplier.City = Console.ReadLine();

        Console.WriteLine("Enter the state :");
        supplier.State = Console.ReadLine();

        Console.WriteLine("Enter the account number:");
        supplier.AccountNumber = long.Parse(Console.ReadLine());



        string jsonSupplier = System.Text.Json.JsonSerializer.Serialize(supplier);
        var requestContent = new StringContent(jsonSupplier, Encoding.UTF8, "application/json");
        using (var httpClient = new HttpClient())
        {
            string apiUrl = "http://localhost:4001/api/suppliers/update/" + supplier.SupplierId;
            using (var response = await httpClient.PutAsync(apiUrl, requestContent))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }

        }
    }
    private static async Task DeleteSupplier()
    {
        Console.WriteLine("Enter the supplier ID:");
        int supplierId = Convert.ToInt32(Console.ReadLine());
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.DeleteAsync("http://localhost:4001/api/suppliers/delete/" + supplierId))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
            }
        }
    }
}

