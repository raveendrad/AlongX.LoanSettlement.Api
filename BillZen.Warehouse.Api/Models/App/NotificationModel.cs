using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillZen.Warehouse.Api
{
    public class NotificationModel
    {
        public long id { get; set; }
        public string date { get; set; }
        public string message { get; set; }
        public bool is_important { get; set; }
    }
}