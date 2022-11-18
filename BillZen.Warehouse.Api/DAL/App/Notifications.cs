using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace BillZen.Warehouse.Api
{
    public class Notifications
    {
        public IList<NotificationModel> GetNotifications()
        {
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_getNoticifactions", new List<SqlStoreProcedureEntity>()
                {
                });

                return (IList<NotificationModel>)dataTable.AsEnumerable().Select<DataRow, NotificationModel>((Func<DataRow, NotificationModel>)(row => new NotificationModel()
                {
                    id = row.Field<long>("id"),
                    date = row.Field<DateTime>("date").ToLongDateString(),
                    message = row.Field<string>("message"),
                    is_important = row.Field<bool>("is_important")

                })).ToList<NotificationModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}