using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillZen.Warehouse.Api
{
    public class SubscriberProfileModel
    {
        public long id { get; set; }
        public string business_name { get; set; }
        public string logo_url { get; set; }
        public string business_thumbnail { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string whatsapp { get; set; }
        public string website { get; set; }
        public string gst_number { get; set; }
        public string business_address { get; set; }
        public string currency_name { get; set; }
        public string currency_symbol { get; set; }
        public string invoice_prefix { get; set; }
        public bool status { get; set; }
        public string service_provider_message { get; set; }

        public long fy { get; set; }
        public string fy_display_name { get; set; }
        public int start_day { get; set; }
        public int start_month { get; set; }
        public int end_day { get; set; }
        public int end_month { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string default_filter_view_type { get; set; }
        public int default_filter_ranger { get; set; }
    }
}