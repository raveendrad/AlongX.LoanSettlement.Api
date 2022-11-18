using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillZen.Warehouse.Api
{
    public class FYModel
    {
        public long id { get; set; }
        public string display_name { get; set; }
        public int start_day { get; set; }
        public int start_month { get; set; }
        public int end_day { get; set; }
        public int end_month { get; set; }

    }
}