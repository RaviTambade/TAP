using PaymentProcessingService.Models;
using PaymentProcessingService.Repositories.Interfaces;
using PaymentProcessingService.Services.Interfaces;
namespace PaymentProcessingService.Services;
public class PaymentService:IPaymentService{
    private readonly IPaymentRepository _repo;
    public PaymentService(IPaymentRepository repo){
        this._repo=repo;
    }

    public List<Payment> GetAllPayments() => _repo.GetAllPayments();
    public Payment GetPaymentById( int id) =>_repo.GetPaymentById(id);
    public List<Payment> GetPaymentByOrderId( int id) =>_repo.GetPaymentByOrderId(id);
    public bool InsertPayments(Payment payment)=>_repo.InsertPayments(payment);
    public bool UpdatePayment(Payment payment)=>_repo.UpdatePayment(payment);
    public bool DeletePayment(int id)=>_repo.DeletePayment(id);
    public List<Payment> GetPaymentByCustomer( int id) =>_repo.GetPaymentByCustomer(id);
   
}