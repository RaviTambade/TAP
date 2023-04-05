using ECommerceApp.Models;

namespace ECommerceApp.Repositories
{

 public interface IUserRepository{

   AuthenticateResponse Authenticate(AuthenticateRequest request);


   public List<User> GetAll();


   public User GetUser(AuthenticateRequest request);

   public User GetById(int id);
 }

    
}