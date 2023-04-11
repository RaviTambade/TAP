using PaymentProcessingService.Models;
namespace PaymentProcessingService.Repositories.Interfaces;
public interface IPaymentRepository
{
     List<Payment> GetAllPayments();
    Payment GetPaymentById(int id);
    List<Payment> GetPaymentByOrderId(int id);
    bool InsertPayments(Payment payment);
    bool UpdatePayment(Payment payment);
    bool DeletePayment(int id);
   
    
     List<Payment> GetPaymentByCustomer(int id);

}