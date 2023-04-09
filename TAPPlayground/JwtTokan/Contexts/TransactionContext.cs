using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ECommerceApp.Models;

namespace ECommerceApp.Contexts;

public class TransactionContext : DbContext
{
    public DbSet<Transaction> Transaction {get; set;}

    private IConfiguration _configuration;
    private string _conString;

    public TransactionContext(IConfiguration configuration)
    {
        _configuration=configuration;
        _conString=this._configuration.GetConnectionString("DefaultConnection");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(_conString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId);
            entity.Property(e => e.FromAccountNumber);
            entity.Property(e => e.ToAccountNumber);
            entity.Property(e => e.TransactionDate);
            entity.Property(e => e.Amount);
        });
        modelBuilder.Entity<Transaction>().ToTable("transactions");
    }
}
