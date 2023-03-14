using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;

public interface ITransactionRepository
{
    public List<Transaction> GetAllTransaction();
    
}