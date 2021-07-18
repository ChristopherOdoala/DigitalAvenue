using SalesManagementApp.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesManagementApp.Core.Models
{
    public class Sale
    {
        public Sale()
        {
            Id = SequentialGuidGenerator.Instance.Create();
            CreatedOn = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public Guid CountryId { get; set; }
        public Guid RegionId { get; set; }
        public Guid CityId { get; set; }
        public Master_City City { get; set; }
        public DateTime DateOfSale { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public double Quantity { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
