

using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;

public class SecureService : ISecureService
{
    private readonly ISecureRepository _repo;

    public SecureService(ISecureRepository repo)
    {
        _repo = repo;
    }
    public bool RegisterCustomer(Customer customer)=>_repo.RegisterCustomer(customer);
    public bool ValidateUser(Credential user)=> _repo.ValidateUser(user);

    public bool ChangePassword(ChangedCredential user)=>_repo.ChangePassword(user);
}