

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

    public List<Shipper> GetAll() => _repo.GetAll();


    public Shipper GetById(int id)
    {
        return _repo.GetById(id);
    }

   public bool Insert(Shipper shipper)
    {
        return _repo.Insert(shipper);
    }

   public bool Update(Shipper shipper)
    {
        return _repo.Update(shipper);
    }
   public bool Delete(int id)
    {
        return _repo.Delete(id);
    }
    
}

