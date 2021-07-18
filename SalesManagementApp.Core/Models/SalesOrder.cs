using SalesManagementApp.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesManagementApp.Core.Models
{
    public class SalesOrder
    {
        public SalesOrder()
        {
            rowguid = SequentialGuidGenerator.Instance.Create();
            CreatedOn = DateTime.Now;
        }

        [Key]
        public Guid rowguid { get; set; }
        public int SalesOrderID { get; set; }
        public int SalesOrderDetailID { get; set; }
        public string CarrierTrackingNumber { get; set; }
        public Int16 OrderQty { get; set; }
        public int ProductID { get; set; }
        public int SpecialOfferID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }
        public decimal LineTotal { get; set; } 
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
