using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;
public interface IAccountRepository{

    List<Account> GetAllAccounts();

    Account GetAccountById(int id);

   
}