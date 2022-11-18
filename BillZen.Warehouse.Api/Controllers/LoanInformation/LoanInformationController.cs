using BillZen.Warehouse.Api.DAL.Customer;
using BillZen.Warehouse.Api.DAL.LoanInfo;
using BillZen.Warehouse.Api.DAL.LoanInformation;
using BillZen.Warehouse.Api.Models.Customer;
using BillZen.Warehouse.Api.Models.LoanInfo;
using BillZen.Warehouse.Api.Models.LoanInformation;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BillZen.Warehouse.Api.Controllers
{ 
    public class LoanInformationController : ApiController
    {

        [HttpGet]
        public LoanCalcModel Get(long loan_information_id = 0)
        {
            LoanInformationModel loanInformation= new LoanInformationModel();
            decimal totalCharges, relfLowrEnd =0, unsecured=0,digitalLender=0,loanDuration=0,DelayinDays,relfHigher=0,subscriptionfee=0, total_payable_inclde=0;
           

           IList<LoanInformationModel> loanInformationList = new List<LoanInformationModel>();

            try
            {
                DataTable dataTable = new SqlQuery().Execute("usp_getLoaninfro", new List<SqlStoreProcedureEntity>()
                {
                    new SqlStoreProcedureEntity()
                    {
                        name = "loan_information_id",
                        datatype = SqlDbType.BigInt,
                        value = loan_information_id.ToString()
                    },
                });

                loanInformation = (from row in dataTable.AsEnumerable()
                                   where row.Field<long>("loan_information_id") == loan_information_id
                                   select new LoanInformationModel
                                   {
                                       loan_information_id = row.Field<long>("loan_information_id"),
                                       customer_id = row.Field<long>("customer_id"),
                                       loan_provider_id = row.Field<long>("loan_provider_id"),
                                       loan_account_number = row.Field<string>("loan_account_number"),
                                       lender_type = row.Field<string>("lender_type"),
                                       loan_type = row.Field<string>("loan_type"),
                                       loan_service_provider = row.Field<string>("loan_service_provider"),
                                       regulated_entity = row.Field<string>("regulated_entity"),
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

                                   }).FirstOrDefault();
                var sumcharges = loanInformation.processing_fee + Convert.ToDecimal(loanInformation.interest) + loanInformation.Insurance_amount + loanInformation.other_charges;

              totalCharges =  sumcharges  / loanInformation.total_outstanding_amount * 100;

                 if(loanInformation.lender_type == "Digital")
                {
                    relfLowrEnd = totalCharges * 75 / 100;
                    
                }
                else
                {
                    relfLowrEnd = totalCharges * 50 / 100;
                }

                if (loanInformation.loan_type == "Unsecured")
                {

                    unsecured =  loanInformation.total_outstanding_amount*5/100;

                }
                else
                {
                    unsecured = 0;
                }

                if (loanInformation.lender_type == "Digital")
                {
                    digitalLender = loanInformation.total_outstanding_amount*10/100;

                }
                else
                {
                    digitalLender = 0;
                }

                if (loanInformation.loan_tenure == "<Month"||loanInformation.loan_tenure=="Month")
                {
                    loanDuration = loanInformation.total_outstanding_amount * 10 / 100;

                }
                else
                {
                    loanDuration = 0;
                }

                if (Convert.ToInt32(loanInformation.loan_delay) < 90)
                {
                    DelayinDays = loanInformation.total_outstanding_amount * 5/100;

                }
                else
                {
                    DelayinDays = 0 ;
                }

                //Subscription payement calculation
                var outstand = loanInformation.total_outstanding_amount;
                if (outstand < 10000)
                {
                    subscriptionfee = 199;

                }
                else if (outstand > 10000 || outstand == 20000)
                {
                    subscriptionfee = 299;
                }
                else if (outstand > 20000 || outstand < 30000)
                {
                    subscriptionfee = 399;
                }
                else if (outstand > 20000 || outstand < 30000)
                {
                    subscriptionfee = 499;
                }
                else if (outstand > 30000 || outstand < 40000)
                {
                    subscriptionfee = 599;
                }
                else if (outstand > 40000 || outstand < 50000)
                {
                    subscriptionfee = 699;
                }
                else if (outstand > 60000 || outstand < 70000)
                {
                    subscriptionfee = 799;
                }
                else if (outstand > 70000 || outstand < 80000)
                {
                    subscriptionfee = 899;
                }
                else if (outstand > 80000 || outstand > 90000)
                {
                    subscriptionfee = 999;
                }
                 total_payable_inclde = loanInformation.total_outstanding_amount + subscriptionfee;

                relfHigher = relfLowrEnd+unsecured+digitalLender+loanDuration+DelayinDays;
                var relHigherEnd = relfHigher / 100;
                LoanCalcModel loanCalcModel = new LoanCalcModel();
                loanCalcModel.relfLowrEnd =decimal.Round(relfLowrEnd).ToString();
                loanCalcModel.relHigherEnd = decimal.Round(relHigherEnd).ToString();
                loanCalcModel.subscriptionfee=decimal.Round(subscriptionfee).ToString();
                loanCalcModel.total_payable_inclde = decimal.Round(total_payable_inclde).ToString();

                return loanCalcModel;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

       

        [HttpPost]
        public DBResponse Post([FromBody] LoanInformationModel _model)
        {
            DBResponse response = new DBResponse();
            try
            {
                LoanInformation request = new LoanInformation();
                response = request.SaveLoanInformation(_model);
                return response;
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message.ToString();
                return response;
            }
        }

    }
}
