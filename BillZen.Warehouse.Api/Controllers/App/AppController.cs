using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BillZen.Warehouse.Api.Controllers
{
    public class AppController : ApiController
    {
        //[HttpGet]
        //public IList<MandatoryActionsModel> Get()
        //{
        //    return new App().GetMandaroryActions();
        //}

        [HttpPost]
        public AuthorizedInfoModel Post([FromBody] CredentialsModel _model)
        {
            return new App().Authenticate(_model);
        }

    }
}
