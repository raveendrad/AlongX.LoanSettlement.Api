using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillZen.Warehouse.Api
{
    public class AuthorizedInfoModel
    {
        public long id { get; set; }
        public long user_id { get; set; }
        public string business_name { get; set; }
        public string logo_url { get; set; }
        public string business_email { get; set; }
        public string business_mobile { get; set; }
        public string business_whatsapp { get; set; }
        public string business_website { get; set; }
        public string gst_number { get; set; }
        public string business_address { get; set; }
        public string currency_name { get; set; }
        public string currency_symbol { get; set; }
        public string invoice_prefix { get; set; }
        public bool app_status { get; set; }
        public string service_provider_message { get; set; }
        public long role_id { get; set; }
        public string role_name { get; set; }
        public string role_description { get; set; }
        public long outlet_id { get; set; }
        public long warehouse_id { get; set; }
        public string outlet_name { get; set; }
        public string warehouse_name { get; set; }
        public bool is_active { get; set; }
        public string full_name { get; set; }
        public string thumbnail_name { get; set; }
        public string user_email { get; set; }
        public string user_mobile { get; set; }
        public string last_login { get; set; }
        public bool status { get; set; }
        public string message { get; set; }

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