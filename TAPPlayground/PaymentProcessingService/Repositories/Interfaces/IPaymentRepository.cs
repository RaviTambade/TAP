using PaymentProcessingService.Models;
namespace PaymentProcessingService.Repositories.Interfaces;
public interface IPaymentRepository
{
   Task<IEnumerable<Payment>> GetAllPayments();
    Task<Payment> GetPaymentById(int id);
   Task<IEnumerable<Payment>> GetPaymentByOrderId(int id);
     Task<bool> InsertPayments(Payment payment);
    Task<bool> UpdatePayment(Payment payment);
    Task<bool>  DeletePayment(int id);
   
    
   Task<IEnumerable<Payment>> GetPaymentByCustomer(int id);

}