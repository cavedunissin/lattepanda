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
    /// GetLatestPayment
    /// Retrieves the latest payment.
    /// </summary>
    public class GetLatestPayment : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetLatestPayment Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetLatestPayment(TembooSession session) : base(session, "/Library/PayPal/Payments/GetLatestPayment")
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
         /// (optional, string) A space delimited list of resource URL endpoints that the token should have access for. This is only used when providing the ClientID and Client Secret in order to generate a new access token.
         /// </summary>
         /// <param name="value">Value of the Scope input for this Choreo.</param>
         public void setScope(String value) {
             base.addInput ("Scope", value);
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
        /// <returns>A GetLatestPaymentResultSet containing execution metadata and results.</returns>
        new public GetLatestPaymentResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetLatestPaymentResultSet results = new JavaScriptSerializer().Deserialize<GetLatestPaymentResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetLatestPayment Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetLatestPaymentResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Amount" output from this Choreo execution
        /// <returns>String - (decimal) The amount of the latest payment.</returns>
        /// </summary>
        public String Amount
        {
            get
            {
                return (String) base.Output["Amount"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "CreateTime" output from this Choreo execution
        /// <returns>String - (date) The date that the payment was created.</returns>
        /// </summary>
        public String CreateTime
        {
            get
            {
                return (String) base.Output["CreateTime"];
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
        /// <returns>String - (string) The payment ID.</returns>
        /// </summary>
        public String PaymentID
        {
            get
            {
                return (String) base.Output["PaymentID"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "State" output from this Choreo execution
        /// <returns>String - (string) The payment state.</returns>
        /// </summary>
        public String State
        {
            get
            {
                return (String) base.Output["State"];
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
