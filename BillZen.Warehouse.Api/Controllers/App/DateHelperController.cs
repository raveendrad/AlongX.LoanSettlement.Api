using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BillZen.Warehouse.Api.Controllers
{
    public class DateHelperController : ApiController
    {
        [HttpGet]
        public DateHelperModel Get(string viewType, int positiveRange,int startDay,int startMonth, int endDay, int endMonth)
        {
            int range = (positiveRange * (-1));
            DateHelperModel outputDate = new DateHelperModel();
            DateTime currentDate = DateTime.Now;
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();
            if (viewType == "Day")
            {
                startDate = currentDate.AddDays(range);
                if (range == 0)
                {
                    endDate = startDate.AddDays(Math.Abs(range));
                }
                else
                {
                    endDate = startDate.AddDays(Math.Abs(range)).AddDays(-1);
                }
            }
            if (viewType == "Week")
            {
                while (currentDate.DayOfWeek != DayOfWeek.Monday)
                {
                    currentDate = currentDate.AddDays(-1);
                }

                startDate = currentDate.AddDays((-7 * Math.Abs(range)));
                if (range == 0)
                {
                    endDate = startDate.AddDays((7 * 1)).AddDays(-1);
                }
                else
                {
                    endDate = startDate.AddDays((7 * Math.Abs(range))).AddDays(-1);
                }
                
            }
            if (viewType == "Month")
            {
                startDate = currentDate.AddMonths(range).AddDays(1 - currentDate.Day);
                if (range == 0)
                {
                    endDate = startDate.AddMonths(1).AddDays(-1);
                }
                else
                {
                    endDate = startDate.AddMonths(Math.Abs(range)).AddDays(-1);
                }
            }
            if (viewType == "FY")
            {
                CultureInfo culture = new CultureInfo("en-IN");
                startDate = Convert.ToDateTime(startDay + "-" + startMonth + "-" + DateTime.Now.Year, culture);
                endDate = Convert.ToDateTime(endDay + "-" + endMonth + "-" + DateTime.Now.Year, culture);

                startDate = startDate.AddYears(range);
                if (range == 0)
                {
                    endDate = endDate.AddYears(range).AddYears(Math.Abs(range+1));
                }
                else
                {
                    endDate = endDate.AddYears(range).AddYears(Math.Abs(range));
                }
               
            }
            outputDate.startDate = startDate.ToString("yyyy-MM-dd");
            outputDate.endtDate = endDate.ToString("yyyy-MM-dd");

            return outputDate;
        }

        [HttpGet]
        public IList<string> Get(DateTime startDate, DateTime endDate)
        {
            List<string> response = new List<string>();
            response.Add(startDate.ToLongDateString());
            if (endDate != null)
            {
                response.Add(endDate.ToLongDateString());
            }

            return response;
        }
    }
}
