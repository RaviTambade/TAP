using AuthenticationService.Models;

namespace AuthenticationService.Repositories.Interfaces
{
    public interface IUserRepository
    {
        AuthenticateResponse Authenticate(AuthenticateRequest request);
        List<User> GetAll();
    }
}