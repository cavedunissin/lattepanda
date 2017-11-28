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

namespace Temboo.Library.Stripe.Subscriptions
{
    /// <summary>
    /// UpdateSubscription
    /// Subscribes a customer to a specified plan.
    /// </summary>
    public class UpdateSubscription : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateSubscription Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateSubscription(TembooSession session) : base(session, "/Library/Stripe/Subscriptions/UpdateSubscription")
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
         /// (optional, string) If you provide a coupon code, it can be specified here
         /// </summary>
         /// <param name="value">Value of the Coupon input for this Choreo.</param>
         public void setCoupon(String value) {
             base.addInput ("Coupon", value);
         }
         /// <summary>
         /// (required, string) The unique identifier of the customer you want to subscribe to a plan
         /// </summary>
         /// <param name="value">Value of the CustomerID input for this Choreo.</param>
         public void setCustomerID(String value) {
             base.addInput ("CustomerID", value);
         }
         /// <summary>
         /// (optional, json) A JSON object used to attach key-value data to this Stripe object.
         /// </summary>
         /// <param name="value">Value of the Metadata input for this Choreo.</param>
         public void setMetadata(String value) {
             base.addInput ("Metadata", value);
         }
         /// <summary>
         /// (required, string) The unique identifier of the plan to subscribe the customer to
         /// </summary>
         /// <param name="value">Value of the Plan input for this Choreo.</param>
         public void setPlan(String value) {
             base.addInput ("Plan", value);
         }
         /// <summary>
         /// (optional, boolean) When set to 1, Stripe will prorate switching plans during a billing cycle. When set to 0, this feature is disabled. Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the Prorate input for this Choreo.</param>
         public void setProrate(String value) {
             base.addInput ("Prorate", value);
         }
         /// <summary>
         /// (optional, string) The token associated with a set of credit card details.
         /// </summary>
         /// <param name="value">Value of the Token input for this Choreo.</param>
         public void setToken(String value) {
             base.addInput ("Token", value);
         }
         /// <summary>
         /// (optional, date) A timestamp representing the end of the trial period in UTC. The customer will not be charged during the trial period.
         /// </summary>
         /// <param name="value">Value of the TrialEnd input for this Choreo.</param>
         public void setTrialEnd(String value) {
             base.addInput ("TrialEnd", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UpdateSubscriptionResultSet containing execution metadata and results.</returns>
        new public UpdateSubscriptionResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateSubscriptionResultSet results = new JavaScriptSerializer().Deserialize<UpdateSubscriptionResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateSubscription Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateSubscriptionResultSet : Temboo.Core.ResultSet
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
