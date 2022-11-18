using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;



namespace BillZen.Warehouse.Api
{
    public class UsersAndRoles
    {
        public IList<UsersAndRolesModel> GetUsersAndRoles(long id = 0)
        {
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_getUsersAndRoles", new List<SqlStoreProcedureEntity>()
{
new SqlStoreProcedureEntity()
{
name = "id",
datatype = SqlDbType.BigInt,
value = id.ToString()
}
});



                return (IList<UsersAndRolesModel>)dataTable.AsEnumerable().Select<DataRow, UsersAndRolesModel>((Func<DataRow, UsersAndRolesModel>)(row => new UsersAndRolesModel()
                {
                    id = row.Field<long>("id"),
                    login_id = row.Field<string>("login_id"),
                    password = row.Field<string>("password"),
                    role_id = row.Field<long>("role_id"),
                    role_name = row.Field<string>("role_name"),
                    role_description = row.Field<string>("role_description"),
                    is_active = row.Field<bool>("is_active"),
                    full_name = row.Field<string>("full_name"),
                    email = row.Field<string>("email"),
                    mobile = row.Field<string>("mobile"),
                    last_login = row.Field<string>("last_login") != null ? row.Field<string>("last_login") : "",
                    outlet_name = row.Field<string>("outlet_name"),
                    warehouse_name = row.Field<string>("warehouse_name"),


                })).ToList<UsersAndRolesModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<RoleModel> GetRoles()
        {
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_getRoles", new List<SqlStoreProcedureEntity>()
                {
                });



                return (IList<RoleModel>)dataTable.AsEnumerable().Select<DataRow, RoleModel>((Func<DataRow, RoleModel>)(row => new RoleModel()
                {
                    id = row.Field<long>("id"),
                    role_name = row.Field<string>("role_name"),
                    role_description = row.Field<string>("role_description")
                })).ToList<RoleModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DBResponse SaveUsersAndRolesAsync(UsersAndRolesModel Request)
        {
            DBResponse response = new DBResponse();
            try
            {
                string randomPassword = GetRandomPassword(10);
                DataTable dataTable = new SqlQuery().Execute("usp_saveUsersAndRoles", new List<SqlStoreProcedureEntity>()
{
new SqlStoreProcedureEntity()
{
name = "id",
datatype = SqlDbType.BigInt,
value = Request.id.ToString()
},
new SqlStoreProcedureEntity()
{
name = "full_name",
datatype = SqlDbType.NVarChar,
value = Request.full_name
},
new SqlStoreProcedureEntity()
{
name = "login_id",
datatype = SqlDbType.NVarChar,
value = Request.login_id
},
new SqlStoreProcedureEntity()
{
name = "password",
datatype = SqlDbType.NVarChar,
value = new StringFormatter().encrypt(randomPassword)
},
new SqlStoreProcedureEntity()
{
name = "role_id",
datatype = SqlDbType.BigInt,
value = Request.role_id.ToString()
},
new SqlStoreProcedureEntity()
{
name = "email",
datatype = SqlDbType.NVarChar,
value = Request.email
},
new SqlStoreProcedureEntity()
{
name = "mobile",
datatype = SqlDbType.NVarChar,
value = Request.mobile
},
new SqlStoreProcedureEntity()
{
name = "is_active",
datatype = SqlDbType.Bit,
value = Request.is_active.ToString()
},
new SqlStoreProcedureEntity()
{
name = "outlet_id",
datatype = SqlDbType.BigInt,
value = Request.outlet_id.ToString()
},
new SqlStoreProcedureEntity()
{
name = "warehouse_id",
datatype = SqlDbType.BigInt,
value = Request.warehouse_id.ToString()
}

});
                response.status = Convert.ToBoolean(dataTable.Rows[0][0]);
                response.message = dataTable.Rows[0][1].ToString();



                if (response.status && Request.id == 0)
                {
                    string htmlBody = "<h4>Hi " + Request.full_name + ",</h4>";
                    htmlBody += "<p>You have been given access to the " + ConfigurationManager.AppSettings["smtp_display_name"] + " application. Please find below your credential to login. </p>";
                    htmlBody += "<span>Login ID - <b>" + Request.login_id + "</b></span><br>";
                    htmlBody += "<span>Password - <b>" + randomPassword + "</b></span><br>";
                     new MessageSender().SendMail(ConfigurationManager.AppSettings["smtp_display_name"], Request.email, "Credential to Access Confirm Admin Portal.", htmlBody, "", "");
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message.ToString();
            }
            return response;
        }
        public string GetRandomPassword(int length)
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";



            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();



            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }



            return sb.ToString();
        }
        public DBResponse ResetPasswordAsync(long id)
        {
            DBResponse response = new DBResponse();
            try
            {
                string randomPassword = GetRandomPassword(10);
                DataTable dataTable = new SqlQuery().Execute("usp_resetUserPassword", new List<SqlStoreProcedureEntity>()
{
new SqlStoreProcedureEntity()
{
name = "id",
datatype = SqlDbType.BigInt,
value = id.ToString()
},
new SqlStoreProcedureEntity()
{
name = "password",
datatype = SqlDbType.NVarChar,
value = new StringFormatter().encrypt(randomPassword)
}
});
                response.status = Convert.ToBoolean(dataTable.Rows[0][0]);
                response.message = dataTable.Rows[0][1].ToString();



                if (response.status)
                {
                    UsersAndRolesModel Request = GetUsersAndRoles(id).FirstOrDefault();
                    string htmlBody = "<h4>Hi " + Request.full_name + ",</h4>";
                    htmlBody += "<p>Your password has been reset by your admin. Please find below your new password. </p>";
                    htmlBody += "<span>Login ID - <b>" + Request.login_id + "</b></span><br>";
                    htmlBody += "<span>Password - <b>" + randomPassword + "</b></span><br>";
                     new MessageSender().SendMail(ConfigurationManager.AppSettings["smtp_display_name"], Request.email, "Password has been reset.", htmlBody, "", "");
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message.ToString();
            }
            return response;
        }
        public DBResponse DeleteUser(long id)
        {
            DBResponse response = new DBResponse();
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_deleteUser", new List<SqlStoreProcedureEntity>()
{
new SqlStoreProcedureEntity()
{
name = "id",
datatype = SqlDbType.BigInt,
value = id.ToString()
}
});
                response.status = Convert.ToBoolean(dataTable.Rows[0][0]);
                response.message = dataTable.Rows[0][1].ToString();
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message.ToString();
            }
            return response;
        }
    }
}