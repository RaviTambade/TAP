using System.Data;
using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;

namespace ECommerceApp.Repositories;
public class DashboardRepository : IDashboardRepository
{

    public static string conString = "server=localhost;port=3306;user=root;password=password;database=Ecommerce";

    // public List<object> GetProductsData(List<Product> products)
    // {
    //     var productList = new List<Object>();                      //creates a new list to store the product data 
    //     MySqlConnection connection = new MySqlConnection();
    //     connection.ConnectionString = conString;
    //     try
    //     {
    //         connection.Open();
    //         foreach (Product product in products)                   //loop through each product in the input list
    //         {

    //             MySqlCommand command = new MySqlCommand("getrevenue", connection);             //create new mysqlcommand object to call the getrevenue stored procedure
    //             command.CommandType = CommandType.StoredProcedure;                             
    //             command.Parameters.Add(new MySqlParameter("@productid", product.ProductId));     //set the productid input parameter for the stored procedure
    //             command.Parameters.Add(new MySqlParameter("@totalrevenue", MySqlDbType.Double));   //set the totalrevenue output parameter for the stored procedure
    //             command.Parameters["@totalrevenue"].Direction = ParameterDirection.Output;         //property that is used to get or set the direction of the mysql parameter of @totalrevenue in the mysqlcommand object 
    //             //direction property is a part of the mysqlParameter classs ,which is defined to input/output
    //             command.ExecuteNonQuery();                   

    //             var revenue = command.Parameters["@totalrevenue"].Value;               //Get the totalrevenue output parameter value 

    //             var productJson = new                           //create new object to store the product data
    //             {
    //                 Id = product.ProductId,
    //                 title = product.Title,
    //                 TotalRevenue = revenue
    //             };
    //             productList.Add(productJson);                      //create the product data to the list
    //         }
    //     }
    //     catch (Exception e)
    //     {
    //         throw e;
    //     }
    //     finally
    //     {
    //         connection.Close();
    //     }
    //     return productList;
    // }

    public List<RevenueModel> GetProductsData()
    {
        List<RevenueModel> revenues = new List<RevenueModel>();
        MySqlConnection connection = new MySqlConnection(conString);
        try
        {
            string query = "SELECT orderdetails.product_id,products.title, SUM(orderdetails.quantity) * products.unit_price AS totalrevenue FROM orderdetails, products WHERE orderdetails.product_id = products.product_id GROUP BY product_id";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = int.Parse(reader["product_id"].ToString());
                string title = reader["title"].ToString();
                double totalrevenue = double.Parse(reader["totalrevenue"].ToString());
                RevenueModel revenue = new RevenueModel
                {
                    ProductId = id,
                    Title = title,
                    TotalRevenue = totalrevenue
                };
                revenues.Add(revenue);
            }
            reader.Close();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            connection.Close();
        }
        return revenues;
    }
}