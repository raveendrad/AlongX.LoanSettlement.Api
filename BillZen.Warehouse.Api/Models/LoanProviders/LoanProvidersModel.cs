using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillZen.Warehouse.Api.Models.LoanProviders
{
    public class LoanProvidersModel
    {

        public long loan_provider_id { get; set; }
        public string loan_provider_name { get; set; }
        public string loan_platform { get; set; }
        public string mobile_number { get; set; }
        public decimal additional_discount_to_settlement { get; set; }
        public string special_comments { get; set; }
    }
}