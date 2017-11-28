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
    /// WeatherForPointsOnLineSummarized
    /// Retrieve weather information for all points on a line defined by a set of latitude and longitude coordinates.
    /// </summary>
    public class WeatherForPointsOnLineSummarized : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the WeatherForPointsOnLineSummarized Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public WeatherForPointsOnLineSummarized(TembooSession session) : base(session, "/Library/NOAA/WeatherForPointsOnLineSummarized")
        {
        }

         /// <summary>
         /// (required, decimal) Enter the latitude of the first endpoint of the line for which weather data is requested. North latitude is positive.
         /// </summary>
         /// <param name="value">Value of the Endpoint1Latitude input for this Choreo.</param>
         public void setEndpoint1Latitude(String value) {
             base.addInput ("Endpoint1Latitude", value);
         }
         /// <summary>
         /// (required, decimal) Enter the longitude of the first endpoint of the line for which weather data is requested. West longitude is negative.
         /// </summary>
         /// <param name="value">Value of the Endpoint1Longitude input for this Choreo.</param>
         public void setEndpoint1Longitude(String value) {
             base.addInput ("Endpoint1Longitude", value);
         }
         /// <summary>
         /// (required, decimal) Enter the latitude of the second endpoint of the line for which weather data is requested. North latitude is positive.
         /// </summary>
         /// <param name="value">Value of the Endpoint2Latitude input for this Choreo.</param>
         public void setEndpoint2Latitude(String value) {
             base.addInput ("Endpoint2Latitude", value);
         }
         /// <summary>
         /// (required, decimal) Enter the longitude of the second endpoint of the line for which weather data is requested. West longitude is negative.
         /// </summary>
         /// <param name="value">Value of the Endpoint2Longitude input for this Choreo.</param>
         public void setEndpoint2Longitude(String value) {
             base.addInput ("Endpoint2Longitude", value);
         }
         /// <summary>
         /// (required, string) Specify a timespan for which NDFD data will be summarized. Enter: 24 hourly, for a 24 hour summary, or: 12 hourly, for a 12 hour weather summary.
         /// </summary>
         /// <param name="value">Value of the Format input for this Choreo.</param>
         public void setFormat(String value) {
             base.addInput ("Format", value);
         }
         /// <summary>
         /// (optional, integer) The number of days to retrieve data from.  If left blank, defaults to 7 days.
         /// </summary>
         /// <param name="value">Value of the NumberOfDays input for this Choreo.</param>
         public void setNumberOfDays(String value) {
             base.addInput ("NumberOfDays", value);
         }
         /// <summary>
         /// (optional, date) The start date for retrieval of NDFD information in UTC format (2004-04-27) . If blank, the earliest date in the database is returned. Currently the NDFD may be only logging 1 day of data.
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
        /// <returns>A WeatherForPointsOnLineSummarizedResultSet containing execution metadata and results.</returns>
        new public WeatherForPointsOnLineSummarizedResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            WeatherForPointsOnLineSummarizedResultSet results = new JavaScriptSerializer().Deserialize<WeatherForPointsOnLineSummarizedResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the WeatherForPointsOnLineSummarized Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class WeatherForPointsOnLineSummarizedResultSet : Temboo.Core.ResultSet
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
