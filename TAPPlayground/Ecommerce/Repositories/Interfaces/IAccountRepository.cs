using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;
public interface IAccountRepository{

    List<Account> GetAllAccounts();

    Account GetAccountById(int id);

   bool InsertAccount(Account account);
   bool UpdateAccount(int id);
   bool DeleteAccount(int id);
   
}