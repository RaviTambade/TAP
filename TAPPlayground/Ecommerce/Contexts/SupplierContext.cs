using Microsoft.EntityFrameworkCore;
using ECommerceApp.Models;

namespace ECommerceApp.Contexts;
public class SupplierContext : DbContext
{
     private readonly IConfiguration _configuration;
     private readonly string _conString;

   
    public SupplierContext(IConfiguration configuration){
         _configuration=configuration;
         _conString= this._configuration.GetConnectionString("DefaultConnection");
    }   
    public DbSet<Supplier> Suppliers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
  
  
        optionsBuilder.UseMySQL(_conString);
    
        // string conString = "server=localhost;port=3306;user=root;password=password;database=ecommerce";
        // optionsBuilder.UseMySQL(conString);

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(s => s.SupplierId);
            entity.Property(s => s.CompanyName);
            entity.Property(s => s.SupplierName);
            entity.Property(s=> s.ContactNumber);
            entity.Property(s=> s.Email);
            entity.Property(s => s.Address);
            entity.Property(s => s.City);
            entity.Property(s => s.State);
            entity.Property(s => s.AccountNumber);
        });
        modelBuilder.Entity<Supplier>().ToTable("suppliers");
    }
}