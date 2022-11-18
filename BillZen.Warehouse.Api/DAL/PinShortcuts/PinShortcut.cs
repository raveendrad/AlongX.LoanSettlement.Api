using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace BillZen.Warehouse.Api
{
    public class PinShortcut
    {
        public IList<PinModel> GetPinnedShortcuts(string login_id)
        {
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_getPinnedShortcutsByLoginId", new List<SqlStoreProcedureEntity>()
                {
                  new SqlStoreProcedureEntity()
                  {
                    name = "login_id",
                    datatype = SqlDbType.NVarChar,
                    value = login_id
                  }
                });

                return (IList<PinModel>)dataTable.AsEnumerable().Select<DataRow, PinModel>((Func<DataRow, PinModel>)(row => new PinModel()
                {
                    id = row.Field<long>("id"),
                    login_id = row.Field<string>("login_id"),
                    shortcut_title = row.Field<string>("shortcut_title"),
                    shortcut_url = row.Field<string>("shortcut_url"),
                    shortcut_icon = row.Field<string>("shortcut_icon")

                })).ToList<PinModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DBResponse SavePinShortcut(PinModel Request)
        {
            DBResponse response = new DBResponse();
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_saveIntoPinnedShortcuts", new List<SqlStoreProcedureEntity>()
                {
                  new SqlStoreProcedureEntity()
                  {
                    name = "login_id",
                    datatype = SqlDbType.NVarChar,
                    value = Request.login_id
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "shortcut_title",
                    datatype = SqlDbType.NVarChar,
                    value = Request.shortcut_title
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "shortcut_url",
                    datatype = SqlDbType.NVarChar,
                    value = Request.shortcut_url
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "shortcut_icon",
                    datatype = SqlDbType.NVarChar,
                    value = Request.shortcut_icon
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
        public DBResponse DeletedPinnedShortcuts(long id)
        {
            DBResponse response = new DBResponse();
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_deletePinnedShortcut", new List<SqlStoreProcedureEntity>()
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