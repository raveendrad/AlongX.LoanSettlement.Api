using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillZen.Warehouse.Api.Models.CustomerInfo
{
    public class CustomerInfoModel
    {
        public long customer_id { get; set; }
        public string loan_provider_name { get; set; }
        public string loan_account_number { get; set; }
        public string loan_type { get; set; }
        public decimal total_loan_emi_pending_with_fine { get; set; }
        public decimal suggested_settlement_amount { get; set; }
        public bool payment_status { get; set; }
        public bool resolve_status { get; set; }
    }
}
