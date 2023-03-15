

using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;

public class SecureService : ISecureService
{
    private readonly ISecureService _repo;

    public SecureService(ISecureService repo)
    {
        _repo = repo;
    }
    public bool RegisterCustomer(Customer customer)=>_repo.RegisterCustomer(customer);
    public bool Validate(User user)=> _repo.ValidateUser(user);

}