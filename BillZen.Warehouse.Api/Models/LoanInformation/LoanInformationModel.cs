using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillZen.Warehouse.Api.Models.LoanInformation
{
    public class LoanInformationModel
    {

        public long loan_information_id { get; set; }
        public long customer_id { get; set; }
        public long loan_provider_id { get; set; }
        public string lender_type { get; set; }
        public string loan_service_provider { get; set; }
        public string regulated_entity { get; set; }
        public string loan_type { get; set; }
        public string loan_tenure { get; set; }
        public string toatl_emis { get; set; }
        public string loan_delay { get; set; }
        public decimal principal_amount { get; set; }
        public decimal processing_fee { get; set; }
        public decimal Insurance_amount { get; set; }
        public decimal other_charges { get; set; }
        public decimal total_outstanding_amount { get; set; }
        public string loan_document { get; set; }
        public string settlement_reason { get; set; }
        public string payment_status { get; set; }
        public string resolve_status { get; set; }
        public string interest { get; set; }
        public string loan_account_number { get; set; }


    }
}