using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesManagementApp.Core.Helpers;
using SalesManagementApp.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementApp.Controller
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class LocationController : BaseController
    {
        private readonly ICountryStateCityService _countryStateCityService;
        public LocationController(ICountryStateCityService countryStateCityService)
        {
            _countryStateCityService = countryStateCityService;
        }

        [HttpGet]
        public IActionResult GetAllCountries()
        {
            var countries = _countryStateCityService.GetAllCountries();
            return Ok(countries);
        }

        [HttpGet]
        public IActionResult GetAllRegions()
        {
            var regions = _countryStateCityService.GetAllRegions();
            return Ok(regions);
        }

        [HttpGet]
        public IActionResult GetAllCities()
        {
            var cities = _countryStateCityService.GetAllCities();
            return Ok(cities);
        }
    }
}
