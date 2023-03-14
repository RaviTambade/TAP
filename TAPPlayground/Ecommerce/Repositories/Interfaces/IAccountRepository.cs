using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;
public interface IAccountRepository{

    List<Account> GetAllAccounts();

    Account GetAccountById(int id);

   bool InsertAccount(Account account);
   bool UpdateAccount(Account account);
   bool DeleteAccount(int id);
   
}