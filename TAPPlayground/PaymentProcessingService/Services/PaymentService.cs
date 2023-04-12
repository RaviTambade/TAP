using PaymentProcessingService.Models;
using PaymentProcessingService.Repositories.Interfaces;
using PaymentProcessingService.Services.Interfaces;
namespace PaymentProcessingService.Services;
public class PaymentService:IPaymentService{
    private readonly IPaymentRepository _repo;
    public PaymentService(IPaymentRepository repo){
        this._repo=repo;
    }

    public async Task<IEnumerable<Payment>> GetAllPayments() => await _repo.GetAllPayments();
    public async Task<Payment> GetPaymentById( int id) =>await _repo.GetPaymentById(id);
    public async Task<IEnumerable<Payment>> GetPaymentByOrderId( int id) =>await _repo.GetPaymentByOrderId(id);
    public async Task<bool> InsertPayments(Payment payment)=>await _repo.InsertPayments(payment);
    public async Task<bool>  UpdatePayment(Payment payment)=>await _repo.UpdatePayment(payment);
    public async Task<bool>  DeletePayment(int id)=>await _repo.DeletePayment(id);
    public async Task<IEnumerable<Payment>> GetPaymentByCustomer( int id) =>await _repo.GetPaymentByCustomer(id);
   
}