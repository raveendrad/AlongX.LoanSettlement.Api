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
    public class Terms
    {
     
        public IList<TermsModel> GetTerms()
        {
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_getTerms", new List<SqlStoreProcedureEntity>()
                {
                });

                return (IList<TermsModel>)dataTable.AsEnumerable().Select<DataRow, TermsModel>((Func<DataRow, TermsModel>)(row => new TermsModel()
                {
                    id = row.Field<long>("id"),
                    term_name = row.Field<string>("term_name"),
                    due_days = row.Field<int>("due_days"),

                })).ToList<TermsModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DBResponse SaveTerm(TermsModel Request)
        {
            DBResponse response = new DBResponse();
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_saveTerms", new List<SqlStoreProcedureEntity>()
                {
                  new SqlStoreProcedureEntity()
                  {
                    name = "term_name",
                    datatype = SqlDbType.NVarChar,
                    value = Request.term_name
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "due_days",
                    datatype = SqlDbType.Int,
                    value = Request.due_days.ToString()
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