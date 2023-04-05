using Microsoft.EntityFrameworkCore;
using ECommerceApp.Models;

namespace ECommerceApp.Context;

public class OrderDetailsContext : DbContext
{

    public DbSet<OrderDetails> OrderDetails { get; set; }
    private IConfiguration _configuration;
    private string _conString;

    public OrderDetailsContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
         
        // string conString = "server=localhost; database=Ecommerce; user=root; password=password";
        optionsBuilder.UseMySQL(_conString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<OrderDetails>(entity =>
        {
            entity.HasKey(e => e.OrderDetailsId);
            entity.Property(e => e.OrderId);
            entity.Property(e => e.ProductId);
            entity.Property(e => e.Quantity);
            entity.Property(e => e.SupplierId);
            entity.Property(e => e.Discount);
        });
       modelBuilder.Entity<OrderDetails>().ToTable("orderdetails");
    }
}