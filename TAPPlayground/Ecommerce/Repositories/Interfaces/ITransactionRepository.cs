using ECommerceApp.Models;

namespace ECommerceApp.Repositories.Interfaces;

public interface ITransactionRepository
{
    List<Transaction> GetAllTransaction();
    Transaction GetTransactionById(int id);
    bool InsertTransaction(Transaction transaction);
    bool UpdateTransaction(Transaction transaction);
    bool DeleteTransaction(int id);  
}