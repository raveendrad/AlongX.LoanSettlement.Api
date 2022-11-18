using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BillZen.Warehouse.Api.Controllers
{
    public class TermsController : ApiController
    {
        [HttpGet]
        public IList<TermsModel> Get()
        {
            return new Terms().GetTerms();
        }

        [HttpPost]
        public DBResponse Post([FromBody] TermsModel _model)
        {
            DBResponse response = new DBResponse();
            try
            {
                Terms request = new Terms();
                response = request.SaveTerm(_model);
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
