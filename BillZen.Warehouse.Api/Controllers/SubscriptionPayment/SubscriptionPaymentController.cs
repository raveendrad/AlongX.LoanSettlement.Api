using BillZen.Warehouse.Api.DAL.SubscriptionPayment;
using BillZen.Warehouse.Api.Models.Customer;
using BillZen.Warehouse.Api.Models.SubscriptionPayment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BillZen.Warehouse.Api.Controllers
{
    public class SubscriptionPaymentController : ApiController
    {
     
            [HttpGet]
            public IList<SubscriptionPaymentModel> Get(long customer_id,long loan_information_id)
            {
                return new SubscriptionPayment().GetSubscriptionPayment(customer_id,loan_information_id);
            }


            [HttpPost]
        public DBResponse Post([FromBody] SubscriptionPaymentModel _model)
        {
            DBResponse response = new DBResponse();
            try
            {
                SubscriptionPayment request = new SubscriptionPayment();

                response = request.SaveSubscriptionPayment(_model);
                return response;
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message.ToString();
                return response;
            }
        }
    }
}
