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
    /// GetTariffPrice
    /// Retrieve summarized rates of a specified electricity tariff, in addition to changes in rates over a specified time span.
    /// </summary>
    public class GetTariffPrice : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetTariffPrice Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetTariffPrice(TembooSession session) : base(session, "/Library/Genability/PricingAndCalc/GetTariffPrice")
        {
        }

         /// <summary>
         /// (optional, string) The Genability ID for an account. This is optional if MasterTariffID is set.
         /// </summary>
         /// <param name="value">Value of the AccountID input for this Choreo.</param>
         public void setAccountID(String value) {
             base.addInput ("AccountID", value);
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
         /// (optional, decimal) Specify a monthly consumption in kWh. By default the highest banded level of consumption is used.
         /// </summary>
         /// <param name="value">Value of the ConsumptionAmount input for this Choreo.</param>
         public void setConsumptionAmount(String value) {
             base.addInput ("ConsumptionAmount", value);
         }
         /// <summary>
         /// (optional, decimal) Specify a monthly demand in kWh. By default the highest banded level of demand is used.
         /// </summary>
         /// <param name="value">Value of the DemandAmount input for this Choreo.</param>
         public void setDemandAmount(String value) {
             base.addInput ("DemandAmount", value);
         }
         /// <summary>
         /// (required, string) The date and time of the requested start of the price query. Must be in ISO 8601 format.  Example: 2012-06-12T00:00:00.0-0700
         /// </summary>
         /// <param name="value">Value of the FromDateTime input for this Choreo.</param>
         public void setFromDateTime(String value) {
             base.addInput ("FromDateTime", value);
         }
         /// <summary>
         /// (optional, string) A Genability tariff ID. This variable is not required, if AccountID is set.
         /// </summary>
         /// <param name="value">Value of the MasterTariffID input for this Choreo.</param>
         public void setMasterTariffID(String value) {
             base.addInput ("MasterTariffID", value);
         }
         /// <summary>
         /// (optional, integer) The number of results to be returned. Defailt is set to: 25.
         /// </summary>
         /// <param name="value">Value of the PageCount input for this Choreo.</param>
         public void setPageCount(String value) {
             base.addInput ("PageCount", value);
         }
         /// <summary>
         /// (optional, integer) The page number to start to display results from. If unspecified, the first page of results will be returned.
         /// </summary>
         /// <param name="value">Value of the PageStart input for this Choreo.</param>
         public void setPageStart(String value) {
             base.addInput ("PageStart", value);
         }
         /// <summary>
         /// (optional, string) Return rate changes for the specified Territory.
         /// </summary>
         /// <param name="value">Value of the TerritoryID input for this Choreo.</param>
         public void setTerritoryID(String value) {
             base.addInput ("TerritoryID", value);
         }
         /// <summary>
         /// (optional, string) The date and time of the requested start of the price query. Must be in ISO 8601 format.  Example: 2012-06-12T00:00:00.0-0700
         /// </summary>
         /// <param name="value">Value of the ToDateTime input for this Choreo.</param>
         public void setToDateTime(String value) {
             base.addInput ("ToDateTime", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetTariffPriceResultSet containing execution metadata and results.</returns>
        new public GetTariffPriceResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetTariffPriceResultSet results = new JavaScriptSerializer().Deserialize<GetTariffPriceResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetTariffPrice Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetTariffPriceResultSet : Temboo.Core.ResultSet
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
