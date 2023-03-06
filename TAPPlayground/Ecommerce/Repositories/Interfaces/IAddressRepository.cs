using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;
public interface IAddressRepository{

    List<Address> GetAddresses(int id);

    bool InsertAddress(Address address);
}
