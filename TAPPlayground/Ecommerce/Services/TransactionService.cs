using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;

namespace ECommerceApp.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepo;

    public TransactionService(ITransactionRepository transactionRepo)
    {
        _transactionRepo=transactionRepo;
    }

    public List<Transaction> GetAllTransaction()=>_transactionRepo.GetAllTransaction();
    
     public Transaction GetTransactionById(int id)
    {
        return _transactionRepo.GetTransactionById(id);
    }

    public bool InsertTransaction(Transaction transaction)
    {
        return _transactionRepo.InsertTransaction(transaction);
    }

    public bool UpdateTransaction(Transaction transaction)
    {
        return _transactionRepo.UpdateTransaction(transaction);
    }
      public bool DeleteTransaction(int id)
    {
        return _transactionRepo.DeleteTransaction(id);
    }
}