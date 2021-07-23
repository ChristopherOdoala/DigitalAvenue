using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesManagementApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SalesManagementApp.Core.Models.Maps
{
    class MasterCityMap : IEntityTypeConfiguration<Master_City>
    {
        public void Configure(EntityTypeBuilder<Master_City> builder)
        {
            //SetupData(builder);
        }

        private void SetupData(EntityTypeBuilder<Master_City> builder)
        {
            var resourceName = "SalesManagementApp.Core.Data.CityDbScript.csv";
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.MissingFieldFound = null;
                    csvReader.Configuration.HeaderValidated = null;
                    csvReader.Configuration.BadDataFound = null;
                    var cityDbScript = csvReader.GetRecords<CityDbScriptVM>();

                    foreach (var data in cityDbScript)
                    {
                        var entity = new Master_City
                        {
                            CityCode = int.Parse(data.CityCode),
                            CityName = data.CityName,
                            CreatedOn = DateTime.Now,
                            RegionCode = data.RegionCode,
                            RegionId = Guid.Parse(data.RegionId)
                        };

                        builder.HasData(entity);
                    }
                }
            }
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
            SetupData(builder);
        }

        private void SetupData(EntityTypeBuilder<Product> builder)
        {
            var resourceName = "SalesManagementApp.Core.Data.Products.csv";
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.MissingFieldFound = null;
                    csvReader.Configuration.HeaderValidated = null;
                    csvReader.Configuration.HasHeaderRecord = true;
                    csvReader.Configuration.BadDataFound = null;
                    var products = csvReader.GetRecords<ProductViewModel>();

                    Decimal listPrice = 0;
                    Decimal standardCost = 0;
                    Decimal weight = 0;
                    Int16 reorderPoint = 0;
                    Int16 safetyStockLevel = 0;

                    DateTime modDate;
                    DateTime disDate;
                    DateTime sellEndDate;
                    DateTime sellStartDate;

                    foreach (var data in products)
                    {
                        var reOrder = short.TryParse(data.ReorderPoint, out reorderPoint);
                        var safetyStock = short.TryParse(data.SafetyStockLevel, out safetyStockLevel);
                        var entity = new Product
                        {
                            Class = data.Class,
                            Color = data.Color,
                            DaysToManufacture = data.DaysToManufacture.HasValue ? 0 : data.DaysToManufacture.Value,
                            DiscontinuedDate = DateTime.TryParse(data.DiscontinuedDate, out disDate) ? new DateTime() : disDate,
                            FinishedGoodsFlag = data.FinishedGoodsFlag,
                            ListPrice = Decimal.TryParse(data.ListPrice, out listPrice) ? 0 : listPrice,
                            MakeFlag = data.MakeFlag,
                            ModifiedDate = DateTime.TryParse(data.ModifiedDate, out modDate) ? new DateTime() : modDate,
                            Name = data.Name,
                            ProductID = data.ProductID.HasValue ? 0 : data.ProductID.Value,
                            ProductLine = data.ProductLine,
                            ProductModelID = data.ProductModelID.HasValue ? 0 : data.ProductModelID.Value,
                            ProductNumber = data.ProductNumber,
                            ProductSubcategoryID = data.ProductSubcategoryID.HasValue ? 0 : data.ProductSubcategoryID.Value,
                            SellEndDate = DateTime.TryParse(data.SellEndDate, out sellEndDate) ? new DateTime() : sellEndDate,
                            SellStartDate = DateTime.TryParse(data.SellStartDate, out sellStartDate) ? new DateTime() : sellStartDate,
                            Size = data.Size,
                            SizeUnitMeasureCode = data.SizeUnitMeasureCode,
                            StandardCost = Decimal.TryParse(data.StandardCost, out standardCost) ? 0 : standardCost,
                            Style = data.Style,
                            Weight = Decimal.TryParse(data.Weight, out weight) ? 0 : weight,
                            WeightUnitMeasureCode = data.WeightUnitMeasureCode,
                            CreatedOn = DateTime.Now
                        };

                        if (reOrder)
                            entity.ReorderPoint = reorderPoint;
                        if (safetyStock)
                            entity.SafetyStockLevel = safetyStockLevel;


                        builder.HasData(entity);
                    }
                }
            }
        }
    }

    class SalesOrderMap : IEntityTypeConfiguration<SalesOrder>
    {
        public void Configure(EntityTypeBuilder<SalesOrder> builder)
        {
            SetUpData(builder);
        }

        private void SetUpData(EntityTypeBuilder<SalesOrder> builder)
        {
            Debugger.Launch();
            var resourceName = "SalesManagementApp.Core.Data.SalesOrder.csv";
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.MissingFieldFound = null;
                    csvReader.Configuration.HeaderValidated = null;
                    csvReader.Configuration.HasHeaderRecord = true;
                    csvReader.Configuration.BadDataFound = null;
                    var saleOrder = csvReader.GetRecords<SalesOrderViewModel>();

                    DateTime modDate;
                    Int16 orderQty;
                    decimal unitPrice = 0;
                    decimal unitPriceDiscount = 0;
                    decimal lineTotal = 0;


                    foreach (var data in saleOrder)
                    {
                        var orderQ = short.TryParse(data.OrderQty, out orderQty);
                        var entity = new SalesOrder
                        {
                            CarrierTrackingNumber = data.CarrierTrackingNumber,
                            ProductID = data.ProductID,
                            rowguid = data.rowguid,
                            SalesOrderDetailID = data.SalesOrderDetailID,
                            SalesOrderID = data.SalesOrderID,
                            SpecialOfferID = data.SpecialOfferID,
                            UnitPrice = Decimal.TryParse(data.UnitPrice, out unitPrice) ? 0 : unitPrice,
                            UnitPriceDiscount = Decimal.TryParse(data.UnitPriceDiscount, out unitPriceDiscount) ? 0 : unitPriceDiscount,
                            LineTotal = Decimal.TryParse(data.LineTotal, out lineTotal) ? 0 : lineTotal,
                            ModifiedDate = DateTime.TryParse(data.ModifiedDate, out modDate) ? new DateTime() : modDate,
                            CreatedOn = DateTime.Now,
                        };

                        if (orderQ)
                            entity.OrderQty = orderQty;

                        builder.HasData(entity);
                    }
                }
            }
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
