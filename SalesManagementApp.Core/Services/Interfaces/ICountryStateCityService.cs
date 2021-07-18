using SalesManagementApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesManagementApp.Core.Services.Interfaces
{
    public interface ICountryStateCityService
    {
        IEnumerable<Master_Country> GetAllCountries();
        IEnumerable<Master_City> GetAllCities();
        IEnumerable<Master_Region> GetAllRegions();
    }
}
