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

namespace Temboo.Library.Genability.PricingAndCalc
{
    /// <summary>
    /// RunNewPriceCalculation
    /// Calculate electricity costs based on a POSTed calculation criteria. 
    /// </summary>
    public class RunNewPriceCalculation : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RunNewPriceCalculation Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RunNewPriceCalculation(TembooSession session) : base(session, "/Library/Genability/PricingAndCalc/RunNewPriceCalculation")
        {
        }

         /// <summary>
         /// (required, json) The POST payload in JSON format.
         /// </summary>
         /// <param name="value">Value of the POSTData input for this Choreo.</param>
         public void setPOSTData(String value) {
             base.addInput ("POSTData", value);
         }
         /// <summary>
         /// (required, string) The App ID provided by Genability.
         /// </summary>
         /// <param name="value">Value of the AppID input for this Choreo.</param>
         public void setAppID(String value) {
             base.addInput ("AppID", value);
         }
         /// <summary>
         /// (required, string) The App Key provided by Genability.
         /// </summary>
         /// <param name="value">Value of the AppKey input for this Choreo.</param>
         public void setAppKey(String value) {
             base.addInput ("AppKey", value);
         }
         /// <summary>
         /// (required, string) A Genability tariff ID.
         /// </summary>
         /// <param name="value">Value of the MasterTariffID input for this Choreo.</param>
         public void setMasterTariffID(String value) {
             base.addInput ("MasterTariffID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A RunNewPriceCalculationResultSet containing execution metadata and results.</returns>
        new public RunNewPriceCalculationResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RunNewPriceCalculationResultSet results = new JavaScriptSerializer().Deserialize<RunNewPriceCalculationResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RunNewPriceCalculation Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RunNewPriceCalculationResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Genability.</returns>
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
