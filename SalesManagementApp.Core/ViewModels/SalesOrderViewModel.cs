using System;
using System.Collections.Generic;
using System.Text;

namespace SalesManagementApp.Core.ViewModels
{
    public class SalesOrderViewModel
    {
        public Guid rowguid { get; set; }
        public int SalesOrderID { get; set; }
        public int SalesOrderDetailID { get; set; }
        public string CarrierTrackingNumber { get; set; }
        public string OrderQty { get; set; }
        public int ProductID { get; set; }
        public int SpecialOfferID { get; set; }
        public string UnitPrice { get; set; }
        public string UnitPriceDiscount { get; set; }
        public string LineTotal { get; set; }
        public string ModifiedDate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
