using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BillZen.Warehouse.Api.Controllers
{
    public class ActivityLogController : ApiController
    {
        [HttpGet]
        public IList<ActivityLogModel> Get(string login_id = "0")
        {
            return new ActivityLog().GetSaveActivityLog(login_id);
        }
        [HttpPost]
        public DBResponse Post([FromBody] ActivityLogModel _model)
        {
            DBResponse response = new DBResponse();
            try
            {
                ActivityLog request = new ActivityLog();
                response = request.SaveActivityLog(_model);
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
