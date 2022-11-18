using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;

namespace BillZen.Warehouse.Api
{
    public class UserProfile
    {

        public DBResponse SaveUserProfile(UserProfileModel Request)
        {
            DBResponse response = new DBResponse();
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_saveMyProfile", new List<SqlStoreProcedureEntity>()
                {
                  new SqlStoreProcedureEntity()
                  {
                    name = "login_id",
                    datatype = SqlDbType.NVarChar,
                    value = Request.login_id.ToString()
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "full_name",
                    datatype = SqlDbType.NVarChar,
                    value = Request.full_name
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
                    name = "current_password",
                    datatype = SqlDbType.NVarChar,
                    value = new StringFormatter().encrypt(Request.current_password)
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "new_password",
                    datatype = SqlDbType.NVarChar,
                    value = new StringFormatter().encrypt(Request.new_password)
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

        public string GenerateTumbnail(string text)
        {
            string output = "";
            if(text.Length == 1)
            {
                output = text;
            }
            else
            {
                if (text.Contains(" "))
                {
                    string[] breakdown = text.Split(' ');
                    if (breakdown.Length > 1)
                    {
                        output = breakdown[0].Substring(0, 1) + breakdown[1].Substring(0, 1);
                    }
                    else
                    {
                        output = breakdown[0].Substring(0, 2);
                    }
                }
                else
                {
                    output = text.Substring(0, 2);
                }
            }
            
            return output.ToUpper();
        }
    }
}