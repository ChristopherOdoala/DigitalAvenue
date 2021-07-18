using Microsoft.Extensions.Logging;
using SalesManagementApp.Core.Models;
using SalesManagementApp.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesManagementApp.Core.Services
{
    public class CountryStateCityService : ICountryStateCityService
    {
        private DataContext _context;
        private readonly ILogger<CountryStateCityService> _logger;
        public CountryStateCityService(DataContext context, ILogger<CountryStateCityService> _logger)
        {
            _context = context;
            this._logger = _logger;
        }

        public IEnumerable<Master_Country> GetAllCountries()
        {
            return _context.Master_Countries;
        }

        public IEnumerable<Master_City> GetAllCities()
        {
            return _context.Master_Cities;
        }

        public IEnumerable<Master_Region> GetAllRegions()
        {
            return _context.Master_Region;
        }
    }
}
