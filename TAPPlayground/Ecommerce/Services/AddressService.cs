using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;
public class AddressService:IAddressService{
    private readonly IAddressRepository _repo;
    public AddressService(IAddressRepository repo){
        this._repo=repo;
    }

    public List<Address> GetAddresses(int id) => _repo.GetAddresses(id);

    public bool InsertAddress(Address address)=>_repo.InsertAddress(address);
}