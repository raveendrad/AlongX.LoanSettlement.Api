using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;



namespace BillZen.Warehouse.Api.Controllers
{
    public class UsersAndRolesController : ApiController
    {
        [HttpGet]
        public IList<UsersAndRolesModel> Get()
        {
            return new UsersAndRoles().GetUsersAndRoles();
        }



        [HttpPost]
        public DBResponse PostAsync([FromBody] UsersAndRolesModel _model)
        {
            DBResponse response = new DBResponse();
            try
            {
                UsersAndRoles request = new UsersAndRoles();
                response =  request.SaveUsersAndRolesAsync(_model);
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
        public DBResponse PatchAsync(long id)
        {
            DBResponse response = new DBResponse();
            try
            {
                UsersAndRoles request = new UsersAndRoles();
                response =  request.ResetPasswordAsync(id);
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
                UsersAndRoles request = new UsersAndRoles();
                response = request.DeleteUser(id);
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