using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesManagementApp.Core.ViewModels
{
    public class SalesVM : IValidatableObject
    {
        public string CustomerName { get; set; }
        public Guid CityId { get; set; }
        public DateTime DateOfSale { get; set; }
        public Guid ProductId { get; set; }
        public double Quantity { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(string.IsNullOrEmpty(CustomerName))
                yield return new   ValidationResult("Customer Name cannot be null");
        }
    }
}
