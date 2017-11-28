using System;
using Temboo.Core;
using System.Web.Script.Serialization;

/*
Copyright 2014 Temboo, Inc.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

namespace Temboo.Library.Zillow
{
    /// <summary>
    /// GetMonthlyPayments
    /// Retrieve estimated monthly payments, including principal and interest based on current interest rates.
    /// </summary>
    public class GetMonthlyPayments : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetMonthlyPayments Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetMonthlyPayments(TembooSession session) : base(session, "/Library/Zillow/GetMonthlyPayments")
        {
        }

         /// <summary>
         /// (optional, integer) Specify the dollar amount that is placed for a down payment. This variable can be used in place of DownPaymentAmount.
         /// </summary>
         /// <param name="value">Value of the DollarsDown input for this Choreo.</param>
         public void setDollarsDown(String value) {
             base.addInput ("DollarsDown", value);
         }
         /// <summary>
         /// (optional, integer) Enter the percentage of the total properly price that will be used as a down payment. If < 20%, mortage insurance info is also returned.
         /// </summary>
         /// <param name="value">Value of the DownPaymentAmount input for this Choreo.</param>
         public void setDownPaymentAmount(String value) {
             base.addInput ("DownPaymentAmount", value);
         }
         /// <summary>
         /// (optional, string) Enter the desired query output format.  Enter: xml, or json.  Default output is set to: xml.
         /// </summary>
         /// <param name="value">Value of the OutputFormat input for this Choreo.</param>
         public void setOutputFormat(String value) {
             base.addInput ("OutputFormat", value);
         }
         /// <summary>
         /// (required, integer) Enter the price for which the monthly payment is to be calculated.
         /// </summary>
         /// <param name="value">Value of the Price input for this Choreo.</param>
         public void setPrice(String value) {
             base.addInput ("Price", value);
         }
         /// <summary>
         /// (required, string) Enter a Zillow Web Service Identifier (ZWS ID).
         /// </summary>
         /// <param name="value">Value of the ZWSID input for this Choreo.</param>
         public void setZWSID(String value) {
             base.addInput ("ZWSID", value);
         }
         /// <summary>
         /// (optional, integer) Enter the zip code of the property.  If null, no property tax, or hazard insurance data will be returned.
         /// </summary>
         /// <param name="value">Value of the Zip input for this Choreo.</param>
         public void setZip(String value) {
             base.addInput ("Zip", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetMonthlyPaymentsResultSet containing execution metadata and results.</returns>
        new public GetMonthlyPaymentsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetMonthlyPaymentsResultSet results = new JavaScriptSerializer().Deserialize<GetMonthlyPaymentsResultSet>(json);

            // Note that we may actually have run into an exception while trying to execute
            // this request; if so, then throw an appropriate exception
            if (results.Execution.LastError != null)
            {
                throw new TembooException(results.Execution.LastError);
            }
            return results;
        }

    }

    /// <summary>
    /// A ResultSet with methods tailored to the values returned by the GetMonthlyPayments Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetMonthlyPaymentsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) The response from Zillow.</returns>
        /// </summary>
        public String Response
        {
            get
            {
                return (String) base.Output["Response"];
            }
        }
    }
}
