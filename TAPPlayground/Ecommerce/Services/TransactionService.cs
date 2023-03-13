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
}