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
    /// GetWeatherByAddress
    /// Retrieves the Yahoo Weather RSS Feed for any specified location by address.
    /// </summary>
    public class GetWeatherByAddress : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetWeatherByAddress Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetWeatherByAddress(TembooSession session) : base(session, "/Library/Yahoo/Weather/GetWeatherByAddress")
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
         /// (optional, string) Deprecated (retained for backward compatibility only).
         /// </summary>
         /// <param name="value">Value of the AppID input for this Choreo.</param>
         public void setAppID(String value) {
             base.addInput ("AppID", value);
         }
         /// <summary>
         /// (optional, integer) An index in the range 1 to 5 that corresponds to the forecast day you want to retrieve. Today corresponds to 1, tomorrow corresponds to 2, and so on. Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the Day input for this Choreo.</param>
         public void setDay(String value) {
             base.addInput ("Day", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: xml (the default) and json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
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
        /// <returns>A GetWeatherByAddressResultSet containing execution metadata and results.</returns>
        new public GetWeatherByAddressResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetWeatherByAddressResultSet results = new JavaScriptSerializer().Deserialize<GetWeatherByAddressResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetWeatherByAddress Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetWeatherByAddressResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "ConditionCode" output from this Choreo execution
        /// <returns>String - (integer) A code representing the current condition.</returns>
        /// </summary>
        public String ConditionCode
        {
            get
            {
                return (String) base.Output["ConditionCode"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "ConditionText" output from this Choreo execution
        /// <returns>String - (string) The textual description for the current condition.</returns>
        /// </summary>
        public String ConditionText
        {
            get
            {
                return (String) base.Output["ConditionText"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "ForecastCode" output from this Choreo execution
        /// <returns>String - (integer) A code representing the forecast condition.</returns>
        /// </summary>
        public String ForecastCode
        {
            get
            {
                return (String) base.Output["ForecastCode"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "ForecastText" output from this Choreo execution
        /// <returns>String - (string) The textual description for the specified day's forecast condition.</returns>
        /// </summary>
        public String ForecastText
        {
            get
            {
                return (String) base.Output["ForecastText"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "High" output from this Choreo execution
        /// <returns>String - (integer) The high temperature forecast for the specified day.</returns>
        /// </summary>
        public String High
        {
            get
            {
                return (String) base.Output["High"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Humidity" output from this Choreo execution
        /// <returns>String - (decimal) The current measurement for atmospheric humidity.</returns>
        /// </summary>
        public String Humidity
        {
            get
            {
                return (String) base.Output["Humidity"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Low" output from this Choreo execution
        /// <returns>String - (integer) The low temperature forecast for the specified day.</returns>
        /// </summary>
        public String Low
        {
            get
            {
                return (String) base.Output["Low"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Pressure" output from this Choreo execution
        /// <returns>String - (decimal) The current measurement for atmospheric pressure.</returns>
        /// </summary>
        public String Pressure
        {
            get
            {
                return (String) base.Output["Pressure"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Temperature" output from this Choreo execution
        /// <returns>String - (integer) The current temperature.</returns>
        /// </summary>
        public String Temperature
        {
            get
            {
                return (String) base.Output["Temperature"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Visibility" output from this Choreo execution
        /// <returns>String - (decimal) The current measurement for visibility.</returns>
        /// </summary>
        public String Visibility
        {
            get
            {
                return (String) base.Output["Visibility"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "WOEID" output from this Choreo execution
        /// <returns>String - (integer) The unique Where On Earth ID of the location.</returns>
        /// </summary>
        public String WOEID
        {
            get
            {
                return (String) base.Output["WOEID"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Yahoo Weather.</returns>
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
