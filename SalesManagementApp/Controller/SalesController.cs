using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesManagementApp.Core.Enums;
using SalesManagementApp.Core.Helpers;
using SalesManagementApp.Core.Services.Interfaces;
using SalesManagementApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementApp.Controller
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SalesController : BaseController
    {
        private readonly ISalesServices _salesService;

        public SalesController(ISalesServices salesService)
        {
            _salesService = salesService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public IActionResult CreateSalesRecord([FromBody] SalesVM model)
        {
            var res = _salesService.CreateSalesRecord(model);
            if (res.ErrorMessages.Any())
                return ApiResponse(res.Data, errors: res.ErrorMessages.ToArray(), codes: ApiResponseCodes.ERROR);

            return ApiResponse(res.Data, string.Empty, codes: ApiResponseCodes.OK);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllSalesRecord(string country, string state, string city, DateTime? dateOfSale, int? pageIndex = 1, int? pageSize = 10)
        {

            var salesRecord = _salesService.GetAllSalesRecord(country, state, city, dateOfSale, out int total, pageIndex, pageSize);

            return ApiResponse(salesRecord.ToList(), string.Empty, totalCount: total);
        }
    }
}
