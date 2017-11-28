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
    /// WeatherForSinglePointSummarized
    /// Retrieve weather information for a single point defined by latitude and longitude coordinates.
    /// </summary>
    public class WeatherForSinglePointSummarized : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the WeatherForSinglePointSummarized Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public WeatherForSinglePointSummarized(TembooSession session) : base(session, "/Library/NOAA/WeatherForSinglePointSummarized")
        {
        }

         /// <summary>
         /// (required, string) Specify a timespan for which NDFD data will be summarized. Enter: 24 hourly, for a 24 hour summary, or: 12 hourly, for a 12 hour weather summary.
         /// </summary>
         /// <param name="value">Value of the Format input for this Choreo.</param>
         public void setFormat(String value) {
             base.addInput ("Format", value);
         }
         /// <summary>
         /// (required, decimal) Enter the latitude coordinates of the point for which weather data is requested. North latitude is positive.
         /// </summary>
         /// <param name="value">Value of the Latitude input for this Choreo.</param>
         public void setLatitude(String value) {
             base.addInput ("Latitude", value);
         }
         /// <summary>
         /// (required, decimal) Enter the longitude coordinate of the point for which weather data is requested. West longitude is negative.
         /// </summary>
         /// <param name="value">Value of the Longitude input for this Choreo.</param>
         public void setLongitude(String value) {
             base.addInput ("Longitude", value);
         }
         /// <summary>
         /// (optional, integer) Specify the number of days to retieve data for. If null, data from the earliest date in the dabase is returned.
         /// </summary>
         /// <param name="value">Value of the NumberOfDays input for this Choreo.</param>
         public void setNumberOfDays(String value) {
             base.addInput ("NumberOfDays", value);
         }
         /// <summary>
         /// (optional, date) Enter the start time for retrieval of NDWD information in UTC format. If null, the earliest date in the database is returned. Format: 2004-04-27T12:00.
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
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A WeatherForSinglePointSummarizedResultSet containing execution metadata and results.</returns>
        new public WeatherForSinglePointSummarizedResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            WeatherForSinglePointSummarizedResultSet results = new JavaScriptSerializer().Deserialize<WeatherForSinglePointSummarizedResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the WeatherForSinglePointSummarized Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class WeatherForSinglePointSummarizedResultSet : Temboo.Core.ResultSet
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
