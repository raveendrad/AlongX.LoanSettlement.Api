using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;

namespace BillZen.Warehouse.Api
{
    public class SubscriberProfile
    {
        public IList<SubscriberProfileModel> GetSubscriberProfile()
        {
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_getSubscriberProfile", new List<SqlStoreProcedureEntity>()
                {
                });

                return (IList<SubscriberProfileModel>)dataTable.AsEnumerable().Select<DataRow, SubscriberProfileModel>((Func<DataRow, SubscriberProfileModel>)(row => new SubscriberProfileModel()
                {
                    id = row.Field<long>("id"),
                    business_name = row.Field<string>("business_name"),
                    logo_url = row.Field<string>("logo_url"),
                    business_thumbnail = GenerateTumbnail(row.Field<string>("business_name")),
                    email = row.Field<string>("email"),
                    mobile = row.Field<string>("mobile"),
                    whatsapp = row.Field<string>("whatsapp"),
                    website = row.Field<string>("website"),
                    gst_number = row.Field<string>("gst_number"),
                    business_address = row.Field<string>("business_address"),
                    currency_name = row.Field<string>("currency_name"),
                    currency_symbol = row.Field<string>("currency_symbol"),
                    invoice_prefix = row.Field<string>("invoice_prefix"),
                    status = row.Field<bool>("status"),
                    service_provider_message = row.Field<string>("service_provider_message"),

                    fy = row.Field<long>("fy"),
                    fy_display_name = row.Field<string>("fy_display_name"),
                    start_day = row.Field<int>("start_day"),
                    start_month = row.Field<int>("start_month"),
                    end_day = row.Field<int>("end_day"),
                    end_month = row.Field<int>("end_month"),
                    default_filter_view_type = row.Field<string>("default_filter_view_type"),
                    default_filter_ranger = Math.Abs(row.Field<int>("default_filter_ranger")),


                })).ToList<SubscriberProfileModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DBResponse SaveSubscriberProfile(SubscriberProfileModel Request)
        {
            DBResponse response = new DBResponse();
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_updateSubscriberProfile", new List<SqlStoreProcedureEntity>()
                {
                  new SqlStoreProcedureEntity()
                  {
                    name = "id",
                    datatype = SqlDbType.BigInt,
                    value = Request.id.ToString()
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "business_name",
                    datatype = SqlDbType.NVarChar,
                    value = Request.business_name
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "logo_url",
                    datatype = SqlDbType.NVarChar,
                    value = Request.logo_url
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
                    name = "whatsapp",
                    datatype = SqlDbType.NVarChar,
                    value = Request.whatsapp
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "website",
                    datatype = SqlDbType.NVarChar,
                    value = Request.website
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "gst_number",
                    datatype = SqlDbType.NVarChar,
                    value = Request.gst_number
                  },
                   new SqlStoreProcedureEntity()
                  {
                    name = "business_address",
                    datatype = SqlDbType.NVarChar,
                    value = Request.business_address
                  },
                   new SqlStoreProcedureEntity()
                  {
                    name = "currency_name",
                    datatype = SqlDbType.NVarChar,
                    value = Request.currency_name.ToString()
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "currency_symbol",
                    datatype = SqlDbType.NVarChar,
                    value = Request.currency_symbol.ToString()
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "invoice_prefix",
                    datatype = SqlDbType.NVarChar,
                    value = Request.invoice_prefix.ToString()
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
        public DBResponse SaveFilterConfiguration(SubscriberProfileModel Request)
        {
            DBResponse response = new DBResponse();
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_updateFilterConfiguration", new List<SqlStoreProcedureEntity>()
                {
                  new SqlStoreProcedureEntity()
                  {
                    name = "id",
                    datatype = SqlDbType.BigInt,
                    value = Request.id.ToString()
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "fy",
                    datatype = SqlDbType.BigInt,
                    value = Request.fy.ToString()
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "default_filter_view_type",
                    datatype = SqlDbType.NVarChar,
                    value = Request.default_filter_view_type
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "default_filter_ranger",
                    datatype = SqlDbType.Int,
                    value = Request.default_filter_ranger.ToString()
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