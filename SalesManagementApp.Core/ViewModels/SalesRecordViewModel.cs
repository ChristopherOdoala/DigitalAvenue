using System;
using System.Collections.Generic;
using System.Text;

namespace SalesManagementApp.Core.ViewModels
{
    public class SalesRecordViewModel
    {
        public string CustomerName { get; set; }
        public string CountryName { get; set; }
        public string RegionName { get; set; }
        public string CityName { get; set; }
        public string ProductName { get; set; }
        public DateTime DateOfSale { get; set; }
        public double Quantity { get; set; }
        public int TotalCount { get; set; }
    }
}
