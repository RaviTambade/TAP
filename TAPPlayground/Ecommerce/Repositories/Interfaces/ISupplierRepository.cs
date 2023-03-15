using ECommerceApp.Models;
namespace ECommerceApp.Repositories.Interfaces;
public interface ISupplierRepository{
    List<Supplier> GetAllSuppliers();

    //Supplier GetSupplierById(int id);

    List<Supplier> GetSuppliersOfProduct(int productId);

    bool InsertSupplier(Supplier supplier);
    bool UpdateSupplier(Supplier supplier);

    bool DeleteSupplier(int id);
    
    
}