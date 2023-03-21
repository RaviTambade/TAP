using ECommerceApp.Repositories.Interfaces;
using MySql.EntityFrameworkCore;
using ECommerceApp.Models;
using ECommerceApp.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace ECommerceApp.Repositories;


public class AccountORMRepository : IAccountRepository
{
    public List<Account> GetAll()
    {
        using (var context = new AccountContext())
        {
            var accounts = from account in context.accounts select account;
            return accounts.ToList<Account>();
        }
    }
   public Account GetById(int accountId){

   }
public bool Insert(Account account)
{

}
public bool Update(Account account)
{

}
bool Delete(int accountId)
{

}
}