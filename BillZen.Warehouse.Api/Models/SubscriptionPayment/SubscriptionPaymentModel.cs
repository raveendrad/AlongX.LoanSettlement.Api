using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillZen.Warehouse.Api.Models.SubscriptionPayment
{
    public class SubscriptionPaymentModel
    {
        public long payment_id { get; set; }
        public long customer_id { get; set; }
        public long loan_information_id { get; set; }
        public string payment_date { get; set; }
        public decimal amount { get; set; }
        public string payment_mode { get; set; }
        public string payment_references { get; set; }

    }
}