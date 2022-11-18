using BillZen.Warehouse.Api.DAL.LoanProviders;
using BillZen.Warehouse.Api.Models.LoanProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace BillZen.Warehouse.Api.Controllers
{
    public class LoanProvidersController : ApiController
    {
        [HttpGet]
        public IList<LoanProvidersModel> Get(long loan_provider_id = 0)
        {
            return new LoanProviders().GetAllLoanProviders(loan_provider_id);
        }

        [HttpPost]
        public DBResponse Post([FromBody] LoanProvidersModel _model)
        {
            DBResponse response = new DBResponse();
            try
            {
                LoanProviders request = new LoanProviders();
                response = request.SaveLoanProviders(_model);
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
        public DBResponse Delete(long loan_provider_id)
        {
            DBResponse response = new DBResponse();
            try
            {
                LoanProviders request = new LoanProviders();
                response = request.DeleteLoanProviders(loan_provider_id);
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
