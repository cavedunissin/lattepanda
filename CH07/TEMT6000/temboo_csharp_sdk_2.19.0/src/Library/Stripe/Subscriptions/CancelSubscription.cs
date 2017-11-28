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
    /// CancelSubscription
    /// Cancels an existing subscription.
    /// </summary>
    public class CancelSubscription : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CancelSubscription Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CancelSubscription(TembooSession session) : base(session, "/Library/Stripe/Subscriptions/CancelSubscription")
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
         /// (optional, boolean) Delays the cancellation of the subscription until the end of the current period when set to 1. Defaults to 0.
         /// </summary>
         /// <param name="value">Value of the AtPeriodEnd input for this Choreo.</param>
         public void setAtPeriodEnd(String value) {
             base.addInput ("AtPeriodEnd", value);
         }
         /// <summary>
         /// (required, string) The id of the customer whose subscription you want to cancel
         /// </summary>
         /// <param name="value">Value of the CustomerID input for this Choreo.</param>
         public void setCustomerID(String value) {
             base.addInput ("CustomerID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CancelSubscriptionResultSet containing execution metadata and results.</returns>
        new public CancelSubscriptionResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CancelSubscriptionResultSet results = new JavaScriptSerializer().Deserialize<CancelSubscriptionResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CancelSubscription Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CancelSubscriptionResultSet : Temboo.Core.ResultSet
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
