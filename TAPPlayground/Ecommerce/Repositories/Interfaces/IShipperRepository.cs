using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;

public interface IShipperRepository{

 public List<Shipper> GetAll();


    Shipper GetById(int id);

    bool Insert(Shipper shipper);
    bool Update(Shipper shipper);
    bool Delete(int id);
    


}