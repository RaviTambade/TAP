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
    public async Task<IEnumerable<Supplier>> GetAll() =>await _repo.GetAll();
    public async Task<Supplier> GetById(int supplierId) =>await _repo.GetById(supplierId);
    public async Task<IEnumerable<Supplier>> GetSuppliers(int productId) =>await _repo.GetSuppliers(productId);
    public async Task<bool> Insert(Supplier supplier) =>await _repo.Insert(supplier);
    public async Task<bool> Update(Supplier supplier) =>await _repo.Update(supplier);
    public async Task<bool> Delete(int id) =>await _repo.Delete(id);
    public async Task<IEnumerable<ProductSupplier>> GetProductSupplier(int id) =>await _repo.GetProductSupplier(id);
}