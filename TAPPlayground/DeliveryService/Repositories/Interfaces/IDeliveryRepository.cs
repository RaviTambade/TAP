using DeliveryService.Models;

namespace DeliveryService.Repositories.Interfaces;

public interface IDeliveryRepository{

Task<IEnumerable<Delivery>> GetAll();


      Task<Delivery>  GetById(int id);

      Task<bool> Insert(Delivery delivery);
      Task<bool> Update(Delivery delivery);
      Task<bool> Delete(int id);
    
}