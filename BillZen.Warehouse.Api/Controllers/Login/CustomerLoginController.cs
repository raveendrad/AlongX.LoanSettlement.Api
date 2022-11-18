using BillZen.Warehouse.Api.Models.Customer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BillZen.Warehouse.Api.Controllers.Login
{
    public class CustomerLoginController : ApiController
    {
         [HttpGet]
        public IList<DBResponse> Get(string mobile_number,string password)
        {
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_Customerlogin", new List<SqlStoreProcedureEntity>()
                {
                    new SqlStoreProcedureEntity()
                    {
                        name = "mobile_number",
                        datatype = SqlDbType.NVarChar,
                        value = mobile_number.ToString()
                    },
                    new SqlStoreProcedureEntity()
                    {
                        name = "password",
                        datatype = SqlDbType.NVarChar,
                        value = password.ToString()
                    }
                });
                return (IList<DBResponse>)dataTable.AsEnumerable().Select<DataRow, DBResponse>((Func<DataRow, DBResponse>)(row => new DBResponse()
                {
                    id = row.Field<long>("customer_id"),
                    message = row.Field<string>("name"),
                    status = Convert.ToBoolean( row.Field<int>("status")),

                })).ToList<DBResponse>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
