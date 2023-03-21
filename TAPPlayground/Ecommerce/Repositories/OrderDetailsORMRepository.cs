
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
        try
        {
            using (var context = new OrderDetailsContext(_configuration))
            {
                var orderDetails = context.OrderDetails.ToList();
                return orderDetails;
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public bool DeleteByOrderDetailsId(int orderDetailsId)
    {
        bool status = false;
        try
        {
            using (var context = new OrderDetailsContext(_configuration))
            {
                var found = context.OrderDetails.Find(orderDetailsId);
                if (found != null)
                {
                    context.OrderDetails.Remove(found);
                    context.SaveChanges();
                    status = true;
                }
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return status;
    }


    public OrderDetails GetById(int orderDetailsId)
    {
       OrderDetails orderDetail= new OrderDetails();
        try
        {
            using (var context = new OrderDetailsContext(_configuration))
            {
                 orderDetail = context.OrderDetails.Find(orderDetailsId);  
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return orderDetail;
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
        bool status = false;
        try
        {
            using (var context = new OrderDetailsContext(_configuration))
            {
                context.OrderDetails.Add(orderDetails);
                context.SaveChanges();
                status = true;
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return status;
    }

    public bool Update(OrderDetails orderDetails)
    {
        bool status = false;
        try
        {
            using (var context = new OrderDetailsContext(_configuration))
            {
                var oldOrderDetails = context.OrderDetails.Find(orderDetails.OrderDetailsId);
                if (oldOrderDetails != null)
                {
                    oldOrderDetails.OrderId=orderDetails.OrderId;
                    oldOrderDetails.ProductId=orderDetails.ProductId;
                    oldOrderDetails.Quantity=orderDetails.Quantity;
                    oldOrderDetails.SupplierId=orderDetails.SupplierId;
                    oldOrderDetails.Discount=orderDetails.Discount;
                    context.SaveChanges();
                    status = true;
                }

            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return status;
    }
}
