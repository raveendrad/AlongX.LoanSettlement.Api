using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillZen.Warehouse.Api.Models.LoanInfo
{
    public class LoanInfoModel
    {
        public long loan_info_id { get; set; }
        public long customer_id { get; set; }
        public long loan_provider_id { get; set; }
        public string loan_provider_name { get; set; }  
        public string loan_type { get; set; }

        public string sanction_date { get; set; }
        public decimal total_loan_sanctioned_amount { get; set; }
        public decimal total_loan_recieved_amount { get; set; }
        public decimal total_amount_per_emi { get; set; }
        public decimal total_loan_emi_commited { get; set; }
        public decimal total_loan_emi_paid { get; set; }
        public decimal total_loan_emi_pending_without_fine { get; set; }
        public decimal total_loan_emi_pending_with_fine { get; set; }
        public decimal last_emi_paid { get; set; }
        public string difaulter_since { get; set; }
        public string additional_info { get; set; }
        public string loan_document { get; set; }
        public string loan_account_number { get; set; }
        public string defaulter_reason { get; set; }
        public decimal suggested_settlement_amount { get; set; }
        public decimal actual_settlement_amount { get; set; }
        public string payment_status { get; set; }
        public string resolve_status { get; set; }


    }
}