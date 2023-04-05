using Microsoft.EntityFrameworkCore.Design;
using MySql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ECommerceApp.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using  ECommerceApp.Models;

namespace ECommerceApp.Contexts{
    public class OrderContext : DbContext
    {   
        public DbSet<Order> orders {get;set;}

        private IConfiguration _configuration;

        public string _conString;

        public OrderContext(IConfiguration configuration)
        {
            _configuration=configuration;
            _conString =this._configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string conString= "server=localhost;port=3306;user=root;password=Password;database=Ecommerce";
            builder.UseMySQL(conString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity=>{
                entity.HasKey(e=>e.OrderId);
                entity.Property(e=>e.OrderDate).IsRequired();
                entity.Property(e=>e.ShippedDate).IsRequired();
                entity.Property(e=>e.CustomerId).IsRequired();
                entity.Property(e=>e.Total).IsRequired();
                entity.Property(e=>e.Status).IsRequired();
            });
        }
    }
}