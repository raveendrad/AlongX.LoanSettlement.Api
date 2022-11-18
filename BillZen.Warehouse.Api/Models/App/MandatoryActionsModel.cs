using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillZen.Warehouse.Api
{
    public class MandatoryActionsModel
    {
        public string action_name { get; set; }
        public bool is_required { get; set; }
        public string action_link { get; set; }
    }
}