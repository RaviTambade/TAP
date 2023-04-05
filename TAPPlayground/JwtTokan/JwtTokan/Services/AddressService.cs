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

    public List<Address> GetAll(int id) => _repo.GetAll(id);

    public bool Insert(Address address)=>_repo.Insert(address);
}