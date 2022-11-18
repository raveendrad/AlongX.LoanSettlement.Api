using BillZen.Warehouse.Api.DAL.Customer;
using BillZen.Warehouse.Api.DAL.GetLoanInformation;
using BillZen.Warehouse.Api.Models.Customer;
using BillZen.Warehouse.Api.Models.LoanInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BillZen.Warehouse.Api.Controllers
{
    public class GetLoanInformationController : ApiController
    {

        [HttpGet]
        public IList<LoanInformationModel> Get(long customer_id)
        {
            return new GetLoanInformation().GetAllLoanInformation(customer_id);
        }
    }
}
