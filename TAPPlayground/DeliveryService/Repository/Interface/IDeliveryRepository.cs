using DeliveryService.Models;

namespace DeliveryService.Repositories.Interfaces;

public interface IDeliveryRepository{

 public List<Delivery> GetAll();


    Delivery GetById(int id);

    bool Insert(Delivery delivery);
    bool Update(Delivery delivery);
    bool Delete(int id);
    
}