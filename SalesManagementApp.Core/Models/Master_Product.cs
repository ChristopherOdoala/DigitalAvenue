using SalesManagementApp.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesManagementApp.Core.Models
{
    public class Master_Product
    {
        public Master_Product()
        {
            Id = SequentialGuidGenerator.Instance.Create();
            CreatedOn = DateTime.Now;
        }
        [Key]
        public Guid Id { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
