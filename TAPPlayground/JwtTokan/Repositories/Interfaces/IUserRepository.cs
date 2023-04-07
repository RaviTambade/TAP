using ECommerceApp.Models;

namespace ECommerceApp.Repositories
{

    public interface IUserRepository
    {

        AuthenticateResponse Authenticate(AuthenticateRequest request);
        List<User> GetAll();
        User GetUser(AuthenticateRequest request);
        User GetById(int id);
        bool ForgotPassword(User user);
        bool UpdatePassword(ChangedCredential credential);
        bool UpdateEmail(ChangedCredential credential);
    }


}