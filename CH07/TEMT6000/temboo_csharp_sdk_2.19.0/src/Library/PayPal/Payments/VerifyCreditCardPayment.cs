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
    /// VerifyCreditCardPayment
    /// Verifies that a credit card payment from the PayPal REST API has been completed successfully.
    /// </summary>
    public class VerifyCreditCardPayment : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the VerifyCreditCardPayment Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public VerifyCreditCardPayment(TembooSession session) : base(session, "/Library/PayPal/Payments/VerifyCreditCardPayment")
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
         /// (conditional, string) The Client ID provided by PayPal. This is used to authenticate PayPal's REST API.
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (conditional, string) The Client Secret provided by PayPal. This is used to authenticate PayPal's REST API.
         /// </summary>
         /// <param name="value">Value of the ClientSecret input for this Choreo.</param>
         public void setClientSecret(String value) {
             base.addInput ("ClientSecret", value);
         }
         /// <summary>
         /// (conditional, json) The proof of payment received from the client SDK. This can be a proof of payment received from the Adaptive Payment API or the REST API.
         /// </summary>
         /// <param name="value">Value of the ProofOfPayment input for this Choreo.</param>
         public void setProofOfPayment(String value) {
             base.addInput ("ProofOfPayment", value);
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
        /// <returns>A VerifyCreditCardPaymentResultSet containing execution metadata and results.</returns>
        new public VerifyCreditCardPaymentResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            VerifyCreditCardPaymentResultSet results = new JavaScriptSerializer().Deserialize<VerifyCreditCardPaymentResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the VerifyCreditCardPayment Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class VerifyCreditCardPaymentResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "FailureDescription" output from this Choreo execution
        /// <returns>String - (json) When the payment details indicate that the payment status is not complete, this will contain a JSON dictionary of payment status descriptions.</returns>
        /// </summary>
        public String FailureDescription
        {
            get
            {
                return (String) base.Output["FailureDescription"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "VerificationStatus" output from this Choreo execution
        /// <returns>String - (string) The status of the payment verification. This will set to either "verified" or "unverified" depending on the status of the payment details.</returns>
        /// </summary>
        public String VerificationStatus
        {
            get
            {
                return (String) base.Output["VerificationStatus"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from PayPal. This includes the full response from retrieving payment details from the Rest API.</returns>
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
