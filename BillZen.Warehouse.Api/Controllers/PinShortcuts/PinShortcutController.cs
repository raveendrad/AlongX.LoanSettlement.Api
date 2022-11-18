using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BillZen.Warehouse.Api.Controllers
{
    public class PinShortcutController : ApiController
    {
        [HttpGet]
        public IList<PinModel> Get(string login_id)
        {
            return new PinShortcut().GetPinnedShortcuts(login_id);
        }
        [HttpPost]
        public DBResponse Post([FromBody] PinModel _model)
        {
            DBResponse response = new DBResponse();
            try
            {
                PinShortcut request = new PinShortcut();
                response = request.SavePinShortcut(_model);
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
        public DBResponse Delete(long id)
        {
            DBResponse response = new DBResponse();
            try
            {
                PinShortcut request = new PinShortcut();
                response = request.DeletedPinnedShortcuts(id);
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
