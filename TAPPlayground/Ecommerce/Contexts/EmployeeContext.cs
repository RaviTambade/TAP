using Microsoft.EntityFrameworkCore.Design;
using MySql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ECommerceApp.Repositories.Interfaces;
using  ECommerceApp.Models;

namespace ECommerceApp.Contexts{
   
    public class EmployeeContext : DbContext
    {   
        public DbSet<Employee> employees {get;set;}
        
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string conString= "server=localhost;port=3306;user=root;password=password;database=ecommerce";
            builder.UseMySQL(conString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity=>{
                entity.HasKey(e=>e.EmpId);
                entity.Property(e=>e.EmpFirstName).IsRequired();
                entity.Property(e=>e.EmpLastName).IsRequired();
                entity.Property(e=>e.BirthDate).IsRequired();
                entity.Property(e=>e.HireDate).IsRequired();
                entity.Property(e=>e.ContactNumber).IsRequired();
                entity.Property(e=>e.Email).IsRequired();
                entity.Property(e=>e.Password).IsRequired();
                entity.Property(e=>e.Photo).IsRequired();
                entity.Property(e=>e.ReportsTo).IsRequired(); 
                entity.Property(e=>e.AccountNumber).IsRequired();
            });
        }
    }
}