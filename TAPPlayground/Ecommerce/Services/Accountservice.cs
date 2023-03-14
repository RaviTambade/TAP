using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;
namespace ECommerceApp.Services;
public class AccountService:IAccountService{
private readonly IAccountRepository _repo;
public AccountService(IAccountRepository repo){
    this._repo=repo;

}
public List<Account> GetAllAccounts()=>_repo.GetAllAccounts();
public Account GetAccountById(int id)=>_repo.GetAccountById(id);
public bool InsertAccount(Account account)=>_repo.InsertAccount(account);
public bool UpdateAccount(int id)=>_repo.UpdateAccount(id);
public bool DeleteAccount(int id)=>_repo.DeleteAccount(id);

}
