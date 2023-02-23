using AuthenticationApp.Models;

namespace AuthenticationApp.Repositories;
public interface IUserRepository{
    public bool ValidateUser(User user);

    public bool RegisterUser(User user);
}