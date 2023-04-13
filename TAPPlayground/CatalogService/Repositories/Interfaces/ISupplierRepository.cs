using System.Collections.Generic;
using CatalogService.Models;
namespace CatalogService.Repositories.Interfaces;
public interface ISupplierRepository
{
     Task<IEnumerable<Supplier>> GetAll();
     Task<Supplier> GetById(int supplierId);
     Task<IEnumerable<Supplier>> GetSuppliers(int productId);
     Task<bool> Insert(Supplier supplier);
     Task<bool>  Update(Supplier supplier);
     Task<bool>  Delete(int supplierId);
    Task<IEnumerable<ProductSupplier>> GetProductSupplier(int supplierId);
}