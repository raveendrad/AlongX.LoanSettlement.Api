using BillZen.Warehouse.Api.Models.LoanInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BillZen.Warehouse.Api.DAL.LoanInfo
{
    public class LoanInfo
    {
        public IList<LoanInfoModel> GetAllLoanInfo(long customer_id)
        {
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_getLoanInfo", new List<SqlStoreProcedureEntity>()
                {
                    new SqlStoreProcedureEntity()
                    {
                        name = "customer_id",
                        datatype = SqlDbType.BigInt,
                        value = customer_id.ToString()
                    },
                });

                return (IList<LoanInfoModel>)dataTable.AsEnumerable().Select<DataRow, LoanInfoModel>((Func<DataRow, LoanInfoModel>)(row => new LoanInfoModel()
                {
                    loan_info_id = row.Field<long>("loan_info_id"),
                    customer_id = row.Field<long>("customer_id"),
                    loan_provider_id = row.Field<long>("loan_provider_id"),
                    loan_provider_name = row.Field<string>("loan_provider_name"),
                    loan_type = row.Field<string>("loan_type"),
                    sanction_date = row.Field<DateTime>("sanction_date").ToLongDateString(),
                    total_loan_sanctioned_amount = row.Field<decimal>("total_loan_sanctioned_amount"),
                    total_loan_recieved_amount = row.Field<decimal>("total_loan_recieved_amount"),
                    total_amount_per_emi = row.Field<decimal>("total_amount_per_emi"),
                    total_loan_emi_commited = row.Field<decimal>("total_loan_emi_commited"),
                    total_loan_emi_paid = row.Field<decimal>("total_loan_emi_paid"),
                    total_loan_emi_pending_without_fine = row.Field<decimal>("total_loan_emi_pending_without_fine"),
                    total_loan_emi_pending_with_fine = row.Field<decimal>("total_loan_emi_pending_with_fine"),
                    last_emi_paid = row.Field<decimal>("last_emi_paid"),
                    difaulter_since = row.Field<DateTime>("difaulter_since").ToLongDateString(),
                    additional_info = row.Field<string>("additional_info"),
                    loan_document = row.Field<string>("loan_document"),
                    loan_account_number = row.Field<string>("loan_account_number"),
                    defaulter_reason = row.Field<string>("defaulter_reason"),
                    suggested_settlement_amount = row.Field<decimal>("suggested_settlement_amount"),
                    actual_settlement_amount = row.Field<decimal>("actual_settlement_amount"),
                    payment_status = row.Field<string>("payment_status"),
                    resolve_status = row.Field<string>("resolve_status")

                })).ToList<LoanInfoModel>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DBResponse SaveLoanInfo(LoanInfoModel Request)
        {
            DBResponse response = new DBResponse();
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_saveLoanInfo", new List<SqlStoreProcedureEntity>()
                {
                  new SqlStoreProcedureEntity()
                  {
                    name = "loan_info_id",
                    datatype = SqlDbType.BigInt,
                    value = Request.loan_info_id.ToString()
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "customer_id",
                    datatype = SqlDbType.BigInt,
                    value = Request.customer_id.ToString()
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "loan_provider_id",
                    datatype = SqlDbType.BigInt,
                    value = Request.loan_provider_id.ToString()
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "loan_type",
                    datatype = SqlDbType.NVarChar,
                    value = Request.loan_type
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "sanction_date",
                    datatype = SqlDbType.Date,
                   value = Request.sanction_date.ToString()
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "total_loan_sanctioned_amount",
                    datatype = SqlDbType.Decimal,
                    value = Request.total_loan_sanctioned_amount.ToString()
                  },
                   new SqlStoreProcedureEntity()
                  {
                    name = "total_loan_recieved_amount",
                    datatype = SqlDbType.Decimal,
                    value = Request.total_loan_recieved_amount.ToString()
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "total_amount_per_emi",
                    datatype = SqlDbType.Decimal,
                    value = Request.total_amount_per_emi.ToString()
                  },
                   new SqlStoreProcedureEntity()
                  {
                    name = "total_loan_emi_commited",
                    datatype = SqlDbType.Decimal,
                    value = Request.total_loan_emi_commited.ToString()
                  },
                    new SqlStoreProcedureEntity()
                  {
                    name = "total_loan_emi_paid",
                    datatype = SqlDbType.Decimal,
                    value = Request.total_loan_emi_paid.ToString()
                  },
                     new SqlStoreProcedureEntity()
                  {
                    name = "total_loan_emi_pending_without_fine",
                    datatype = SqlDbType.Decimal,
                    value = Request.total_loan_emi_pending_without_fine.ToString()
                  },
                      new SqlStoreProcedureEntity()
                  {
                    name = "total_loan_emi_pending_with_fine",
                    datatype = SqlDbType.Decimal,
                    value = Request.total_loan_emi_pending_with_fine.ToString()
                  },
                       new SqlStoreProcedureEntity()
                  {
                    name = "last_emi_paid",
                    datatype = SqlDbType.Decimal,
                    value = Request.last_emi_paid.ToString()
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "difaulter_since",
                    datatype = SqlDbType.NVarChar,
                    value = Request.difaulter_since
                  },
                    new SqlStoreProcedureEntity()
                  {
                    name = "additional_info",
                    datatype = SqlDbType.NVarChar,
                    value = Request.additional_info
                  },
                    new SqlStoreProcedureEntity()
                  {
                    name = "loan_document",
                    datatype = SqlDbType.NVarChar,
                    value = Request.loan_document
                  },
                    new SqlStoreProcedureEntity()
                  {
                    name = "loan_account_number",
                    datatype = SqlDbType.NVarChar,
                    value = Request.loan_account_number
                  },
                     new SqlStoreProcedureEntity()
                  {
                    name = "defaulter_reason",
                    datatype = SqlDbType.NVarChar,
                    value = Request.defaulter_reason
                  },
                    new SqlStoreProcedureEntity()
                  {
                    name = "suggested_settlement_amount",
                    datatype = SqlDbType.Decimal,
                    value = Request.suggested_settlement_amount.ToString()
                  },
                    new SqlStoreProcedureEntity()
                  {
                    name = "actual_settlement_amount",
                    datatype = SqlDbType.Decimal,
                    value = Request.actual_settlement_amount.ToString()
                  },
                    new SqlStoreProcedureEntity()
                  {
                    name = "payment_status",
                    datatype = SqlDbType.Bit,
                    value = Request.payment_status.ToString()
                  },
                    new SqlStoreProcedureEntity()
                  {
                    name = "resolve_status",
                    datatype = SqlDbType.Bit,
                    value = Request.resolve_status.ToString()
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

        public DBResponse DeleteLoanInfo(long loan_info_id)
        {
            DBResponse response = new DBResponse();
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_deleteCustomer", new List<SqlStoreProcedureEntity>()
                {
                  new SqlStoreProcedureEntity()
                  {
                    name = "loan_info_id",
                    datatype = SqlDbType.BigInt,
                    value = loan_info_id.ToString()
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