using BillZen.Warehouse.Api.Models.Customer;
using BillZen.Warehouse.Api.Models.LoanInformation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BillZen.Warehouse.Api.DAL.GetLoanInformation
{
    public class GetLoanInformation
    {
        public IList<LoanInformationModel> GetAllLoanInformation(long customer_id)
        {
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_getLoanInformation", new List<SqlStoreProcedureEntity>()
                {
                    new SqlStoreProcedureEntity()
                    {
                        name = "customer_id",
                        datatype = SqlDbType.BigInt,
                        value = customer_id.ToString()
                    },
                });

                return (IList<LoanInformationModel>)dataTable.AsEnumerable().Select<DataRow, LoanInformationModel>((Func<DataRow, LoanInformationModel>)(row => new LoanInformationModel()
                {
                    loan_information_id = row.Field<long>("loan_information_id"),
                    customer_id = row.Field<long>("customer_id"),
                    loan_provider_id = row.Field<long>("loan_provider_id"),
                    lender_type = row.Field<string>("lender_type"),
                    loan_service_provider = row.Field<string>("loan_service_provider"),
                    regulated_entity = row.Field<string>("regulated_entity"),
                    loan_type = row.Field<string>("loan_type"),
                    loan_account_number = row.Field<string>("loan_account_number"),
                    loan_tenure = row.Field<string>("loan_tenure"),
                    toatl_emis = row.Field<string>("toatl_emis"),
                    loan_delay = row.Field<string>("loan_delay"),
                    principal_amount = row.Field<decimal>("principal_amount"),
                    processing_fee = row.Field<decimal>("processing_fee"),
                    Insurance_amount = row.Field<decimal>("Insurance_amount"),
                    other_charges = row.Field<decimal>("other_charges"),
                    total_outstanding_amount = row.Field<decimal>("total_outstanding_amount"),
                    loan_document = row.Field<string>("loan_document"),
                    settlement_reason = row.Field<string>("settlement_reason"),
                    payment_status = row.Field<string>("payment_status"),
                    resolve_status = row.Field<string>("resolve_status"),
                    interest = row.Field<string>("interest"),

                })).ToList<LoanInformationModel>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}