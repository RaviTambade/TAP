using E_AgroServiceDemo.Models;

namespace E_AgroServiceDemo.Repositories.Interfaces;
public interface IFarmerRepository{
    public List<Farmer> GetAllFarmers();
}