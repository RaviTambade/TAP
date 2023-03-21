using Microsoft.EntityFrameworkCore.Design;
using MySql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ECommerceApp.Repositories.Interfaces;
using  ECommerceApp.Models;

namespace ECommerceApp.Contexts;
public class AccountContext:DbContext{

public DbSet<Account>Accounts{ get; set; }

 private IConfiguration _configuration;
    private string _conString;

    public AccountContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _conString = this._configuration.GetConnectionString("DefaultConnection");
    }

     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(_conString);
    }
     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId);
            entity.Property(e => e.AccountNumber);
            entity.Property(e => e.IFSCCode);
            entity.Property(e => e.RegisterDate);
            entity.Property(e => e.Balance);
        });
       modelBuilder.Entity<Account>().ToTable("accounts");
    }

}