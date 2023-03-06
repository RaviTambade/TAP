using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _repo;
    public UserService(IUserRepository repo)
    {
        this._repo = repo;
    }

    public bool ValidateUser(User user) => _repo.ValidateUser(user);



}