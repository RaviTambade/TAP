using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;

namespace ECommerceApp.Services.Interfaces;
public interface IPaymentService : IPaymentRepository
{
    List<Payment> GetAllPayments();
}