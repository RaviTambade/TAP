using ECommerceApp.Models;
namespace ECommerceApp.Repositories.Interfaces;
public interface IPaymentRepository
{
 List<Payment> GetAllPayments(int id);

 Payment GetPaymentById(int id);
 Payment GetPaymentByOrderId(int id);

 bool InsertPayments(Payment payment);
 bool UpdatePayment(Payment payment);
 bool DeletePayment(int id);
    List<Payment> GetAllPayments();
}