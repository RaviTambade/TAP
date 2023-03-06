using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;
public interface IUserRepository{
    bool ValidateUser(User user);
}