using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QST.ECommerce.Domain.Customer;
using Microsoft.EntityFrameworkCore;
using QST.ECommerce.Domain.Catalogue;

namespace QST.ECommerce.Infrastructure.DbContexts;

// A Class which is used to connect Application with the underlying Database using DBSet objects
// For configurations, there is another config class available for each Entity/Table
public class CatalogDbContext : DbContext
{
    public CatalogDbContext(DbContextOptions options) : base(options)
    {
        // Catalog, Ordering, Inventory, Payment, Notification, Shipment
    }

    public CatalogDbContext()
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Customer> Customers => Set<Customer>();
    //public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);

    }

}
