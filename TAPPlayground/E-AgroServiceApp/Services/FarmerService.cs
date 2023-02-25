using E_AgroServiceDemo.Repositories.Interfaces;
using E_AgroServiceDemo.Repositories;
using E_AgroServiceDemo.Models;
using E_AgroServiceDemo.Services.Interfaces;

namespace E_AgroServiceDemo.Services;

public class FarmerService:IFarmerService{
    private readonly IFarmerRepository _farmerrepo;

    public FarmerService(IFarmerRepository farmerrepo){
        this._farmerrepo=farmerrepo;
    }

    public bool DeleteFarmer(int id)
    {
      return _farmerrepo.DeleteFarmer(id);
    }

    public List<Farmer> GetAllFarmers()=> _farmerrepo.GetAllFarmers();

    public Farmer GetFarmerById(int id)
    {
      return _farmerrepo.GetFarmerById(id);
    }

    public bool InsertFarmer(Farmer farmer)
    {
        return _farmerrepo.InsertFarmer(farmer);
    }

    public bool UpdateFarmer(Farmer farmer)
    {
        return _farmerrepo.UpdateFarmer(farmer);
    }
}
