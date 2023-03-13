using ECommerceApp.Models;
namespace ECommerceApp.Repositories.Interfaces;
public interface ISupplierRepository{
    List<Supplier> GetAllSuppliers();

    Supplier GetSupplierById(int id);
}