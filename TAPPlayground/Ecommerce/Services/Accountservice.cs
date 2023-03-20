using System;
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
public List<Account> GetAll()=>_repo.GetAll();
public Account GetById(int id)=>_repo.GetById(id);
public bool Insert(Account account)=>_repo.Insert(account);
public bool Update(Account account)=>_repo.Update(account);
public bool Delete(Int32  id)=>_repo.Delete(id);

}
