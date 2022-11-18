using BillZen.Warehouse.Api.Models.LoanProviders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BillZen.Warehouse.Api.DAL.LoanProviders
{
    public class LoanProviders
    {
        public IList<LoanProvidersModel> GetAllLoanProviders(long loan_provider_id)
        {
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_getLoanProviders", new List<SqlStoreProcedureEntity>()
                {
                    new SqlStoreProcedureEntity()
                    {
                        name = "loan_provider_id",
                        datatype = SqlDbType.BigInt,
                        value = loan_provider_id.ToString()
                    }
                });

                return (IList<LoanProvidersModel>)dataTable.AsEnumerable().Select<DataRow, LoanProvidersModel>((Func<DataRow, LoanProvidersModel>)(row => new LoanProvidersModel()
                {
                    loan_provider_id = row.Field<long>("loan_provider_id"),
                    loan_provider_name = row.Field<string>("loan_provider_name"),
                    loan_platform = row.Field<string>("loan_platform"),
                    mobile_number = row.Field<string>("mobile_number"),
                    additional_discount_to_settlement = row.Field<decimal>("additional_discount_to_settlement"),
                    special_comments = row.Field<string>("special_comments")

                })).ToList<LoanProvidersModel>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DBResponse SaveLoanProviders(LoanProvidersModel Request)
        {
            DBResponse response = new DBResponse();
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_saveLoanProviders", new List<SqlStoreProcedureEntity>()
                {
                  new SqlStoreProcedureEntity()
                  {
                    name = "loan_provider_id",
                    datatype = SqlDbType.BigInt,
                    value = Request.loan_provider_id.ToString()
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "loan_provider_name",
                    datatype = SqlDbType.NVarChar,
                    value = Request.loan_provider_name
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "loan_platform",
                    datatype = SqlDbType.NVarChar,
                    value = Request.loan_platform
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "mobile_number",
                    datatype = SqlDbType.NVarChar,
                    value = Request.mobile_number
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "additional_discount_to_settlement",
                    datatype = SqlDbType.Decimal,
                    value = Request.additional_discount_to_settlement.ToString()
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "special_comments",
                    datatype = SqlDbType.NVarChar,
                    value = Request.special_comments
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

        public DBResponse DeleteLoanProviders(long loan_provider_id)
        {
            DBResponse response = new DBResponse();
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_deleteLoanProviders", new List<SqlStoreProcedureEntity>()
                {
                  new SqlStoreProcedureEntity()
                  {
                    name = "loan_provider_id",
                    datatype = SqlDbType.BigInt,
                    value = loan_provider_id.ToString()
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