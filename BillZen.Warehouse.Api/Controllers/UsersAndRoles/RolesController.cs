using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace BillZen.Warehouse.Api.Controllers
{
    public class RolesController : ApiController
    {
        [HttpGet]
        public IList<RoleModel> Get()
        {
            return new UsersAndRoles().GetRoles();
        }
    }
}