using ECommerceApp.Models;
using ECommerceApp.Repositories;
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
   public List<Supplier> GetAllSuppliers()=> _repo.GetAllSuppliers();

    public Supplier GetSupplierById(int id)
    {
        return _repo.GetSupplierById(id);
    }

    public List<Supplier> GetSuppliersOfProduct(int productId)
    {
        return _repo.GetSuppliersOfProduct(productId);
    }
}