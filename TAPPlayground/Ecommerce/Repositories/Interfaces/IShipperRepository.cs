using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;

public interface IShipperRepository{

 public List<Shipper> GetAllShippers();


    Shipper GetShipperById(int id);

    bool InsertShipper(Shipper shipper);
    bool UpdateShipper(Shipper shipper);
    bool DeleteShipper(int id);
    


}