using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BillZen.Warehouse.Api.Controllers
{
    public class NotififactionController : ApiController
    {
        [HttpGet]
        public IList<NotificationModel> Get()
        {
            return new Notifications().GetNotifications();
        }
    }
}
