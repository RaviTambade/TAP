using ECommerceApp.Context;
using ECommerceApp.Contexts;
using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;

namespace ECommerceApp.Repositories;

public class TransactionORMRepository : ITransactionRepository
{
    private IConfiguration _configuration;

    public TransactionORMRepository(IConfiguration configuration)
    {
        _configuration=configuration;
    }

    public List<Transaction> GetAll()
    {
        using (var context = new TransactionContext(_configuration))
        {
            var transactions = context.Transaction.ToList();
            return transactions;
        }
    }
    public bool Delete(int transactionId)
    {
        throw new NotImplementedException();
    }

    public Transaction GetById(int transactionId)
    {
        throw new NotImplementedException();
    }

    public bool Insert(Transaction transaction)
    {
        throw new NotImplementedException();
    }

    public bool Update(Transaction transaction)
    {
        throw new NotImplementedException();
    }
}