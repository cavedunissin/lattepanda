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

namespace Temboo.Library.Stripe.Plans
{
    /// <summary>
    /// CreatePlan
    /// Creates a subscription plan
    /// </summary>
    public class CreatePlan : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreatePlan Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreatePlan(TembooSession session) : base(session, "/Library/Stripe/Plans/CreatePlan")
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
         /// (required, integer) The amount in cents to charge on a recurring basis for subscribers of this plan
         /// </summary>
         /// <param name="value">Value of the Amount input for this Choreo.</param>
         public void setAmount(String value) {
             base.addInput ("Amount", value);
         }
         /// <summary>
         /// (optional, string) 3-letter ISO code for currency. Defaults to 'usd' which is currently the only supported currency.
         /// </summary>
         /// <param name="value">Value of the Currency input for this Choreo.</param>
         public void setCurrency(String value) {
             base.addInput ("Currency", value);
         }
         /// <summary>
         /// (required, string) Indicates billing frequency. Valid values are: month or year.
         /// </summary>
         /// <param name="value">Value of the Interval input for this Choreo.</param>
         public void setInterval(String value) {
             base.addInput ("Interval", value);
         }
         /// <summary>
         /// (required, string) The unique identifier of the plan you want to create
         /// </summary>
         /// <param name="value">Value of the PlanID input for this Choreo.</param>
         public void setPlanID(String value) {
             base.addInput ("PlanID", value);
         }
         /// <summary>
         /// (required, string) The name of the plan which will be displayed in the Stripe web interface.
         /// </summary>
         /// <param name="value">Value of the PlanName input for this Choreo.</param>
         public void setPlanName(String value) {
             base.addInput ("PlanName", value);
         }
         /// <summary>
         /// (optional, integer) The number of days in a trial period (customer will not be billed until the trial period is over)
         /// </summary>
         /// <param name="value">Value of the TrialPeriodDays input for this Choreo.</param>
         public void setTrialPeriodDays(String value) {
             base.addInput ("TrialPeriodDays", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CreatePlanResultSet containing execution metadata and results.</returns>
        new public CreatePlanResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreatePlanResultSet results = new JavaScriptSerializer().Deserialize<CreatePlanResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreatePlan Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreatePlanResultSet : Temboo.Core.ResultSet
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
