using E_AgroServiceDemo.Models;

namespace E_AgroServiceDemo.Repositories.Interfaces;
public interface IUserRepository{
    public bool ValidateAdmin(User user);
        public bool ValidateFarmer(User user);

}