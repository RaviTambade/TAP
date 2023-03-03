using SessionManagement.Models;

namespace SessionManagement.Repositories;

public interface IAddressRepository
{
    bool InsertAddress(Address address);
}