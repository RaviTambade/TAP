using System.Collections;
using System.Threading.Tasks;
using OrderProcessingService.Models;
using OrderProcessingService.Repositories.Interfaces;
using OrderProcessingService.Services.Interfaces;

namespace OrderProcessingService.Services;
public class OrderService : IOrderService{
    private readonly IOrderRepository _repo;
    public OrderService(IOrderRepository repo){
        this._repo=repo;
    }

    public async Task<IEnumerable<Order>> GetAll(){
        var orders= _repo.GetAll();
        return await orders;
    } 

    public async Task<IEnumerable<Order>> GetAllCancelled(){
       var orders= _repo.GetAllCancelled();
       return await orders;

    }
    public async Task<IEnumerable<Order>> GetAllDelivered(){
        var orders= _repo.GetAllDelivered();
        return await orders;
    }

    public async Task<Order> GetById(int id) => await _repo.GetById(id);

    public async Task<Order> GetOrderByCustId(int id) => await _repo.GetOrderByCustId(id);
    public async Task<int> GetOrderId(int id) => await _repo.GetOrderId(id);

    public async Task<bool> InsertOrder(int id)=> await _repo.InsertOrder(id);

    public async Task<bool> Insert(Order order)=> await _repo.Insert(order);

    public async Task<bool> Update(Order order)=> await _repo.Update(order);

    public async Task<bool> Delete(int id)=> await _repo.Delete(id);
}