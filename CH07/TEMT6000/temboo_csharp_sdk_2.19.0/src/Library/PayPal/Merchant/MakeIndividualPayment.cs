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
    /// MakeIndividualPayment
    /// Retrieves the available balance for a PayPal account.
    /// </summary>
    public class MakeIndividualPayment : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the MakeIndividualPayment Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public MakeIndividualPayment(TembooSession session) : base(session, "/Library/PayPal/Merchant/MakeIndividualPayment")
        {
        }

         /// <summary>
         /// (optional, string) The currency code associated with the PaymentAmount. Defaults to "USD".
         /// </summary>
         /// <param name="value">Value of the CurrencyCode input for this Choreo.</param>
         public void setCurrencyCode(String value) {
             base.addInput ("CurrencyCode", value);
         }
         /// <summary>
         /// (required, string) The email address used to identify the recipient of the payment.
         /// </summary>
         /// <param name="value">Value of the EmailAddress input for this Choreo.</param>
         public void setEmailAddress(String value) {
             base.addInput ("EmailAddress", value);
         }
         /// <summary>
         /// (optional, string) The subject line of the email that PayPal sends when the transaction is completed. Character length and limitations: 255 single-byte alphanumeric characters.
         /// </summary>
         /// <param name="value">Value of the EmailSubject input for this Choreo.</param>
         public void setEmailSubject(String value) {
             base.addInput ("EmailSubject", value);
         }
         /// <summary>
         /// (required, password) The API Password provided by PayPal.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (required, decimal) The amount to be paid.
         /// </summary>
         /// <param name="value">Value of the PaymentAmount input for this Choreo.</param>
         public void setPaymentAmount(String value) {
             base.addInput ("PaymentAmount", value);
         }
         /// <summary>
         /// (required, string) The API Signature provided by PayPal.
         /// </summary>
         /// <param name="value">Value of the Signature input for this Choreo.</param>
         public void setSignature(String value) {
             base.addInput ("Signature", value);
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
        /// <returns>A MakeIndividualPaymentResultSet containing execution metadata and results.</returns>
        new public MakeIndividualPaymentResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            MakeIndividualPaymentResultSet results = new JavaScriptSerializer().Deserialize<MakeIndividualPaymentResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the MakeIndividualPayment Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class MakeIndividualPaymentResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Acknowledged" output from this Choreo execution
        /// <returns>String - (string) Indicates the status of the request. Should contain "Sucess" or "Failure".</returns>
        /// </summary>
        public String Acknowledged
        {
            get
            {
                return (String) base.Output["Acknowledged"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "CorrelationId" output from this Choreo execution
        /// <returns>String - (string) A unique id returned by PayPal for this payment.</returns>
        /// </summary>
        public String CorrelationId
        {
            get
            {
                return (String) base.Output["CorrelationId"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "ErrorMessage" output from this Choreo execution
        /// <returns>String - (string) This will contain any error message returned by PayPal during this operation.</returns>
        /// </summary>
        public String ErrorMessage
        {
            get
            {
                return (String) base.Output["ErrorMessage"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Timestamp" output from this Choreo execution
        /// <returns>String - (date) The timestamp associated with the payment request.</returns>
        /// </summary>
        public String Timestamp
        {
            get
            {
                return (String) base.Output["Timestamp"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (string) The full response from PayPal formatted in name/value pairs.</returns>
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
