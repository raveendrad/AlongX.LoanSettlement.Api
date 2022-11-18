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
    public class ActivityLog
    {
        public IList<ActivityLogModel> GetSaveActivityLog(string login_id="0")
        {
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_getActivityLog", new List<SqlStoreProcedureEntity>()
                {
                  new SqlStoreProcedureEntity()
                  {
                    name = "login_id",
                    datatype = SqlDbType.NVarChar,
                    value = login_id
                  }
                });

                return (IList<ActivityLogModel>)dataTable.AsEnumerable().Select<DataRow, ActivityLogModel>((Func<DataRow, ActivityLogModel>)(row => new ActivityLogModel()
                {
                    id = row.Field<long>("id"),
                    date = row.Field<DateTime>("date").ToString(),
                    action_performer_name = row.Field<string>("action_performer_name"),
                    action_performer_login_id = row.Field<string>("action_performer_login_id"),
                    action_title = row.Field<string>("action_title"),
                    action_content = row.Field<string>("action_content")

                })).ToList<ActivityLogModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DBResponse SaveActivityLog(ActivityLogModel Request)
        {
            DBResponse response = new DBResponse();
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_saveActivityLog", new List<SqlStoreProcedureEntity>()
                {
                  new SqlStoreProcedureEntity()
                  {
                    name = "action_performer_name",
                    datatype = SqlDbType.NVarChar,
                    value = Request.action_performer_name
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "action_performer_login_id",
                    datatype = SqlDbType.NVarChar,
                    value = Request.action_performer_login_id
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "action_title",
                    datatype = SqlDbType.NVarChar,
                    value = Request.action_title
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "action_content",
                    datatype = SqlDbType.NVarChar,
                    value = Request.action_content
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