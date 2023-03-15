

using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;

public class ShipperService : IShipperService
{
    private readonly IShipperRepository _repo;

    public ShipperService(IShipperRepository repo)
    {
        _repo = repo;
    }

    public List<Shipper> GetAllShippers() => _repo.GetAllShippers();


    public Shipper GetShipperById(int id)
    {
        return _repo.GetShipperById(id);
    }

   public bool InsertShipper(Shipper shipper)
    {
        return _repo.InsertShipper(shipper);
    }

   public bool UpdateShipper(Shipper shipper)
    {
        return _repo.UpdateShipper(shipper);
    }
   public bool DeleteShipper(int id)
    {
        return _repo.DeleteShipper(id);
    }
    
}

