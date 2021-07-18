using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesManagementApp.Core.Models.Maps
{
    class MasterCityMap : IEntityTypeConfiguration<Master_City>
    {
        public void Configure(EntityTypeBuilder<Master_City> builder)
        {

        }
    }

    class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

        }
    }

    class Master_CountryMap : IEntityTypeConfiguration<Master_Country>
    {
        public void Configure(EntityTypeBuilder<Master_Country> builder)
        {

        }
    }

    class Master_ProductMap : IEntityTypeConfiguration<Master_Product>
    {
        public void Configure(EntityTypeBuilder<Master_Product> builder)
        {

        }
    }

    class Master_RegionMap : IEntityTypeConfiguration<Master_Region>
    {
        public void Configure(EntityTypeBuilder<Master_Region> builder)
        {

        }
    }

    class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

        }
    }

    class SalesOrderMap : IEntityTypeConfiguration<SalesOrder>
    {
        public void Configure(EntityTypeBuilder<SalesOrder> builder)
        {

        }
    }

    class ProductCategoryMap : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {

        }
    }

    class SaleMap : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {

        }
    }

    class DBErrorsMap : IEntityTypeConfiguration<DBErrors>
    {
        public void Configure(EntityTypeBuilder<DBErrors> builder)
        {

        }
    }
}
