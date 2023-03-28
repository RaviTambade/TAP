using ECommerceApp.Models;
using ECommerceApp.Repositories;
using ECommerceApp.Repositories.Interfaces;
using ECommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Services;
public class SupplierService : ISupplierService
{
   private readonly ISupplierRepository _repo;
   public SupplierService(ISupplierRepository repo){
    _repo=repo;
   }

    public List<Supplier> GetAll()=> _repo.GetAll();

    public Supplier GetById(int supplierId)
    {
        return _repo.GetById(supplierId);
    }

    public List<Supplier> GetSuppliers(int productId)
    {
        return _repo.GetSuppliers(productId);
    }

    public bool Insert(Supplier supplier)
    {
        return _repo.Insert(supplier);
    }

    public bool Update(Supplier supplier)
    {
        return _repo.Update(supplier);
    }
      public bool Delete(int id)
    {
        return _repo.Delete(id);
    }

    public List<ProductSupplier> GetProductSupplier(int id){
        return _repo.GetProductSupplier(id);
    }
}