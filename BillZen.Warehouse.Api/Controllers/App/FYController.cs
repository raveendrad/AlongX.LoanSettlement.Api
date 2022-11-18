using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BillZen.Warehouse.Api.Controllers
{
    public class FYController : ApiController
    {
        [HttpGet]
        public IList<FYModel> Get()
        {
            return new App().GetFY();
        }
    }
}
