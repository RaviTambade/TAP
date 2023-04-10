

using DeliveryService.Models;
using DeliveryService.Repositories.Interfaces;
using DeliveryService.Services.Interfaces;

namespace DeliveryService.Services;

public class DeliveryServices : IDeliveryService
{
    private readonly IDeliveryRepository _repo;

    public DeliveryServices(IDeliveryRepository repo)
    {
        _repo = repo;
    }

    public List<Delivery> GetAll() => _repo.GetAll();


    public Delivery GetById(int id)
    {
        return _repo.GetById(id);
    }

   public bool Insert(Delivery delivery)
    {
        return _repo.Insert(delivery);
    }

   public bool Update(Delivery delivery)
    {
        return _repo.Update(delivery);
    }
   public bool Delete(int id)
    {
        return _repo.Delete(id);
    }
    
}

