using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;
public class AddressService:IAddressService{
    private readonly IAddressRepository _repo;
    public AddressService(IAddressRepository repo){
        this._repo=repo;
    }

    public Address GetById(int addressId)=>_repo.GetById(addressId);

    public List<Address> GetAll() => _repo.GetAll();

    public bool Insert(Address address)=>_repo.Insert(address);

     public bool Update(Address address)=> _repo.Update(address);
     public bool Delete(int id)=>_repo.Delete(id);
}


