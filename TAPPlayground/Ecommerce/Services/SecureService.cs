

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
    public bool Register(User user) => _repo.Register(user);
    public bool ValidateUser(Credential user) => _repo.ValidateUser(user);

    public bool ChangePassword(User user) => _repo.ChangePassword(user);

    public bool UpdatePassword(ChangedCredential credential) => _repo.UpdatePassword(credential);

    public bool UpdateEmail(ChangedCredential credential) =>_repo.UpdateEmail(credential);
}