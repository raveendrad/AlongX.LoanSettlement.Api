using BillZen.Warehouse.Api.Models.CustomerInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BillZen.Warehouse.Api.DAL.CustomerInfo
{
    public class CustomerInfo
    {

        public IList<CustomerInfoModel> GetAllCustomerInfo(long customer_id)
        {
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_getCustomerInfo", new List<SqlStoreProcedureEntity>()
                {
                    new SqlStoreProcedureEntity()
                    {
                        name = "customer_id",
                        datatype = SqlDbType.BigInt,
                        value = customer_id.ToString()
                    }
                });

                return (IList<CustomerInfoModel>)dataTable.AsEnumerable().Select<DataRow, CustomerInfoModel>((Func<DataRow, CustomerInfoModel>)(row => new CustomerInfoModel()
                {
                    customer_id = row.Field<long>("customer_id"),
                    loan_provider_name = row.Field<string>("loan_provider_name"),
                    loan_account_number = row.Field<string>("loan_account_number"),
                    loan_type = row.Field<string>("loan_type"),
                    total_loan_emi_pending_with_fine = row.Field<decimal>("total_loan_emi_pending_with_fine"),
                    suggested_settlement_amount = row.Field<decimal>("suggested_settlement_amount"),
                    payment_status = row.Field<bool>("payment_status"),
                    resolve_status = row.Field<bool>("resolve_status")

                })).ToList<CustomerInfoModel>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}