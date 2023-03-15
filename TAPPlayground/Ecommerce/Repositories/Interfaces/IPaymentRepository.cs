using ECommerceApp.Models;
namespace ECommerceApp.Repositories.Interfaces;
public interface IPaymentRepository
{
 List<Payment> GetAllPayments();

 Payment GetPaymentById(int paymentId);
 Payment GetPaymentByOrderId(int OrderId);

 bool InsertPayments(Payment payment);
 bool UpdatePayment(Payment payment);
 bool DeletePayment(int paymentId);


}