using SalesManagementApp.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesManagementApp.Core.Models
{
    public class Master_Region
    {
        public Master_Region()
        {
            rowguid = SequentialGuidGenerator.Instance.Create();
            CreatedOn = DateTime.Now;
        }
        [Key]
        public Guid rowguid { get; set; }
        public string RegionCode { get; set; }
        public string CountryCode { get; set; }
        public string RegionName { get; set; }
        public Guid CountryId { get; set; }
        public Master_Country Country { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
