using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;
namespace ECommerceApp.Services;
public class CustomerAccountService:ICustomerAccountService{
private readonly ICustomerAccountRepository _repo;
public CustomerAccountService(ICustomerAccountRepository repo){
    this._repo=repo;

}
public List<CustomerAccount> GetAll()=>_repo.GetAll();
}