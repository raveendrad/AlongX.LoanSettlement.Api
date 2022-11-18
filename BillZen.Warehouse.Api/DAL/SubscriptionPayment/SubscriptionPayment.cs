using BillZen.Warehouse.Api.Models.Customer;
using BillZen.Warehouse.Api.Models.LoanInformation;
using BillZen.Warehouse.Api.Models.SubscriptionPayment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BillZen.Warehouse.Api.DAL.SubscriptionPayment
{
    public class SubscriptionPayment
    {

        public IList<SubscriptionPaymentModel> GetSubscriptionPayment(long customer_id,long loan_information_id)
        {
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_getSubscriptionPayment", new List<SqlStoreProcedureEntity>()
                {
                    
                     new SqlStoreProcedureEntity()
                    {
                        name = "customer_id",
                        datatype = SqlDbType.BigInt,
                        value = customer_id.ToString()
                    },
                      new SqlStoreProcedureEntity()
                    {
                        name = "loan_information_id",
                        datatype = SqlDbType.BigInt,
                        value = loan_information_id.ToString()
                    }
                });

                return (IList<SubscriptionPaymentModel>)dataTable.AsEnumerable().Select<DataRow, SubscriptionPaymentModel>((Func<DataRow, SubscriptionPaymentModel>)(row => new SubscriptionPaymentModel()
                {
                    payment_id = row.Field<long>("payment_id"),
                    customer_id = row.Field<long>("customer_id"),
                    loan_information_id = row.Field<long>("loan_information_id"),
                    payment_date = row.Field<DateTime>("payment_date").ToLongDateString(),

                    amount = row.Field<decimal>("amount"),
                    payment_mode = row.Field<string>("payment_mode"),
                    payment_references = row.Field<string>("payment_references"),

                })).ToList<SubscriptionPaymentModel>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }







        public DBResponse SaveSubscriptionPayment(SubscriptionPaymentModel Request)
        {
            DBResponse response = new DBResponse();
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_saveSubscriptionPayment", new List<SqlStoreProcedureEntity>()
                {
                  new SqlStoreProcedureEntity()
                  {
                    name = "payment_id",
                    datatype = SqlDbType.BigInt,
                    value = Request.payment_id.ToString()
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "customer_id",
                    datatype = SqlDbType.BigInt,
                    value = Request.customer_id.ToString()
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "loan_information_id",
                    datatype = SqlDbType.BigInt,
                    value = Request.loan_information_id.ToString()
                  },
                 new SqlStoreProcedureEntity()
                  {
                    name = "payment_date",
                    datatype = SqlDbType.Date,
                   value = Request.payment_date.ToString()
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "amount",
                    datatype = SqlDbType.Decimal,
                    value = Request.amount.ToString()
                  },

                  new SqlStoreProcedureEntity()
                  {
                    name = "payment_mode",
                    datatype = SqlDbType.NVarChar,
                    value = Request.payment_mode
                  },

                    new SqlStoreProcedureEntity()
                  {
                    name = "payment_references",
                    datatype = SqlDbType.NVarChar,
                    value = Request.payment_references
                  },

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