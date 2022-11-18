using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillZen.Warehouse.Api
{
    public class RoleModel
    {
        public long id { get; set; }
        public string role_name { get; set; }
        public string role_description { get; set; }
    }
}