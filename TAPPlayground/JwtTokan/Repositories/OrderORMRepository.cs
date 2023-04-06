using ECommerceApp.Contexts;
using ECommerceApp.Models;
using ECommerceApp.Repositories.Interfaces;

namespace ECommerceApp.Repositories;

public class OrderORMRepository : IOrderORMRepository
{
    private IConfiguration _configuration;

    public OrderORMRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public List<Order> GetAll()
    {
        Console.WriteLine("orm called");
        using (var context = new OrderContext(_configuration))
        {
            var orders = from order in context.orders select order;
            return orders.ToList<Order>();
        }
    }
}