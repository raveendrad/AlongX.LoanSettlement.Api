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
    public class App
    {
        public AuthorizedInfoModel Authenticate(CredentialsModel Request)
        {
            try
            {
                StringFormatter stringFormatter = new StringFormatter();
                DataTable dataTable = new SqlQuery().Execute("usp_login", new List<SqlStoreProcedureEntity>()
                {
                  new SqlStoreProcedureEntity()
                  {
                    name = "login_id",
                    datatype = SqlDbType.NVarChar,
                    value = Request.login_id.ToString()
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "password",
                    datatype = SqlDbType.NVarChar,
                    value = stringFormatter.encrypt(stringFormatter.decrypt(Request.password.ToString()))
                  }
                }); ;

                if(dataTable.Rows[0]["status"].ToString() == "0")
                {
                    AuthorizedInfoModel authorizedInfoModels = new AuthorizedInfoModel();
                    authorizedInfoModels.status = false;
                    authorizedInfoModels.message = dataTable.Rows[0]["message"].ToString();

                    return authorizedInfoModels;
                }
                else
                {
                    return (AuthorizedInfoModel)dataTable.AsEnumerable().Select<DataRow, AuthorizedInfoModel>((Func<DataRow, AuthorizedInfoModel>)(row => new AuthorizedInfoModel()
                    {
                        id = row.Field<long>("id"),
                        business_name = row.Field<string>("business_name"),
                        logo_url = row.Field<string>("logo_url"),
                        business_email = row.Field<string>("business_email"),
                        business_mobile = row.Field<string>("business_mobile"),
                        business_whatsapp = row.Field<string>("business_whatsapp"),
                        business_website = row.Field<string>("business_website"),
                        gst_number = row.Field<string>("gst_number"),
                        business_address = row.Field<string>("business_address"),
                        currency_name = row.Field<string>("currency_name"),
                        currency_symbol = row.Field<string>("currency_symbol"),
                        invoice_prefix = row.Field<string>("invoice_prefix"),
                        app_status = row.Field<bool>("app_status"),
                        service_provider_message = row.Field<string>("service_provider_message"),
                        role_id = row.Field<long>("role_id"),
                        role_name = row.Field<string>("role_name"),
                        role_description = row.Field<string>("role_description"),
                        outlet_id = row.Field<long>("outlet_id"),
                        warehouse_id = row.Field<long>("warehouse_id"),
                        outlet_name = row.Field<string>("outlet_name"),
                        warehouse_name = row.Field<string>("warehouse_name"),
                        is_active = row.Field<bool>("is_active"),
                        full_name = row.Field<string>("full_name"),
                        thumbnail_name = GenerateTumbnail(row.Field<string>("full_name")),
                        user_email = row.Field<string>("user_email"),
                        user_mobile = row.Field<string>("user_mobile"),
                        last_login = row.Field<string>("last_login"),
                        status = row.Field<int>("status") == 1 ? true : false,
                        message = row.Field<string>("message"),
                        user_id = row.Field<long>("user_id"),
                        fy = row.Field<long>("fy"),
                        fy_display_name = row.Field<string>("fy_display_name"),
                        start_day = row.Field<int>("start_day"),
                        start_month = row.Field<int>("start_month"),
                        end_day = row.Field<int>("end_day"),
                        end_month = row.Field<int>("end_month"),
                        default_filter_view_type = row.Field<string>("default_filter_view_type"),
                        default_filter_ranger = row.Field<int>("default_filter_ranger"),

                    })).FirstOrDefault<AuthorizedInfoModel>();
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GenerateTumbnail(string text)
        {
            string output = "";
            if (text.Length == 1)
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

        public IList<FYModel> GetFY()
        {
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_getFY", new List<SqlStoreProcedureEntity>()
                {
                });

                return (IList<FYModel>)dataTable.AsEnumerable().Select<DataRow, FYModel>((Func<DataRow, FYModel>)(row => new FYModel()
                {
                    id = row.Field<long>("id"),
                    display_name = row.Field<string>("display_name"),
                    start_day = row.Field<int>("start_day"),
                    start_month = row.Field<int>("start_month"),
                    end_day = row.Field<int>("end_day"),
                    end_month = row.Field<int>("end_month")

                })).ToList<FYModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public IList<MandatoryActionsModel> GetMandaroryActions()
        //{
        //    try
        //    {
        //        DataTable dataTable = new SqlQuery().Execute("usp_getMandatoryActions", new List<SqlStoreProcedureEntity>()
        //        {
        //        });

        //        return (IList<MandatoryActionsModel>)dataTable.AsEnumerable().Select<DataRow, MandatoryActionsModel>((Func<DataRow, MandatoryActionsModel>)(row => new MandatoryActionsModel()
        //        {
        //            action_name = row.Field<string>("action_name"),
        //            is_required = row.Field<bool>("is_required"),
        //            action_link = row.Field<string>("action_link")

        //        })).ToList<MandatoryActionsModel>();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}