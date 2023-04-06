using Microsoft.EntityFrameworkCore;
using ECommerceApp.Models;

namespace ECommerceApp.Contexts;
public class ShipperContext : DbContext
{
     private readonly IConfiguration _configuration;
     private readonly string _conString;

   
    public ShipperContext(IConfiguration configuration){
         _configuration=configuration;
         _conString= this._configuration.GetConnectionString("DefaultConnection");
    }   
    public DbSet<Shipper> shippers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
  
  
        optionsBuilder.UseMySQL(_conString);
    
        // string conString = "server=localhost;port=3306;user=root;password=password;database=ecommerce";
        // optionsBuilder.UseMySQL(conString);

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Shipper>(entity =>
        {
            entity.HasKey(s => s.ShipperId);
            entity.Property(s => s.CompanyName);
            entity.Property(s=> s.ContactNumber);
            entity.Property(s=> s.Email);
            entity.Property(s => s.AccountNumber);
        });
        modelBuilder.Entity<Shipper>().ToTable("shippers");
    }
}