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

namespace Temboo.Library.Yahoo.Weather
{
    /// <summary>
    /// GetTemperature
    /// Retrieves the current temperature from Yahoo Weather for the specified location.
    /// </summary>
    public class GetTemperature : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetTemperature Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetTemperature(TembooSession session) : base(session, "/Library/Yahoo/Weather/GetTemperature")
        {
        }

         /// <summary>
         /// (required, string) The address to be searched.
         /// </summary>
         /// <param name="value">Value of the Address input for this Choreo.</param>
         public void setAddress(String value) {
             base.addInput ("Address", value);
         }
         /// <summary>
         /// (optional, string) The unit of temperature in the response. Acceptable inputs: f for Fahrenheit or c for Celsius. Defaults to f. When c is specified, all units measurements returned are changed to metric.
         /// </summary>
         /// <param name="value">Value of the Units input for this Choreo.</param>
         public void setUnits(String value) {
             base.addInput ("Units", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetTemperatureResultSet containing execution metadata and results.</returns>
        new public GetTemperatureResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetTemperatureResultSet results = new JavaScriptSerializer().Deserialize<GetTemperatureResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetTemperature Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetTemperatureResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Temperature" output from this Choreo execution
        /// <returns>String - (integer) The current temperature (defaults to Fahrenheit).</returns>
        /// </summary>
        public String Temperature
        {
            get
            {
                return (String) base.Output["Temperature"];
            }
        }
    }
}
