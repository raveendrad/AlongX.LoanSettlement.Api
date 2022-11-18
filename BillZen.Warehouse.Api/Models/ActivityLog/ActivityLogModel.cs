using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillZen.Warehouse.Api
{
    public class ActivityLogModel
    {
        public long id { get; set; }
        public string date { get; set; }
        public string action_performer_name { get; set; }
        public string action_performer_login_id { get; set; }
        public string action_title { get; set; }
        public string action_content { get; set; }
    }
}