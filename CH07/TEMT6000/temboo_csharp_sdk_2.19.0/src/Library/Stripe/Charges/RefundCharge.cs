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

namespace Temboo.Library.Stripe.Charges
{
    /// <summary>
    /// RefundCharge
    /// Issues a refund of an existing credit card charge.
    /// </summary>
    public class RefundCharge : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RefundCharge Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RefundCharge(TembooSession session) : base(session, "/Library/Stripe/Charges/RefundCharge")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by Stripe
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, integer) The amount to refund to the customer in cents. When left empty, the entire charge is refunded.
         /// </summary>
         /// <param name="value">Value of the Amount input for this Choreo.</param>
         public void setAmount(String value) {
             base.addInput ("Amount", value);
         }
         /// <summary>
         /// (required, string) The unique identifier of the charge to be refunded
         /// </summary>
         /// <param name="value">Value of the ChargeID input for this Choreo.</param>
         public void setChargeID(String value) {
             base.addInput ("ChargeID", value);
         }
         /// <summary>
         /// (optional, json) A JSON object used to attach key-value data to this Stripe object.
         /// </summary>
         /// <param name="value">Value of the Metadata input for this Choreo.</param>
         public void setMetadata(String value) {
             base.addInput ("Metadata", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RefundChargeResultSet containing execution metadata and results.</returns>
        new public RefundChargeResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RefundChargeResultSet results = new JavaScriptSerializer().Deserialize<RefundChargeResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RefundCharge Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RefundChargeResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Stripe</returns>
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
