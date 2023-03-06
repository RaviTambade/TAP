using ECommerceApp.Models;
namespace ECommerceApp.Repositories.Interfaces;
public interface IOrderDetailsRepository
{
    bool InsertOrderdetails(orderdetails orderdetails);
}