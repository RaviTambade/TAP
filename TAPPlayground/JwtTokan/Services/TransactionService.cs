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

    public List<Transaction> GetAllTransactions()=>_transactionRepo.GetAllTransactions();
    
     public Transaction GetById(int transactionId)
    {
        return _transactionRepo.GetById(transactionId);
    }

    public bool Insert(Transaction transaction)
    {
        return _transactionRepo.Insert(transaction);
    }

    public bool Update(Transaction transaction)
    {
        return _transactionRepo.Update(transaction);
    }
      public bool Delete(int transactionId)
    {
        return _transactionRepo.Delete(transactionId);
    }
}