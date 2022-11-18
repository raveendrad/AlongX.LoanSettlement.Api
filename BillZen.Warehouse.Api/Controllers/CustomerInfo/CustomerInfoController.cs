using BillZen.Warehouse.Api.DAL.CustomerInfo;
using BillZen.Warehouse.Api.Models.CustomerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BillZen.Warehouse.Api.Controllers
{
    public class CustomerInfoController : ApiController
    {
        [HttpGet]
        public IList<CustomerInfoModel> Get(long customer_id)
        {
            return new CustomerInfo().GetAllCustomerInfo(customer_id);
        }

    }
}
