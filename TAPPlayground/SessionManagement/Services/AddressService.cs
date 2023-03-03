using SessionManagement.Models;
using SessionManagement.Repositories;


namespace SessionManagement.Services;

public class AddressService : IAddressService
{

private readonly IAddressRepository _addressrepo;

    public AddressService(IAddressRepository addressrepo)
    {
        _addressrepo = addressrepo;
    }

    public bool InsertAddress(Address address)
    {
        return _addressrepo.InsertAddress(address);
    }
}