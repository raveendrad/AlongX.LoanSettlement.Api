using BillZen.Warehouse.Api.DAL.Customer;
using BillZen.Warehouse.Api.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace BillZen.Warehouse.Api.Controllers
{
    public class CustomerController : ApiController
    {
        [HttpGet]
        public IList<CustomerModel> Get(long customer_id)
        {
            return new Customer().GetAllCustomers(customer_id);
        }

        [HttpPost]
        public DBResponse Post([FromBody] CustomerModel _model)
        {
            DBResponse response = new DBResponse();
            try
            {
                Customer request = new Customer();
                response = request.SaveCustomer(_model);
                return response;
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message.ToString();
                return response;
            }
        }
        [HttpDelete]
        public DBResponse Delete(long customer_id)
        {
            DBResponse response = new DBResponse();
            try
            {
                Customer request = new Customer();
                response = request.DeleteCustomer(customer_id);
                return response;
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message.ToString();
                return response;
            }
        }
        [HttpPut]
        public DBResponse Put([FromBody] CustomerModel _model)
        {
            DBResponse response = new DBResponse();
            {
                Customer request = new Customer();
                response = request.UpdateCustomerInfo(_model);
            }

            return response;


        }
    }
}
