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
    /// CalculateTariffInputMetaData
    /// Retrieve inputs required to run a calculation for the specified tariff, within a specified period of time.
    /// </summary>
    public class CalculateTariffInputMetaData : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CalculateTariffInputMetaData Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CalculateTariffInputMetaData(TembooSession session) : base(session, "/Library/Genability/PricingAndCalc/CalculateTariffInputMetaData")
        {
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
         /// (optional, string) Specify whether results retireved should be based on a billing period, or not.  Default is set to: false.
         /// </summary>
         /// <param name="value">Value of the BillingPeriod input for this Choreo.</param>
         public void setBillingPeriod(String value) {
             base.addInput ("BillingPeriod", value);
         }
         /// <summary>
         /// (optional, string) Specify whether electricity pricing information should be restricted to city limits, or not.  Example input value: Inside.
         /// </summary>
         /// <param name="value">Value of the CityLimits input for this Choreo.</param>
         public void setCityLimits(String value) {
             base.addInput ("CityLimits", value);
         }
         /// <summary>
         /// (optional, string) The connection type.  For example: Primary.
         /// </summary>
         /// <param name="value">Value of the ConnectionType input for this Choreo.</param>
         public void setConnectionType(String value) {
             base.addInput ("ConnectionType", value);
         }
         /// <summary>
         /// (required, string) The date and time of the requested start of the price query. Must be in ISO 8601 format.  Example: 2012-06-12T00:00:00.0-0700
         /// </summary>
         /// <param name="value">Value of the FromDateTime input for this Choreo.</param>
         public void setFromDateTime(String value) {
             base.addInput ("FromDateTime", value);
         }
         /// <summary>
         /// (optional, string) Specify how calculation details are displayed.  For example retrieved details can be grouped by month, or year. Options include: Daily, Weekly, Month, Year.
         /// </summary>
         /// <param name="value">Value of the GroupBy input for this Choreo.</param>
         public void setGroupBy(String value) {
             base.addInput ("GroupBy", value);
         }
         /// <summary>
         /// (optional, string) An applicability value.  If an error is returned, indicating the need for an extra applicability parameter, use this variable to set the parameter name.  For example: territoryID.
         /// </summary>
         /// <param name="value">Value of the KeyName input for this Choreo.</param>
         public void setKeyName(String value) {
             base.addInput ("KeyName", value);
         }
         /// <summary>
         /// (conditional, string) The value for the specified KeyName variable. For example if KeyName is set to territoryID, you could provide 3385 for the KeyValue input.
         /// </summary>
         /// <param name="value">Value of the KeyValue input for this Choreo.</param>
         public void setKeyValue(String value) {
             base.addInput ("KeyValue", value);
         }
         /// <summary>
         /// (required, string) A Genability tariff ID.
         /// </summary>
         /// <param name="value">Value of the MasterTariffID input for this Choreo.</param>
         public void setMasterTariffID(String value) {
             base.addInput ("MasterTariffID", value);
         }
         /// <summary>
         /// (required, string) The date and time of the requested start of the price query. Must be in ISO 8601 format.  Example: 2012-06-12T00:00:00.0-0700
         /// </summary>
         /// <param name="value">Value of the ToDateTime input for this Choreo.</param>
         public void setToDateTime(String value) {
             base.addInput ("ToDateTime", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CalculateTariffInputMetaDataResultSet containing execution metadata and results.</returns>
        new public CalculateTariffInputMetaDataResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CalculateTariffInputMetaDataResultSet results = new JavaScriptSerializer().Deserialize<CalculateTariffInputMetaDataResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CalculateTariffInputMetaData Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CalculateTariffInputMetaDataResultSet : Temboo.Core.ResultSet
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
