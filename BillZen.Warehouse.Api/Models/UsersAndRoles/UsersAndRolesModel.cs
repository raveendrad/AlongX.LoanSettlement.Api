using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillZen.Warehouse.Api
{
    public class UsersAndRolesModel
    {
        public long id { get; set; }
        public string login_id { get; set; }
        public string password { get; set; }
        public long role_id { get; set; }
        public string role_name { get; set; }
        public string role_description { get; set; }
        public bool is_active { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string last_login { get; set; }
        public long outlet_id { get; set; }
        public long warehouse_id { get; set; }
        public string outlet_name { get; set; }
        public string warehouse_name { get; set; }

    }
}