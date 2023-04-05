using ECommerceApp.Helpers;
using ECommerceApp.Models;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ECommerceApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionsrv;
        public TransactionController(ITransactionService transactionsrv)
        {
            _transactionsrv = transactionsrv;
        }

        [HttpGet]
        [Route("/api/transactions/GetAllTransactions")]
        public IEnumerable<Transaction> GetAllTransactions()
        {
            List<Transaction> transactions = _transactionsrv.GetAll();
            return transactions;
        }

        [HttpGet]
        [Route("/api/transactions/GetTransactionDetails/{id}")]
        public Transaction GetById(int id)
        {
            Transaction transaction = _transactionsrv.GetById(id);
            return transaction;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut]
        [Route("/api/transactions/update/{id}")]
        public bool Update( int id,[FromBody] Transaction transaction)
        {
            Transaction oldTransaction = _transactionsrv.GetById(id);
            if(oldTransaction.TransactionId==0){
                return false;
            }
            transaction.TransactionId=id;
            bool status = _transactionsrv.Update(transaction);
            return status;
        }

        [Authorize(Roles = Role.Admin+","+Role.Customer)]
        [HttpPost]
        [Route("/api/products/Addproduct/")]
        public bool Insert([FromBody] Transaction transaction)
        {
            bool status = _transactionsrv.Insert(transaction);
            return status;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete]
        [Route("/api/products/delete/{id}")]
        public bool Delete(int id)
        {
            bool status = _transactionsrv.Delete(id);
            return status;
        }
    }
}







