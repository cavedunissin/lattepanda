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

namespace Temboo.Library.PayPal.Merchant
{
    /// <summary>
    /// RefundTransaction
    /// Issue a refund to a PayPal buyer by specifying a transaction ID.
    /// </summary>
    public class RefundTransaction : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RefundTransaction Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RefundTransaction(TembooSession session) : base(session, "/Library/PayPal/Merchant/RefundTransaction")
        {
        }

         /// <summary>
         /// (optional, decimal) Refund amount. Amount is required if RefundType is set to Partial. If RefundType is set to Full, leave input blank.
         /// </summary>
         /// <param name="value">Value of the Amount input for this Choreo.</param>
         public void setAmount(String value) {
             base.addInput ("Amount", value);
         }
         /// <summary>
         /// (optional, string) A three-character currency code (i.e. USD). Required for partial refunds. Leave this field blank for full refunds. Defaults to USD.
         /// </summary>
         /// <param name="value">Value of the CurrencyCode input for this Choreo.</param>
         public void setCurrencyCode(String value) {
             base.addInput ("CurrencyCode", value);
         }
         /// <summary>
         /// (optional, string) Your own invoice or tracking number. Character length limitation is 127 alphanumeric characters.
         /// </summary>
         /// <param name="value">Value of the InvoiceID input for this Choreo.</param>
         public void setInvoiceID(String value) {
             base.addInput ("InvoiceID", value);
         }
         /// <summary>
         /// (optional, string) Custom note about the refund. Character length limitation is 255 alphanumeric characters.
         /// </summary>
         /// <param name="value">Value of the Note input for this Choreo.</param>
         public void setNote(String value) {
             base.addInput ("Note", value);
         }
         /// <summary>
         /// (required, password) The API Password provided by PayPal.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (required, string) The refund type must be set to Full or Partial.  This flag effects what values some other input variables should have. Defaults to Full.
         /// </summary>
         /// <param name="value">Value of the RefundType input for this Choreo.</param>
         public void setRefundType(String value) {
             base.addInput ("RefundType", value);
         }
         /// <summary>
         /// (required, string) The API Signature provided by PayPal.
         /// </summary>
         /// <param name="value">Value of the Signature input for this Choreo.</param>
         public void setSignature(String value) {
             base.addInput ("Signature", value);
         }
         /// <summary>
         /// (required, string) The ID for the transaction you want to retrieve data for.
         /// </summary>
         /// <param name="value">Value of the TransactionID input for this Choreo.</param>
         public void setTransactionID(String value) {
             base.addInput ("TransactionID", value);
         }
         /// <summary>
         /// (conditional, boolean) Set to 1 to indicate that you're testing against the PayPal sandbox instead of production. Set to 0 (the default) when moving to production.
         /// </summary>
         /// <param name="value">Value of the UseSandbox input for this Choreo.</param>
         public void setUseSandbox(String value) {
             base.addInput ("UseSandbox", value);
         }
         /// <summary>
         /// (required, string) The API Username provided by PayPal.
         /// </summary>
         /// <param name="value">Value of the Username input for this Choreo.</param>
         public void setUsername(String value) {
             base.addInput ("Username", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RefundTransactionResultSet containing execution metadata and results.</returns>
        new public RefundTransactionResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RefundTransactionResultSet results = new JavaScriptSerializer().Deserialize<RefundTransactionResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RefundTransaction Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RefundTransactionResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (string) Response from PayPal formatted in name/value pairs.</returns>
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
