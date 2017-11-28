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

namespace Temboo.Library.NOAA
{
    /// <summary>
    /// WeatherByZipcode
    /// Retrieve DWML-encoded NDFD data for a specified zipcode (in 50 U.S. States and Puerto Rico).
    /// </summary>
    public class WeatherByZipcode : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the WeatherByZipcode Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public WeatherByZipcode(TembooSession session) : base(session, "/Library/NOAA/WeatherByZipcode")
        {
        }

         /// <summary>
         /// (optional, date) Enter today's date, or some future date in UTC format. Format: 2004-04-27T12:00. Defaults to NOW if not provided.
         /// </summary>
         /// <param name="value">Value of the EndDate input for this Choreo.</param>
         public void setEndDate(String value) {
             base.addInput ("EndDate", value);
         }
         /// <summary>
         /// (optional, string) Enter an additional weather parameter in the following format: phail=phail. Use only if Product is set to: glance.
         /// </summary>
         /// <param name="value">Value of the NDFDParameterName input for this Choreo.</param>
         public void setNDFDParameterName(String value) {
             base.addInput ("NDFDParameterName", value);
         }
         /// <summary>
         /// (required, string) Enter one of two parameters: time-series (to return all data between the Begin and End time parameters); glance for a subset of 5 often used parameters
         /// </summary>
         /// <param name="value">Value of the Product input for this Choreo.</param>
         public void setProduct(String value) {
             base.addInput ("Product", value);
         }
         /// <summary>
         /// (optional, date) Enter the start time for retrieval of NDWD information in UTC format. If null, the earliest date in the database is returned.  Format: 2004-04-27T12:00.
         /// </summary>
         /// <param name="value">Value of the StartDate input for this Choreo.</param>
         public void setStartDate(String value) {
             base.addInput ("StartDate", value);
         }
         /// <summary>
         /// (optional, string) Enter the unit format the data will be displayed in. Default is: e, for Standard English (U.S. Standard).  Or: m, for Metric (SI Units).
         /// </summary>
         /// <param name="value">Value of the Unit input for this Choreo.</param>
         public void setUnit(String value) {
             base.addInput ("Unit", value);
         }
         /// <summary>
         /// (required, integer) Enter the zipcode for which NDFD weather information will be retrieved.
         /// </summary>
         /// <param name="value">Value of the ZipCodeList input for this Choreo.</param>
         public void setZipCodeList(String value) {
             base.addInput ("ZipCodeList", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A WeatherByZipcodeResultSet containing execution metadata and results.</returns>
        new public WeatherByZipcodeResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            WeatherByZipcodeResultSet results = new JavaScriptSerializer().Deserialize<WeatherByZipcodeResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the WeatherByZipcode Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class WeatherByZipcodeResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) Response from NDFD servers.</returns>
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
