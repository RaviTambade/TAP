using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace ECommerceApp.Repositories;
public class CategoryRepository : ICategoryRepository
{

    private IConfiguration _configuration;
    private string _conString;

    public CategoryRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

    public List<Category> GetAll()
    {
       List<Category> categories = new List<Category>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {
            string query = "select * from categories";
            MySqlCommand command = new MySqlCommand(query, con);
            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = int.Parse(reader["category_id"].ToString());
                string? categoryTitle = reader["category_title"].ToString();
                string? description = reader["description"].ToString();
                string? imageUrl = reader["image"].ToString();
              
              Category category=new Category()
                {
                  CategoryId=id,
                  CategoryTitle=categoryTitle,
                  Description=description,
                  ImageUrl=imageUrl
                };
                categories.Add(category);
            }
            reader.Close();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
        return categories;

    }
}