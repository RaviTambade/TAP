
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

    public async Task <IEnumerable<Delivery>> GetAll(){
        var delivery= _repo.GetAll();
         Console.WriteLine("service");
         return await delivery;
    }

    public async Task<Delivery> GetById(int id)
    {
        return await _repo.GetById(id);
    }

   public async Task<bool> Insert(Delivery delivery)
    {
        return await _repo.Insert(delivery);
    }

   public async Task<bool> Update(Delivery delivery)
    {
        return await _repo.Update(delivery);
    }
   public async Task<bool> Delete(int id)
    {
        return await _repo.Delete(id);
    }
    
}

