using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using JwtTokan.Entities;
using JwtTokan.Helpers;
using JwtTokan.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
namespace JwtTokan.Repositories;
public class UserRepository : IUserRepository
{

    private readonly IConfiguration _configuration;
    private readonly string _conString;

    private readonly AppSettings _appsettings;

    public UserRepository(IConfiguration configuration,IOptions<AppSettings> appSettings)
    {

        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
        _appsettings = appSettings.Value;
    }


    public AuthenticateResponse Authenticate(AuthenticateRequest request)
    {
        User user = GetUser(request);
        // return null if user not found
        if (user == null){ return null;}
        // authentication successful so generate jwt token
        var token = generateJwtToken(user);
        return new AuthenticateResponse(user, token);
    }
    public List<User> GetAll()
    {
        List<User> users = new List<User>();

        MySqlConnection con = new MySqlConnection();

        con.ConnectionString = _conString;


        try
        {

            string query = "SELECT * FROM users";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                int userId = int.Parse(reader["user_id"].ToString());

                string email = reader["email"].ToString();

                string contactNumber = reader["contact_number"].ToString();

                string password = reader["password"].ToString();


                User user = new User
                {

                    UserId = userId,
                    Email = email,
                    ContactNumber = contactNumber,
                    Password = password

                };

                users.Add(user);

            }

            reader.Close();

        }
        catch (Exception ee)
        {
            throw ee;
        }
        finally
        {

            con.Close();
        }
        return users;
    }

 public User GetById(int id)
    {
        User user = new User();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {

            string query = "SELECT * FROM users where user_id =@id";
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);

            command.Parameters.AddWithValue("@id", id);
           
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {

                int userId = int.Parse(reader["user_id"].ToString());

                string userEmail = reader["email"].ToString();

                string contactNumber = reader["contact_number"].ToString();

                string userPassword = reader["password"].ToString();


                user = new User
                {

                    UserId = userId,
                    Email = userEmail,
                    ContactNumber = contactNumber,
                    Password = userPassword

                };
            }

            reader.Close();

        }
        catch (Exception ee)
        {

            throw ee;
        }
        finally
        {
            con.Close();
        }
        Console.WriteLine(user);
        return user;

    }

    public User GetUser(AuthenticateRequest request)
    {
        User user = new User();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {

            string query = "SELECT * FROM users where email=@email AND password =@password";
            Console.WriteLine(query);
            con.Open();
            
            MySqlCommand command = new MySqlCommand(query, con);

            command.Parameters.AddWithValue("@email", request.Email);
            command.Parameters.AddWithValue("@password", request.Password);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                int userId = int.Parse(reader["user_id"].ToString());

                string userEmail = reader["email"].ToString();

                string contactNumber = reader["contact_number"].ToString();

                string userPassword = reader["password"].ToString();


                user = new User
                {

                    UserId = userId,
                    Email = userEmail,
                    ContactNumber = contactNumber,
                    Password = userPassword

                };
            }

            reader.Close();

        }
        catch (Exception ee)
        {

            throw ee;
        }
        finally
        {
            con.Close();
        }
        return user;

    }


public List<string> GetRolesOfUser(int userId)
    {
        List<string> roles = new List<string>();

        MySqlConnection con = new MySqlConnection();

        con.ConnectionString = _conString;


        try
        {

            string query ="SELECT role from roles where role_id in  (select role_id from userroles where user_id=@userId";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userId",userId);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                string roleName = reader["role"].ToString();

                 roles.Add(roleName);
            }
           
            
            reader.Close();

        }
        catch (Exception ee)
        {
            throw ee;
        }
        finally
        {

            con.Close();
        }
        return roles;
    }


    private string generateJwtToken(User user)

    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = System.Text.Encoding.ASCII.GetBytes(_appsettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor

        {

            Subject = new ClaimsIdentity(AllClaims(user.userId)),
             
            Expires = DateTime.UtcNow.AddDays(7),

            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),

       SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);

    }

      List<Claim> AllClaims(int id){

            List<Claim> claims =new List<Claim>();
            claims.Add( new Claim("id", user.UserId.ToString()) );
            List<string> roles=  GetRolesOfUser(id);
         

         foreach(string role in roles){

            claims.Add(new Claim("role",role));
         }
          return claims;
      }


}
