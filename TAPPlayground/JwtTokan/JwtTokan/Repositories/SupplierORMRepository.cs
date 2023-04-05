
// using ECommerceApp.Context;
// using ECommerceApp.Contexts;
// using ECommerceApp.Models;
// using ECommerceApp.Repositories.Interfaces;

// namespace ECommerceApp.Repositories;

// public class SupplierORMRepository : ISupplierRepository
// {
//     private IConfiguration _configuration;

//     public SupplierORMRepository(IConfiguration configuration)
//     {
//         _configuration = configuration;
//     }

   
//     public List<Supplier> GetAll()
//     {
//         using (var context = new SupplierContext(_configuration))
//         {
//             var suppliers = context.Suppliers.ToList();
//             return suppliers;
//         }
//     }

//     public Supplier GetById(int supplierId)
//     {
//         throw new NotImplementedException();
//     }

//     public List<Supplier> GetSuppliers(int productId)
//     {
//         throw new NotImplementedException();
//     }

//     public bool Insert(Supplier supplier)
//     {
//         throw new NotImplementedException();
//     }

//     public bool Update(Supplier supplier)
//     {
//         throw new NotImplementedException();
//     }

//     public bool Delete(int supplierId)
//     {
//         throw new NotImplementedException();
//     }

// }
