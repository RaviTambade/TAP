using JwtTokan.Entities;
using JwtTokan.Models;

namespace JwtTokan.Repositories
{

 public interface IUserRepository{

   AuthenticateResponse Authenticate(AuthenticateRequest request);


   public List<User> GetAll();


   public User GetUser(AuthenticateRequest request);

   public User GetById(int id);
 }

    
}