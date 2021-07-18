using SalesManagementApp.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesManagementApp.Core.Models
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            Id = SequentialGuidGenerator.Instance.Create();
            CreatedOn = DateTime.Now;
        }
        [Key]
        public Guid Id { get; set; }
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public string ModifiedDate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
