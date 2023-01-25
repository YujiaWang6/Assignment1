using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;

namespace Assignment1.Controllers
{
    public class HostingCostController : ApiController
    {
        /// <summary>
        /// This method is to input the days {id} and output 3 strings with calculated hosting cost based on the input days.
        /// </summary>
        /// <param name="id">input number of total days</param>
        /// <explanation> The input number will be the total days. As $5.5/FN (fortnight = 14 days), the fortnight number should be calculated based on the total days.
        /// Then, the fee before tax will be calculated as fortnight number times 5.5.
        /// Then, the 13% HST should be calculated based on the fee from last step.
        /// Then, add fee before tax and tax together as the total fee.
        /// convert them to string and output them.
        /// </explanation>
        /// <returns>
        /// "(number of fortnights) fortnights at $5.5/FN = $(fee before tax) CAD"
        /// "HST 13% = $(tax calculated based on last step)"
        /// "Total = $(total fee)CAD"
        /// </returns>
        /// <example>
        /// GET: api/HostingCost/0  -->  1 fortnights at $5.50/FN = $5.50 CAD
        ///                              HST 13% = $0.72 CAD
        ///                              Total = $6.22 CAD
        /// </example>
        /// <example>
        /// GET: api/HostingCost/14  --> 2 fortnights at $5.50/FN = $11.00 CAD
        ///                              HST 13% = $1.43 CAD
        ///                              Total = $12.43 CAD
        /// </example>
        /// <example>
        /// GET: api/HostingCost/15  --> 2 fortnights at $5.50/FN = $11.00 CAD
        ///                              HST 13% = $1.43 CAD
        ///                              Total = $12.43 CAD                          
        /// </example>
        /// <example>
        /// GET: api/HostingCost/21  --> 2 fortnights at $5.50/FN = $11.00 CAD
        ///                              HST 13% = $1.43 CAD
        ///                              Total = $12.43 CAD
        /// </example>
        /// <example>
        /// GET: api/HostingCost/28  --> 3 fortnights at $5.50/FN = $16.50 CAD
        ///                              HST 13% = $2.14 CAD
        ///                              Total = $18.64 CAD
        /// </example>
        public IEnumerable<string> Get(decimal id)
        {
            //convert input days to number of fortnights
            decimal numberOfFortnights = decimal.Floor(id / 14) + 1;

            //convert type decimal to type double
            double doubleNumberOfFortnights = Decimal.ToDouble(numberOfFortnights);

            //calculation of fees,tax and total fee (keep 2 decimal)
            double feeBeforeTax = (doubleNumberOfFortnights * 5.5);

            double tax = (feeBeforeTax * 0.13);

            double totalFee = feeBeforeTax + tax;

            //convert all the calculated values into strings
            string fortnightsNumberString = doubleNumberOfFortnights.ToString();

            string feeBeforeTaxString = feeBeforeTax.ToString("C",CultureInfo.CurrentCulture);

            string taxString = tax.ToString("C", CultureInfo.CurrentCulture);

            string totalFeeString = totalFee.ToString("C", CultureInfo.CurrentCulture);

            //combine with other words
            string firstSentence = fortnightsNumberString + " fortnights at $5.50/FN = $" + feeBeforeTaxString + " CAD";

            string secondSentence = "HST 13% = $" + taxString + " CAD";

            string thirdSentence = "Total = $" + totalFeeString + " CAD";

            //combine the output string
            return new string[] { firstSentence , secondSentence , thirdSentence };
        }
    }
}

//Thoughts and error made when solving this question:
//input id >= 14 --> 2 fortnights
// id/14 using rounded ceiling as the number of fortnights
//check return numberOfFortnights (return type is decimal to check the value)
//add functions for the calculation of the fees
//first step: times 5.5 as feeBeforeTax (error occur, as (numberOfFortnights * 5.5) is decimal * double --> change decimal to double)
//            solved, using Decimal.ToDouble(numberOfFortnights)
//second step: times 0.13 as 13% tax
//third step: add feeBeforeTax+tax as totalFee
//fourth step: conver to string .ToString()
//fifth step: combine with sentence
//sixth step: return the stings(error: sentences are connected together)
//            solved, using IEnumerable<string> to seperate
//another error, 0 is not included, probably using if statement. or using round floor and add 1 as numberOfFortnights
//another error, decimal place is not 2  --> solved. using tax = (double)System.Math.Round(tax, 2); string.Format("{0:F2}", tax);
//HOW TO KEEP 11 AS 11.00????
//solved, using C# currency format: string totalFeeString = totalFee.ToString("C", CultureInfo.CurrentCulture);








