using System.Collections;
using System.Threading.Tasks;
using OrderProcessingService.Models;
using OrderProcessingService.Repositories.Interfaces;
using OrderProcessingService.Services.Interfaces;

namespace OrderProcessingService.Services;
public class OrderDetailsService : IOrderDetailsService
{
    private readonly IOrderDetailsRepository _repo;
    public OrderDetailsService(IOrderDetailsRepository repo)
    {
        this._repo = repo;
    }

    public async Task<bool> DeleteByOrderDetailsId(int orderDetailsId)
    {
        return await _repo.DeleteByOrderDetailsId(orderDetailsId);
    }

    public async Task<IEnumerable<OrderDetails>> GetAll()
    {
        var orderdetails = _repo.GetAll();
        Console.WriteLine("service");
        return await orderdetails;
    }

    public async Task<OrderDetails> GetById(int orderDetailsId)
    {
        return await _repo.GetById(orderDetailsId);
    }

    public async Task<IEnumerable<OrderDetailsOrder>> GetOrderDetailsByOrder(int orderId)
    {
        var orderDetails = _repo.GetOrderDetailsByOrder(orderId);
        return await orderDetails;
    }

    public async Task<IEnumerable<OrderHistory>> GetOrderHistory(int customerId)
    {
        return await _repo.GetOrderHistory(customerId);
    }

    public async Task<bool> Insert(OrderDetails orderDetails)
    {
        return await _repo.Insert(orderDetails);
    }

    public async Task<bool> Update(OrderDetails orderDetails)
    {
      return await _repo.Update(orderDetails);
    }
}