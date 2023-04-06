using Microsoft.EntityFrameworkCore.Design;
using MySql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ECommerceApp.Repositories.Interfaces;
using  ECommerceApp.Models;

namespace ECommerceApp.Contexts{
    public class CustomerContext : DbContext
    {   
        public DbSet<Customer> customers {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string conString= "server=localhost;port=3306;user=root;password=1234512345;database=ecommerce";
            builder.UseMySQL(conString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity=>{
                entity.HasKey(e=>e.CustomerId);
                entity.Property(e=>e.FirstName).IsRequired();
                entity.Property(e=>e.LastName).IsRequired();
                entity.Property(e=>e.Email).IsRequired();
                entity.Property(e=>e.ContactNumber).IsRequired();
                entity.Property(e=>e.Password).IsRequired();
                entity.Property(e=>e.AccountNumber).IsRequired();
            });
        }
    }
}