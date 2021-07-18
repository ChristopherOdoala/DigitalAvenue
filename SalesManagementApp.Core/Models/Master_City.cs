using SalesManagementApp.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesManagementApp.Core.Models
{
    public class Master_City
    {
        public Master_City()
        {
            Id = SequentialGuidGenerator.Instance.Create();
            CreatedOn = DateTime.Now;
        }
        [Key]
        public Guid Id { get; set; }
        public int CityCode { get; set; }
        public string CityName { get; set; }
        public string RegionCode { get; set; }
        public Guid RegionId { get; set; }
        public Master_Region Region { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
