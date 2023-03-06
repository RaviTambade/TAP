using System.Data;
using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace ECommerceApp.Repositories;
public class DashboardRepository : IDashboardRepository
{

    public static string conString = "server=localhost;port=3306;user=root;password=password;database=Ecommerce";

    public List<object> GetProductsData(List<Product> products)
    {
        var productList = new List<Object>();                      //creates a new list to store the product data 
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = conString;
        try
        {
            connection.Open();
            foreach (Product product in products)                   //loop through each product in the input list
            {

                MySqlCommand command = new MySqlCommand("getrevenue", connection);             //create new mysqlcommand object to call the getrevenue stored procedure
                command.CommandType = CommandType.StoredProcedure;                             
                command.Parameters.Add(new MySqlParameter("@productid", product.ProductId));     //set the productid input parameter for the stored procedure
                command.Parameters.Add(new MySqlParameter("@totalrevenue", MySqlDbType.Double));   //set the totalrevenue output parameter for the stored procedure
                command.Parameters["@totalrevenue"].Direction = ParameterDirection.Output;         //property that is used to get or set the direction of the mysql parameter of @totalrevenue in the mysqlcommand object 
                //direction property is a part of the mysqlParameter classs ,which is defined to input/output
                command.ExecuteNonQuery();                   

                var revenue = command.Parameters["@totalrevenue"].Value;               //Get the totalrevenue output parameter value 

                var productJson = new                           //create new object to store the product data
                {
                    Id = product.ProductId,
                    title = product.Title,
                    TotalRevenue = revenue
                };
                productList.Add(productJson);                      //create the product data to the list
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            connection.Close();
        }
        return productList;
    }
}