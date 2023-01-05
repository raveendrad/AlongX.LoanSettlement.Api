using BillZen.Warehouse.Api.Models.Customer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace BillZen.Warehouse.Api.DAL.Customer
{
    public class Customer
    {
        public IList<CustomerModel> GetAllCustomers(long customer_id, string mobile_number)
        {
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_getCustomers", new List<SqlStoreProcedureEntity>()
                {
                    new SqlStoreProcedureEntity()
                    {
                        name = "customer_id",
                        datatype = SqlDbType.BigInt,
                        value = customer_id.ToString()
                    },
                      new SqlStoreProcedureEntity()
                    {
                        name = "mobile_number",
                        datatype = SqlDbType.NVarChar,
                        value = mobile_number
                    }
                });

                return (IList<CustomerModel>)dataTable.AsEnumerable().Select<DataRow, CustomerModel>((Func<DataRow, CustomerModel>)(row => new CustomerModel()
                {
                    customer_id = row.Field<long>("customer_id"),
                    name = row.Field<string>("name"),
                    email = row.Field<string>("email"),
                    mobile_number = row.Field<string>("mobile_number"),
                    alternate_mobile_number = row.Field<string>("alternate_mobile_number"),
                    full_address = row.Field<string>("full_address"),
                    city = row.Field<string>("city"),
                    state = row.Field<string>("state"),
                    pincode = row.Field<string>("pincode"),
                    occupation = row.Field<string>("occupation"),
                    your_earning_per_month = row.Field<decimal>("your_earning_per_month"),
                    gender = row.Field<string>("gender"),
                    date_of_birth = row.Field<DateTime>("date_of_birth").ToLongDateString(),
                    date_of_registration = row.Field<DateTime>("date_of_registration").ToLongDateString(),
                    password = row.Field<string>("password"),
                    pan_card = row.Field<string>("pan_card"),
                    adhaar_card = row.Field<string>("adhaar_card")

                })).ToList<CustomerModel>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DBResponse SaveCustomer(CustomerModel Request)
        {
            DBResponse response = new DBResponse();
            try
            {
                string randomPassword = GetRandomPassword(10);
                DataTable dataTable = new SqlQuery().Execute("usp_saveCustomer", new List<SqlStoreProcedureEntity>()
                {
                  new SqlStoreProcedureEntity()
                  {
                    name = "customer_id",
                    datatype = SqlDbType.BigInt,
                    value = Request.customer_id.ToString()
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "name",
                    datatype = SqlDbType.NVarChar,
                    value = Request.name
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "email",
                    datatype = SqlDbType.NVarChar,
                    value = Request.email
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "mobile_number",
                    datatype = SqlDbType.NVarChar,
                    value = Request.mobile_number
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "alternate_mobile_number",
                    datatype = SqlDbType.NVarChar,
                    value = Request.alternate_mobile_number
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "full_address",
                    datatype = SqlDbType.NVarChar,
                    value = Request.full_address
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "city",
                    datatype = SqlDbType.NVarChar,
                    value = Request.city
                  },
                    new SqlStoreProcedureEntity()
                  {
                    name = "state",
                    datatype = SqlDbType.NVarChar,
                    value = Request.state
                  },
                    new SqlStoreProcedureEntity()
                  {
                    name = "pincode",
                    datatype = SqlDbType.NVarChar,
                    value = Request.pincode
                  },
                    new SqlStoreProcedureEntity()
                  {
                    name = "occupation",
                    datatype = SqlDbType.NVarChar,
                    value = Request.occupation
                  },
                    new SqlStoreProcedureEntity()
                  {
                    name = "your_earning_per_month",
                    datatype = SqlDbType.Decimal,
                    value = Request.your_earning_per_month.ToString()
                  },

                    new SqlStoreProcedureEntity()
                  {
                    name = "gender",
                    datatype = SqlDbType.NVarChar,
                    value = Request.gender
                  },

                    new SqlStoreProcedureEntity()
                  {
                    name = "date_of_birth",
                    datatype = SqlDbType.Date,
                   value = Request.date_of_birth.ToString()
                  },

                    new SqlStoreProcedureEntity()
                  {
                    name = "date_of_registration",
                    datatype = SqlDbType.Date,
                   value =DateTime.Today.ToString()
                  },

                    new SqlStoreProcedureEntity()
                  {
                    name = "password",
                    datatype = SqlDbType.NVarChar,
                    value = randomPassword
                  },
                     new SqlStoreProcedureEntity()
                  {
                    name = "pan_card",
                    datatype = SqlDbType.NVarChar,
                    value = Request.pan_card
                  },
                      new SqlStoreProcedureEntity()
                  {
                    name = "adhaar_card",
                    datatype = SqlDbType.NVarChar,
                    value = Request.adhaar_card
                  },
                });
                response.status = Convert.ToBoolean(dataTable.Rows[0][0]);
                response.message = dataTable.Rows[0][1].ToString();
                if (response.status && Request.customer_id == 0)
                {
                    string htmlBody = "<h4>Hi " + Request.name + ",</h4>";
                    htmlBody += "<p>You have been given access to the " + ConfigurationManager.AppSettings["smtp_display_name"] + " application. Please find below your credential to login. </p>";
                    htmlBody += "<span>Login ID - <b>" + Request.mobile_number + "</b></span><br>";
                    htmlBody += "<span>Password - <b>" + randomPassword + "</b></span><br>";
                    new MessageSender().SendMail(ConfigurationManager.AppSettings["smtp_display_name"], Request.email, "Credential to Access Confirm Finance Portal.", htmlBody, "", "");
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

        public DBResponse DeleteCustomer(long customer_id)
        {
            DBResponse response = new DBResponse();
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_deleteCustomer", new List<SqlStoreProcedureEntity>()
                {
                  new SqlStoreProcedureEntity()
                  {
                    name = "customer_id",
                    datatype = SqlDbType.BigInt,
                    value = customer_id.ToString()
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

        public DBResponse UpdateCustomerInfo(CustomerModel Request)
        {
            DBResponse response = new DBResponse();
            try
            {
                //string salesproduct_json = JsonConvert.SerializeObject(Request.salesproduct);
                DataTable dataTable = new SqlQuery().Execute("usp_updateCustomerInfo", new List<SqlStoreProcedureEntity>()
                {
                    new SqlStoreProcedureEntity()
                  {
                    name = "customer_id",
                    datatype = SqlDbType.BigInt,
                    value = Request.customer_id.ToString()
                  },

                  new SqlStoreProcedureEntity()
                  {
                    name = "name",
                    datatype = SqlDbType.NVarChar,
                    value = Request.name
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "email",
                    datatype = SqlDbType.NVarChar,
                    value = Request.email
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "your_earning_per_month",
                    datatype = SqlDbType.Decimal,
                    value = Request.your_earning_per_month.ToString()
                  },
                    new SqlStoreProcedureEntity()
                  {
                    name = "full_address",
                    datatype = SqlDbType.NVarChar,
                    value = Request.full_address
                  },
                     new SqlStoreProcedureEntity()
                  {
                    name = "pincode",
                    datatype = SqlDbType.NVarChar,
                    value = Request.pincode
                  },
                      new SqlStoreProcedureEntity()
                  {
                    name = "city",
                    datatype = SqlDbType.NVarChar,
                    value = Request.city
                  },

                       new SqlStoreProcedureEntity()
                  {
                    name = "state",
                    datatype = SqlDbType.NVarChar,
                    value = Request.state
                  },

                   new SqlStoreProcedureEntity()
                  {
                    name = "adhaar_card",
                    datatype = SqlDbType.NVarChar,
                    value = Request.adhaar_card
                  },
                   new SqlStoreProcedureEntity()
                  {
                    name = "pan_card",
                    datatype = SqlDbType.NVarChar,
                    value = Request.pan_card
                  }
                });
                response.status = Convert.ToBoolean(dataTable.Rows[0][0]);
                response.message = dataTable.Rows[0][1].ToString();
                //response.indentno = Convert.ToInt64(dataTable.Rows[0][2]);
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