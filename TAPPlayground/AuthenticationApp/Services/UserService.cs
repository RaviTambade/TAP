using AuthenticationApp.Models;
using AuthenticationApp.Repositories;

namespace AuthenticationApp.Services;
public class UserService : IUserService
{
  private readonly IUserRepository _repo;
  public UserService(IUserRepository repo){
    this._repo=repo;
  }

  public bool ValidateUser(User user){
    return _repo.ValidateUser(user);
  }
  public bool RegisterUser(User user){
    return _repo.RegisterUser(user);
  }
}