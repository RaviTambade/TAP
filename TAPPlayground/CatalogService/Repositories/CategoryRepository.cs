using CatalogService.Models;
using CatalogService.Repositories.Interfaces;
using MySql.Data.MySqlClient;
namespace CatalogService.Repositories;
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

                Category category = new Category()
                {
                    CategoryId = id,
                    CategoryTitle = categoryTitle,
                    Description = description,
                    ImageUrl = imageUrl
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
    public Category GetDetails(int categoryId)
    {
        Category category = new Category();
        MySqlConnection connection = new MySqlConnection(_conString);
        try
        {
            string query = "SELECT * FROM categories WHERE category_id=@categoryId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@categoryId", categoryId);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                int id = int.Parse(reader["category_id"].ToString());
                string? categoryTitle = reader["category_title"].ToString();
                string? description = reader["description"].ToString();
                string? imageUrl = reader["image"].ToString();
                category = new Category()
                {
                    CategoryId = id,
                    CategoryTitle = categoryTitle,
                    Description = description,
                    ImageUrl = imageUrl
                };
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
        return category;
    }
    public bool Insert(Category category)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection(_conString);
        try
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "INSERT INTO categories(category_title,description,image)VALUES(@categoryTitle,@description,@imageurl)";
            command.Parameters.AddWithValue("@categoryTitle", category.CategoryTitle);
            command.Parameters.AddWithValue("@description", category.Description);
            command.Parameters.AddWithValue("@imageurl", category.ImageUrl);
            command.Connection = connection;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                status = true;
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
        return status;
    }
    public bool Update(Category category)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection(_conString);
        try
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "Update categories SET category_title=@categoryTitle,description=@description,image=@imageurl WHERE category_id=@categoryId";
            command.Parameters.AddWithValue("@categoryId", category.CategoryId);
            command.Parameters.AddWithValue("@categoryTitle", category.CategoryTitle);
            command.Parameters.AddWithValue("@description", category.Description);
            command.Parameters.AddWithValue("@imageurl", category.ImageUrl);
            command.Connection = connection;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                status = true;
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
        return status;
    }
    public bool Delete(int categoryId)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection(_conString);
        try
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "DELETE FROM categories WHERE category_id=@categoryId";
            command.Parameters.AddWithValue("@categoryId", categoryId);
            command.Connection = connection;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                status = true;
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
        return status;
    }
}