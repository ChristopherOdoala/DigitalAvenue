using Microsoft.EntityFrameworkCore;
using SalesManagementApp.Core.Models;
using SalesManagementApp.Core.Models.Maps;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesManagementApp.Core
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MasterCityMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new Master_CountryMap());
            modelBuilder.ApplyConfiguration(new Master_ProductMap());
            modelBuilder.ApplyConfiguration(new Master_RegionMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new SalesOrderMap());
            modelBuilder.ApplyConfiguration(new ProductCategoryMap());
            modelBuilder.ApplyConfiguration(new SaleMap());
            modelBuilder.ApplyConfiguration(new DBErrorsMap());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Master_City> Master_Cities { get; set; }
        public DbSet<Master_Country> Master_Countries { get; set; }
        public DbSet<Master_Product> Master_Products { get; set; }
        public DbSet<Master_Region> Master_Region { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Sale> Sales { get; set; }

    }
}
