
using BankingService.Models;
using BankingService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace BankingService.Controllers
{

   [ApiController]
    [Route("/api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionsrv;
        private readonly ILogger<TransactionController> _logger;
        public TransactionController(ILogger<TransactionController> logger, ITransactionService transactionsrv)
        {
            _logger=logger;
            _transactionsrv = transactionsrv;
        }

        [HttpGet]
        [Route("gettransactions")]
        public IEnumerable<Transaction> GetAllTransactions()
        {
            List<Transaction> transactions = _transactionsrv.GetAllTransactions();
            _logger.LogInformation("Get All method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());

            return transactions;
        }

        [HttpGet]
        [Route("gettransactiondetails/{id}")]
        public Transaction GetById(int id)
        {
            Transaction transaction = _transactionsrv.GetById(id);
            _logger.LogInformation("Get By Id method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());

            return transaction;
        }

       // [Authorize(Roles = Role.Admin)]
        [HttpPut]
        [Route("update/{id}")]
        public bool Update( int id,[FromBody] Transaction transaction)
        {
            Transaction oldTransaction = _transactionsrv.GetById(id);
            _logger.LogInformation("Update method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            if(oldTransaction.TransactionId==0){
                return false;
            }
            transaction.TransactionId=id;
            bool status = _transactionsrv.Update(transaction);
            return status;
        }

        //[Authorize(Roles = Role.Admin+","+Role.Customer)]
        [HttpPost]
        [Route("addtransaction")]
        public bool Insert([FromBody] Transaction transaction)
        {
            bool status = _transactionsrv.Insert(transaction);
      _logger.LogInformation("Insert method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());

            return status;
        }

       // [Authorize(Roles = Role.Admin)]
        [HttpDelete]
        [Route("delete/{id}")]
        public bool Delete(int id)
        {
            bool status = _transactionsrv.Delete(id);
            _logger.LogInformation("Delete method invoked at  {DT}",  DateTime.UtcNow.ToLongTimeString());
            return status;
        }
    }
}