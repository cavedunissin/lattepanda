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

namespace Temboo.Library.PayPal.Payments
{
    /// <summary>
    /// AcceptPayPalPayment
    /// Creates a new PayPal payment which can then be approved and executed.
    /// </summary>
    public class AcceptPayPalPayment : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the AcceptPayPalPayment Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public AcceptPayPalPayment(TembooSession session) : base(session, "/Library/PayPal/Payments/AcceptPayPalPayment")
        {
        }

         /// <summary>
         /// (optional, string) A valid access token retrieved from PayPal. Required unless providing the ClientID and ClientSecret which can be used to generate a new access token.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (required, string) URL to which the customer is returned if they do not approve the use of PayPal to pay you.
         /// </summary>
         /// <param name="value">Value of the CancelURL input for this Choreo.</param>
         public void setCancelURL(String value) {
             base.addInput ("CancelURL", value);
         }
         /// <summary>
         /// (conditional, string) The Client ID provided by PayPal. Required unless a valid Access Token is provided.
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (conditional, string) The Client Secret provided by PayPal. Required unless a valid Access Token is provided.
         /// </summary>
         /// <param name="value">Value of the ClientSecret input for this Choreo.</param>
         public void setClientSecret(String value) {
             base.addInput ("ClientSecret", value);
         }
         /// <summary>
         /// (required, string) The currency for the payment (i.e.  USD).
         /// </summary>
         /// <param name="value">Value of the Currency input for this Choreo.</param>
         public void setCurrency(String value) {
             base.addInput ("Currency", value);
         }
         /// <summary>
         /// (optional, string) A description for this payment.
         /// </summary>
         /// <param name="value">Value of the Description input for this Choreo.</param>
         public void setDescription(String value) {
             base.addInput ("Description", value);
         }
         /// <summary>
         /// (required, string) The URL to which the customer's browser is returned after choosing to pay with PayPal.
         /// </summary>
         /// <param name="value">Value of the ReturnURL input for this Choreo.</param>
         public void setReturnURL(String value) {
             base.addInput ("ReturnURL", value);
         }
         /// <summary>
         /// (optional, string) A space delimited list of resource URL endpoints that the token should have access for. This is only used when providing the ClientID and Client Secret in order to generate a new access token.
         /// </summary>
         /// <param name="value">Value of the Scope input for this Choreo.</param>
         public void setScope(String value) {
             base.addInput ("Scope", value);
         }
         /// <summary>
         /// (required, decimal) The total of the payment.
         /// </summary>
         /// <param name="value">Value of the Total input for this Choreo.</param>
         public void setTotal(String value) {
             base.addInput ("Total", value);
         }
         /// <summary>
         /// (conditional, boolean) Set to 1 to indicate that you're testing against the PayPal sandbox instead of production. Set to 0 (the default) when moving to production.
         /// </summary>
         /// <param name="value">Value of the UseSandbox input for this Choreo.</param>
         public void setUseSandbox(String value) {
             base.addInput ("UseSandbox", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A AcceptPayPalPaymentResultSet containing execution metadata and results.</returns>
        new public AcceptPayPalPaymentResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            AcceptPayPalPaymentResultSet results = new JavaScriptSerializer().Deserialize<AcceptPayPalPaymentResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the AcceptPayPalPayment Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class AcceptPayPalPaymentResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "ApprovalURL" output from this Choreo execution
        /// <returns>String - (string) The approval url that the application should redirect the user to in order to approve the payment.</returns>
        /// </summary>
        public String ApprovalURL
        {
            get
            {
                return (String) base.Output["ApprovalURL"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "NewAccessToken" output from this Choreo execution
        /// <returns>String - (string) The new access token retrieved from PayPal when providing the Client ID and Client Secret.</returns>
        /// </summary>
        public String NewAccessToken
        {
            get
            {
                return (String) base.Output["NewAccessToken"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "PaymentID" output from this Choreo execution
        /// <returns>String - (string) The id of the payment that was created. This is used to execute the payment after the buyer has approved.</returns>
        /// </summary>
        public String PaymentID
        {
            get
            {
                return (String) base.Output["PaymentID"];
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
