using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillZen.Warehouse.Api
{
    public class PinModel
    {
        public long id { get; set; }
        public string login_id { get; set; }
        public string shortcut_title { get; set; }
        public string shortcut_url { get; set; }
        public string shortcut_icon { get; set; }
    }
}