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

    public List<Transaction> GetAllTransactions()
    {
        try{
            using (var context = new TransactionContext(_configuration))
            {
            var transactions = context.Transaction.ToList();
            return transactions;
            }
        }
        catch(Exception e)
        {
            throw e;
        }

    }
    public bool Delete(int transactionId)
    {
        bool status = false;
        try
        {
            using (var context = new TransactionContext(_configuration))
            {
                var found = context.Transaction.Find(transactionId);
                if (found != null)
                {
                    context.Transaction.Remove(found);
                    context.SaveChanges();
                    status = true;
                }
            }
        }   
        catch(Exception e)
         {
            throw e;
         }
        return status;
    }

    public Transaction GetById(int transactionId)
    {
        Transaction transaction = new Transaction();
        try
        {
            using (var context = new TransactionContext(_configuration))
            {
                transaction = context.Transaction.Find(transactionId);  
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return transaction;
    }

    public bool Insert(Transaction transaction)
    {
       bool status = false;
       try
       {
         using(var context = new TransactionContext(_configuration))
         {
            context.Transaction.Add(transaction);
            context.SaveChanges();
            status = true;
         }
       }
       catch(Exception e)
       {
        throw e;
       }
       return status;
    }

    public bool Update(Transaction transaction)
    {
         bool status = false;
        try
        {
            using (var context = new TransactionContext(_configuration))
            {
                var oldTransaction = context.Transaction.Find(transaction.TransactionId);
                if (oldTransaction != null)
                {
                    oldTransaction.TransactionId=transaction.TransactionId;
                    oldTransaction.FromAccountNumber=transaction.FromAccountNumber;
                    oldTransaction.ToAccountNumber=transaction.ToAccountNumber;
                    oldTransaction.TransactionDate=transaction.TransactionDate;
                    oldTransaction.Amount=transaction.Amount;
                    context.SaveChanges();
                    status = true;
                }
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return status;
    }
}



   
