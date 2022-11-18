using BillZen.Warehouse.Api.DAL.LoanInfo;
using BillZen.Warehouse.Api.Models.LoanInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BillZen.Warehouse.Api.Controllers
{
    public class LoanInfoController : ApiController
    {
        [HttpGet]
        public IList<LoanInfoModel> Get(long customer_id = 0)
        {
            return new LoanInfo().GetAllLoanInfo(customer_id);
        }

        [HttpPost]
        public DBResponse Post([FromBody] LoanInfoModel _model)
        {
            DBResponse response = new DBResponse();
            try
            {
                LoanInfo request = new LoanInfo();
                response = request.SaveLoanInfo(_model);
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
        public DBResponse Delete(long loan_info_id)
        {
            DBResponse response = new DBResponse();
            try
            {
                LoanInfo request = new LoanInfo();
                response = request.DeleteLoanInfo(loan_info_id);
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
