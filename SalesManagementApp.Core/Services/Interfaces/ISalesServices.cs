using SalesManagementApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesManagementApp.Core.Services.Interfaces
{
    public interface ISalesServices
    {
        ResultModel<string> CreateSalesRecord(SalesVM model);
        IEnumerable<SalesRecordViewModel> GetAllSalesRecord(string country, string state, string city, DateTime? dateOfSale, out int totalcount, int? pageIndex = 1, int? pageSize = 10);
    }
}
