using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;
public interface IUserRepository{
    bool Validate(User user);
    List<User> GetAll();
}