

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
    
}