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

namespace Temboo.Library.PayPal.AdaptivePayments
{
    /// <summary>
    /// PaymentDetails
    /// Retrieves information about a specific payment.
    /// </summary>
    public class PaymentDetails : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the PaymentDetails Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public PaymentDetails(TembooSession session) : base(session, "/Library/PayPal/AdaptivePayments/PaymentDetails")
        {
        }

         /// <summary>
         /// (required, string) Your PayPal AppID (or the default AppID for the PayPal sandbox).
         /// </summary>
         /// <param name="value">Value of the AppID input for this Choreo.</param>
         public void setAppID(String value) {
             base.addInput ("AppID", value);
         }
         /// <summary>
         /// (required, password) The API Password provided by PayPal.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (conditional, string) The pay key that identifies the payment for which you want to retrieve details. This is the pay key returned in the response of the Pay method.
         /// </summary>
         /// <param name="value">Value of the PayKey input for this Choreo.</param>
         public void setPayKey(String value) {
             base.addInput ("PayKey", value);
         }
         /// <summary>
         /// (required, string) The API Signature provided by PayPal.
         /// </summary>
         /// <param name="value">Value of the Signature input for this Choreo.</param>
         public void setSignature(String value) {
             base.addInput ("Signature", value);
         }
         /// <summary>
         /// (optional, string) The tracking ID that was specified for this payment in the PayRequest message.
         /// </summary>
         /// <param name="value">Value of the TrackingID input for this Choreo.</param>
         public void setTrackingID(String value) {
             base.addInput ("TrackingID", value);
         }
         /// <summary>
         /// (optional, string) The PayPal transaction ID associated with the payment. The Instant Payment Notification message associated with the payment contains the transaction ID.
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
        /// <returns>A PaymentDetailsResultSet containing execution metadata and results.</returns>
        new public PaymentDetailsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            PaymentDetailsResultSet results = new JavaScriptSerializer().Deserialize<PaymentDetailsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the PaymentDetails Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class PaymentDetailsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "AccountID" output from this Choreo execution
        /// <returns>String - (string) The account id of the payment reciever.</returns>
        /// </summary>
        public String AccountID
        {
            get
            {
                return (String) base.Output["AccountID"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Amount" output from this Choreo execution
        /// <returns>String - (decimal) The payment amount.</returns>
        /// </summary>
        public String Amount
        {
            get
            {
                return (String) base.Output["Amount"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "CurrencyCode" output from this Choreo execution
        /// <returns>String - (string) The currency code for the payment.</returns>
        /// </summary>
        public String CurrencyCode
        {
            get
            {
                return (String) base.Output["CurrencyCode"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Email" output from this Choreo execution
        /// <returns>String - (string) The receiver email address.</returns>
        /// </summary>
        public String Email
        {
            get
            {
                return (String) base.Output["Email"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Status" output from this Choreo execution
        /// <returns>String - (string) The status of the payment.</returns>
        /// </summary>
        public String Status
        {
            get
            {
                return (String) base.Output["Status"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "TransactionStatus" output from this Choreo execution
        /// <returns>String - (string) The transaction status of the payment.</returns>
        /// </summary>
        public String TransactionStatus
        {
            get
            {
                return (String) base.Output["TransactionStatus"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from PayPal.</returns>
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
