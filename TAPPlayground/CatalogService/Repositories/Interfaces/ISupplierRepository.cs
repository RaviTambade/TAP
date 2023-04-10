using System.Collections.Generic;
using CatalogService.Models;
namespace CatalogService.Repositories.Interfaces;
public interface ISupplierRepository
{
    List<Supplier> GetAll();
    Supplier GetById(int supplierId);
    List<Supplier> GetSuppliers(int productId);
    bool Insert(Supplier supplier);
    bool Update(Supplier supplier);
    bool Delete(int supplierId);
    List<ProductSupplier> GetProductSupplier(int supplierId);
}