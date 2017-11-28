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
    /// VerifyAllPayments
    /// Verifies that a payment has been successfully completed.
    /// </summary>
    public class VerifyAllPayments : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the VerifyAllPayments Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public VerifyAllPayments(TembooSession session) : base(session, "/Library/PayPal/Payments/VerifyAllPayments")
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
         /// (conditional, string) Your PayPal AppID (or the default AppID for the PayPal sandbox: APP-80W284485P519543T). This is used to authenticate PayPal's Adaptive Payments API.
         /// </summary>
         /// <param name="value">Value of the AppID input for this Choreo.</param>
         public void setAppID(String value) {
             base.addInput ("AppID", value);
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
         /// (conditional, string) The API Password provided by PayPal. This is used to authenticate PayPal's Adaptive Payments API.
         /// </summary>
         /// <param name="value">Value of the Password input for this Choreo.</param>
         public void setPassword(String value) {
             base.addInput ("Password", value);
         }
         /// <summary>
         /// (required, json) The proof of payment received from the client SDK. This can be a proof of payment received from the Adaptive Payment API or the REST API.
         /// </summary>
         /// <param name="value">Value of the ProofOfPayment input for this Choreo.</param>
         public void setProofOfPayment(String value) {
             base.addInput ("ProofOfPayment", value);
         }
         /// <summary>
         /// (conditional, string) The API Signature provided by PayPal. This is used to authenticate PayPal's Adaptive Payments API.
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
         /// (conditional, string) The API Username provided by PayPal. This is used to authenticate PayPal's Adaptive Payments API.
         /// </summary>
         /// <param name="value">Value of the Username input for this Choreo.</param>
         public void setUsername(String value) {
             base.addInput ("Username", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A VerifyAllPaymentsResultSet containing execution metadata and results.</returns>
        new public VerifyAllPaymentsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            VerifyAllPaymentsResultSet results = new JavaScriptSerializer().Deserialize<VerifyAllPaymentsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the VerifyAllPayments Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class VerifyAllPaymentsResultSet : Temboo.Core.ResultSet
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
        /// <returns>String - (json) The response from PayPal. This includes the full response from retrieving payment details from either the AdaptivePayments API or the Rest API.</returns>
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
