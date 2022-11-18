using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillZen.Warehouse.Api
{
    public class UserProfileModel
    {
        public string login_id { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string current_password { get; set; }
        public string new_password { get; set; }

    }
}