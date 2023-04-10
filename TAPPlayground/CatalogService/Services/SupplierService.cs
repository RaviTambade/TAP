using CatalogService.Models;
using CatalogService.Repositories;
using CatalogService.Repositories.Interfaces;
using CatalogService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Services;
public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _repo;
    public SupplierService(ISupplierRepository repo)
    {
        _repo = repo;
    }
    public List<Supplier> GetAll() => _repo.GetAll();
    public Supplier GetById(int supplierId) => _repo.GetById(supplierId);
    public List<Supplier> GetSuppliers(int productId) => _repo.GetSuppliers(productId);
    public bool Insert(Supplier supplier) => _repo.Insert(supplier);
    public bool Update(Supplier supplier) => _repo.Update(supplier);
    public bool Delete(int id) => _repo.Delete(id);
    public List<ProductSupplier> GetProductSupplier(int id) => _repo.GetProductSupplier(id);
}