using E_AgroServiceDemo.Repositories.Interfaces;
using E_AgroServiceDemo.Repositories;
using E_AgroServiceDemo.Models;
using E_AgroServiceDemo.Services.Interfaces;

namespace E_AgroServiceDemo.Services;

public class UserService :IUserService
{
  private readonly IUserRepository _repo;
  public UserService(IUserRepository repo){
    this._repo=repo;
  }

  public bool ValidateAdmin(User user){
    return _repo.ValidateAdmin(user);
  }

  public bool ValidateFarmer(User user){
    return _repo.ValidateFarmer(user);
  }


}