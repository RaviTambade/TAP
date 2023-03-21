
using ECommerceApp.Context;
using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;

namespace ECommerceApp.Repositories;

public class OrderDetailsORMRepository : IOrderDetailsRepository
{
    private IConfiguration _configuration;

    public OrderDetailsORMRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public List<OrderDetails> GetAll()
    {
        Console.WriteLine("orm called");
        using (var context = new OrderDetailsContext(_configuration))
        {
            var orderDetails = context.OrderDetails.ToList();
            return orderDetails;
        }
    }

     public bool DeleteByOrderDetailsId(int orderDetailsId)
    {
        throw new NotImplementedException();
    }


    public OrderDetails GetById(int orderDetailsId)
    {
        throw new NotImplementedException();
    }

    public List<OrderDetailsOrder> GetOrderDetailsByOrder(int orderId)
    {
        throw new NotImplementedException();
    }

    public List<OrderHistory> GetOrderHistory(int customerId)
    {
        throw new NotImplementedException();
    }

    public bool Insert(OrderDetails orderDetails)
    {
        throw new NotImplementedException();
    }

    public bool Update(OrderDetails orderDetails)
    {
        throw new NotImplementedException();
    }
}
