using ECommerceApp.Repositories.Interfaces;
using MySql.EntityFrameworkCore;
using ECommerceApp.Models;
using ECommerceApp.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace ECommerceApp.Repositories;


public class AccountORMRepository : IAccountRepository
{
    private IConfiguration _configuration;

    public AccountORMRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public List<Account> GetAll()
    {
        using (var context = new AccountContext(_configuration))
        {
             var accounts = context.Accounts.ToList();
            return accounts;
        }
    }
   public Account GetById(int accountId)
   {
throw new NotImplementedException();
   }
public bool Insert(Account account)
{
throw new NotImplementedException();
}
public bool Update(Account account)
{
throw new NotImplementedException();
}
 public bool Delete(int accountId)
{
throw new NotImplementedException();
}
}