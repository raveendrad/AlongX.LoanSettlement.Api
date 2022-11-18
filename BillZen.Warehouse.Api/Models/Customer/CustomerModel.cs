using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillZen.Warehouse.Api.Models.Customer
{
    public class CustomerModel
    {
        public long customer_id { get; set; }
        public string name { get; set; }=null;
        public string email { get; set; }=null ;
        public string mobile_number { get; set; } = null;   
        public string alternate_mobile_number { get; set; } = null; 
        public string full_address { get; set; } = null;    
        public string city { get; set; } = null;    
        public string state { get; set; } = null;   
        public string pincode { get; set; } = null;
        public string occupation { get; set; } = null;
        public decimal? your_earning_per_month { get; set; } 
        public string gender { get; set; } = null;
        public string date_of_birth { get; set; } = null;
        public string date_of_registration { get; set; } = null;
        public string password { get; set; } = null;
        public string pan_card { get; set; } = null;
        public string adhaar_card { get; set; } = null;
    }
}