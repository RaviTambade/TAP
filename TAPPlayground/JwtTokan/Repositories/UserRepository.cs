using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ECommerceApp.Helpers;
using ECommerceApp.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
namespace ECommerceApp.Repositories;
public class UserRepository : IUserRepository
{

    private readonly IConfiguration _configuration;
    private readonly string _conString;

    private readonly AppSettings _appsettings;

    public UserRepository(IConfiguration configuration, IOptions<AppSettings> appSettings)
    {

        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
        _appsettings = appSettings.Value;
    }


    public AuthenticateResponse Authenticate(AuthenticateRequest request)
    {
        User user = GetUser(request);
        Console.WriteLine(request.Email + "," + request.Password);
        // return null if user not found
        if (user == null) { return null; }
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

    public bool ForgotPassword(User user)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {

            string query = $"Update users SET password =@newPassword WHERE email=@email";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@newPassword", user.Password);
            cmd.Parameters.AddWithValue("@email", user.Email);
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected >= 1)
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
            con.Close();
        }
        return status;
    }

    public bool UpdatePassword(ChangedCredential credential)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {

            string query = $"Update users SET password =@newPassword WHERE email=@email AND password =@oldPassword";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@email", credential.Email);
            cmd.Parameters.AddWithValue("@newPassword", credential.NewPassword);
            cmd.Parameters.AddWithValue("@oldPassword", credential.OldPassword);
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected >= 1)
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
            con.Close();
        }
        return status;
    }

    public bool UpdateEmail(ChangedCredential credential)
    {
        bool status = false;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {

            string query = $"Update users SET email=@newemail  WHERE password =@password AND email=@email";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@email", credential.Email);
            cmd.Parameters.AddWithValue("@password", credential.OldPassword);
            cmd.Parameters.AddWithValue("@newemail", credential.NewEmail);
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected >= 1)
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
            con.Close();
        }
        return status;
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
        User user = null;
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = _conString;
        try
        {


            string query = "SELECT * FROM users where email=@email AND password =@password";
            Console.WriteLine(query);
            Console.WriteLine(request.Email);
            Console.WriteLine(request.Password);
            con.Open();

            MySqlCommand command = new MySqlCommand(query, con);

            command.Parameters.AddWithValue("@email", request.Email);
            command.Parameters.AddWithValue("@password", request.Password);
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
        return user;

    }


    public List<string> GetRolesOfUser(int userId)
    {
        List<string> roles = new List<string>();

        MySqlConnection con = new MySqlConnection();

        con.ConnectionString = _conString;


        try
        {

            string query = "SELECT role from roles where role_id in  (select role_id from user_roles where user_id=@userId)";
            Console.WriteLine(query);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userId", userId);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                string roleName = reader["role"].ToString();
                Console.WriteLine(roleName);

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

            Subject = new ClaimsIdentity(AllClaims(user)),

            Expires = DateTime.UtcNow.AddDays(7),

            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),

       SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);

    }

    List<Claim> AllClaims(User user)
    {

        List<Claim> claims = new List<Claim>();
        claims.Add(new Claim("id", user.UserId.ToString()));
        List<string> roles = GetRolesOfUser(user.UserId);


        foreach (string role in roles)
        {

            claims.Add(new Claim("role", role));
        }
        return claims;
    }
}
