using BillZen.Warehouse.Api.Models.Customer;
using BillZen.Warehouse.Api.Models.LoanInfo;
using BillZen.Warehouse.Api.Models.LoanInformation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BillZen.Warehouse.Api.DAL.LoanInformation
{
    public class LoanInformation
    {




        public DBResponse SaveLoanInformation(LoanInformationModel Request)
        {
            DBResponse response = new DBResponse();
            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_saveLoanInforomation", new List<SqlStoreProcedureEntity>()
                {
                  new SqlStoreProcedureEntity()
                  {
                    name = "loan_information_id",
                    datatype = SqlDbType.BigInt,
                    value = Request.loan_information_id.ToString()
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
                    name = "loan_account_number",
                    datatype = SqlDbType.NVarChar,
                    value = Request.loan_account_number
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "lender_type",
                    datatype = SqlDbType.NVarChar,
                    value = Request.lender_type
                  },
                 new SqlStoreProcedureEntity()
                  {
                    name = "loan_service_provider",
                    datatype = SqlDbType.NVarChar,
                    value = Request.loan_service_provider
                  },
                 new SqlStoreProcedureEntity()
                  {
                    name = "regulated_entity",
                    datatype = SqlDbType.NVarChar,
                    value = Request.regulated_entity
                  },
                 new SqlStoreProcedureEntity()
                  {
                    name = "loan_type",
                    datatype = SqlDbType.NVarChar,
                    value = Request.loan_type
                  },
                 new SqlStoreProcedureEntity()
                  {
                    name = "loan_tenure",
                    datatype = SqlDbType.NVarChar,
                    value = Request.loan_tenure
                  },
                 new SqlStoreProcedureEntity()
                  {
                    name = "toatl_emis",
                    datatype = SqlDbType.NVarChar,
                    value = Request.toatl_emis
                  },
                 new SqlStoreProcedureEntity()
                  {
                    name = "loan_delay",
                    datatype = SqlDbType.NVarChar,
                    value = Request.loan_delay
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "principal_amount",
                    datatype = SqlDbType.Decimal,
                    value = Request.principal_amount.ToString()
                  },
                   new SqlStoreProcedureEntity()
                  {
                    name = "processing_fee",
                    datatype = SqlDbType.Decimal,
                    value = Request.processing_fee.ToString()
                  },
                  new SqlStoreProcedureEntity()
                  {
                    name = "Insurance_amount",
                    datatype = SqlDbType.Decimal,
                    value = Request.Insurance_amount.ToString()
                  },
                   new SqlStoreProcedureEntity()
                  {
                    name = "other_charges",
                    datatype = SqlDbType.Decimal,
                    value = Request.other_charges.ToString()
                  },
                    new SqlStoreProcedureEntity()
                  {
                    name = "total_outstanding_amount",
                    datatype = SqlDbType.Decimal,
                    value = Request.total_outstanding_amount.ToString()
                  },

                  new SqlStoreProcedureEntity()
                  {
                    name = "loan_document",
                    datatype = SqlDbType.NVarChar,
                    value = Request.loan_document
                  },
                    new SqlStoreProcedureEntity()
                  {
                    name = "settlement_reason",
                    datatype = SqlDbType.NVarChar,
                    value = Request.settlement_reason
                  },
                    new SqlStoreProcedureEntity()
                  {
                    name = "payment_status",
                    datatype = SqlDbType.NVarChar,
                    value = Request.payment_status
                  },
                    new SqlStoreProcedureEntity()
                  {
                    name = "resolve_status",
                    datatype = SqlDbType.NVarChar,
                    value = Request.resolve_status
                  },
                    new SqlStoreProcedureEntity()
                  {
                    name = "interest",
                    datatype = SqlDbType.NVarChar,
                    value = Request.interest
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

        public DBResponse UpdateLoanPayement(LoanInformationModel Request)
        {
            DBResponse response = new DBResponse();
            try
            {
                //string salesproduct_json = JsonConvert.SerializeObject(Request.salesproduct);
                DataTable dataTable = new SqlQuery().Execute("usp_updateLoanInfo", new List<SqlStoreProcedureEntity>()
                {
                    new SqlStoreProcedureEntity()
                  {
                    name = "loan_information_id",
                    datatype = SqlDbType.BigInt,
                    value = Request.loan_information_id.ToString()
                  },

                   new SqlStoreProcedureEntity()
                  {
                    name = "resolve_status",
                    datatype = SqlDbType.NVarChar,
                    value = Request.resolve_status
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