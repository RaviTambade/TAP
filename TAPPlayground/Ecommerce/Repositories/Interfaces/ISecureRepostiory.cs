using System.Net.Http.Headers;
using ECommerceApp.Models;
namespace ECommerceApp.Repositories.Interfaces;
public interface ISecureRepository{
  
bool RegisterCustomer(Customer customer);
bool ValidateUser(Credential user);
bool ChangePassword(ChangedCredential user);

}