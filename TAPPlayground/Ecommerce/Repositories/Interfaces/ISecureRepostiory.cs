using System.Net.Http.Headers;
using ECommerceApp.Models;
namespace ECommerceApp.Repositories.Interfaces;
public interface ISecureRepository{
  
  bool RegisterCustomer(Customer customer);
  bool ValidateUser(User user);
  bool ChangePassword(int id);

}