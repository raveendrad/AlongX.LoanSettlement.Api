using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillZen.Warehouse.Api
{
    public class TermsModel
    {
        public long id { get; set; }
        public string term_name { get; set; }
        public int due_days { get; set; }
    }
}