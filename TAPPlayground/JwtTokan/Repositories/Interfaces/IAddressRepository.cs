using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;
public interface IAddressRepository{

    List<Address> GetAll();

    bool Insert(Address address);

     Address GetById(int addressId);

      bool Update(Address address);
      bool Delete(int addressId);


}
