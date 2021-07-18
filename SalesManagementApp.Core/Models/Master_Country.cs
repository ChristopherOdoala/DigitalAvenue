using SalesManagementApp.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesManagementApp.Core.Models
{
    public class Master_Country
    {
        public Master_Country()
        {
            rowguid = SequentialGuidGenerator.Instance.Create();
            CreatedOn = DateTime.Now;
        }
        [Key]
        public Guid rowguid { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
