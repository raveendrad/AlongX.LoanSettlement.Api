using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BillZen.Warehouse.Api.Controllers
{
    public class SubscriberProfileController : ApiController
    {
        [HttpGet]
        public IList<SubscriberProfileModel> Get()
        {
            return new SubscriberProfile().GetSubscriberProfile();
        }

        [HttpPut]
        public DBResponse Put([FromBody] SubscriberProfileModel _model)
        {
            DBResponse response = new DBResponse();
            try
            {
                SubscriberProfile request = new SubscriberProfile();
                response = request.SaveSubscriberProfile(_model);
                return response;
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message.ToString();
                return response;
            }
        }
        [HttpPatch]
        public DBResponse Patch([FromBody] SubscriberProfileModel _model)
        {
            DBResponse response = new DBResponse();
            try
            {
                _model.default_filter_ranger = (_model.default_filter_ranger * (-1));
                SubscriberProfile request = new SubscriberProfile();
                response = request.SaveFilterConfiguration(_model);
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
