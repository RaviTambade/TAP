using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;
public interface IAddressRepository{

    List<Address> GetAll(int id);

    bool Insert(Address address);

     Address GetById(int addressId);
}
