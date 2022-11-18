using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BillZen.Warehouse.Api.Controllers
{
    public class UserProfileController : ApiController
    {
        
        [HttpPut]
        public DBResponse Put([FromBody] UserProfileModel _model)
        {
            DBResponse response = new DBResponse();
            try
            {
                UserProfile request = new UserProfile();
                response = request.SaveUserProfile(_model);
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
