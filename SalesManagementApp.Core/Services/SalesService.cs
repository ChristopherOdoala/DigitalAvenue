using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SalesManagementApp.Core.Dapper.Interfaces;
using SalesManagementApp.Core.Dapper.Services;
using SalesManagementApp.Core.Models;
using SalesManagementApp.Core.Services.Interfaces;
using SalesManagementApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesManagementApp.Core.Services
{
    public class SalesService : Service<Sale>, ISalesServices
    {
        private readonly DataContext _context;
        private readonly ILogger<SalesService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public SalesService(DataContext context, ILogger<SalesService> _logger, IUnitOfWork unitOfWork): base(unitOfWork)
        {
            _context = context;
            this._logger = _logger;
            _unitOfWork = unitOfWork;
        }

        public ResultModel<string> CreateSalesRecord(SalesVM model)
        {
            var resultModel = new ResultModel<string>();

            if(model is null)
            {
                resultModel.AddError("Model for sales creation cannot be null");
                return resultModel;
            }

            if(model.CityId == Guid.Empty)
            {
                resultModel.AddError("City Id cannot be null");
                return resultModel;
            }

            if (model.ProductId == Guid.Empty)
            {
                resultModel.AddError("Product Id cannot be null");
                return resultModel;
            }

            var product = _context.Products.Find(model.ProductId);

            if(product is null)
            {
                resultModel.AddError($"Product with Id {model.ProductId} does not exist");
                return resultModel;
            }

            var city = _context.Master_Cities.Include(x => x.Region).ThenInclude(x => x.Country).Where(x => x.Id == model.CityId).FirstOrDefault();

            if(city is null)
            {
                resultModel.AddError($"City with Id {model.CityId} does not exist");
                return resultModel;
            }

            var saleRecord = new Sale
            {
                CityId = model.CityId,
                CountryId = city.Region.CountryId,
                RegionId = city.RegionId,
                CustomerName = model.CustomerName,
                DateOfSale = model.DateOfSale,
                ProductId = model.ProductId,
                Quantity = model.Quantity
            };

            try
            {
                _context.Sales.Add(saleRecord);
                _context.SaveChanges();

                resultModel.Data = "Created Successfully";
                return resultModel;
            }
            catch(Exception ex)
            {
                resultModel.AddError($"{ex.Message}");
                return resultModel;
            }
        }

        public IEnumerable<SalesRecordViewModel> GetAllSalesRecord(string country, string state, string city, DateTime? dateOfSale, out int totalcount, int? pageIndex = 1, int? pageSize = 10)
        {
            pageIndex = (!pageIndex.HasValue || pageIndex < 1) ? 1 : pageIndex.Value;
            pageSize = (!pageSize.HasValue || pageSize < 1) ? 10 : pageSize.Value;

            var parameters = new DynamicParameters();

            parameters.Add("@Country", country, DbType.String);
            parameters.Add("@State", state, DbType.String);
            parameters.Add("@City", city, DbType.String);
            parameters.Add("@DateOfSale", city, DbType.DateTime);
            parameters.Add("@PageIndex", pageIndex, DbType.Int32);
            parameters.Add("@PageSize", pageSize, DbType.Int32);

            List<SalesRecordViewModel> salesRecord = new List<SalesRecordViewModel> { };

            try
            {
                salesRecord = ExecuteStoredProcedure<SalesRecordViewModel>("[Sp_GetAllSalesRecord]", parameters).Result.ToList();
                totalcount = salesRecord.FirstOrDefault()?.TotalCount ?? 0;
                return salesRecord;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message + "Inner Exception:" + ex.InnerException.Message);
                totalcount = 0;
                return salesRecord;
            }
            
        }
    }
}
