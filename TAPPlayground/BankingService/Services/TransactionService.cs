using BankingService.Models;
using BankingService.Repositories.Interfaces;
using BankingService.Services.Interfaces;

namespace BankingService.Services;

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