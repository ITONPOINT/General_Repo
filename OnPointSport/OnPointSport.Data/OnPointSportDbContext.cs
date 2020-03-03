using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data.Entity;
using OnPointSport.Core.Domain;


namespace OnPointSport.Data
{
    public class OnPointSportDbContext : DbContext
    {
        public OnPointSportDbContext()
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ExchangeRate> ExchangeRates { get; set; }
        public virtual DbSet<ProductService> ProductServices { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<StockAdjustment> StockAdjustments { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; } 
        public virtual DbSet<Import> Imports { get; set; }  
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<ItemDetail> ItemDetails { get; set; }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
              .Where(x => x.Entity is AuditableEntity
                  && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                if (entry.Entity is AuditableEntity entity)
                {
                    string identityName = Thread.CurrentPrincipal?.Identity?.Name;
                    DateTime now = DateTime.Now;

                    if (entry.State == EntityState.Added)
                    {
                        entity.DateCreation = now;
                    }
                    else
                    {
                        Entry(entity).Property(x => x.DateCreation).IsModified = false;
                    }

                    entity.DateModification = now;
                }
            }

            return base.SaveChanges();
        }
    }
}
