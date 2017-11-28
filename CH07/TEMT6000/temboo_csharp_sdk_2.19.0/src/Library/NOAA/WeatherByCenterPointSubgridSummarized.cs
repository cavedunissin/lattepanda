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
    /// WeatherByCenterPointSubgridSummarized
    /// Retrieve weather information for a rectangle defined by a center point and distances in the latitudinal and longitudinal directions.
    /// </summary>
    public class WeatherByCenterPointSubgridSummarized : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the WeatherByCenterPointSubgridSummarized Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public WeatherByCenterPointSubgridSummarized(TembooSession session) : base(session, "/Library/NOAA/WeatherByCenterPointSubgridSummarized")
        {
        }

         /// <summary>
         /// (required, decimal) Enter the latitude specifying the rectangle or the grid center that defines the area being queried. North latitude is positive.
         /// </summary>
         /// <param name="value">Value of the CenterPointLatitude input for this Choreo.</param>
         public void setCenterPointLatitude(String value) {
             base.addInput ("CenterPointLatitude", value);
         }
         /// <summary>
         /// (required, decimal) Enter the longitute specifying the rectangle or the grid center that defines the area being queried. West longitude is negative.
         /// </summary>
         /// <param name="value">Value of the CenterPointLongitude input for this Choreo.</param>
         public void setCenterPointLongitude(String value) {
             base.addInput ("CenterPointLongitude", value);
         }
         /// <summary>
         /// (required, string) Specify a timespan for which NDFD data will be summarized. Enter: 24 hourly, for a 24 hour summary, or: 12 hourly, for a 12 hour weather summary.
         /// </summary>
         /// <param name="value">Value of the Format input for this Choreo.</param>
         public void setFormat(String value) {
             base.addInput ("Format", value);
         }
         /// <summary>
         /// (required, decimal) Specify the distance from the center point in the latitudinal direction to the rectangle's East/West oriented sides.
         /// </summary>
         /// <param name="value">Value of the LatitudeDistance input for this Choreo.</param>
         public void setLatitudeDistance(String value) {
             base.addInput ("LatitudeDistance", value);
         }
         /// <summary>
         /// (required, decimal) Specify the distance from the center point in the longitudinal direction to the rectangle's North/South oriented side.
         /// </summary>
         /// <param name="value">Value of the LongitudeDistance input for this Choreo.</param>
         public void setLongitudeDistance(String value) {
             base.addInput ("LongitudeDistance", value);
         }
         /// <summary>
         /// (optional, integer) Specify the number of days to retieve data for. If null, data from the earliest date in the dabase is returned.
         /// </summary>
         /// <param name="value">Value of the NumberOfDays input for this Choreo.</param>
         public void setNumberOfDays(String value) {
             base.addInput ("NumberOfDays", value);
         }
         /// <summary>
         /// (optional, decimal) Enter desired data resolution in kilometers.  Default is 5km.
         /// </summary>
         /// <param name="value">Value of the SquareResolution input for this Choreo.</param>
         public void setSquareResolution(String value) {
             base.addInput ("SquareResolution", value);
         }
         /// <summary>
         /// (required, date) Enter the start time for retrieval of NDWD data in following format: 2004-04-27 If null, the earliest date in the database is returned.
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
        /// <returns>A WeatherByCenterPointSubgridSummarizedResultSet containing execution metadata and results.</returns>
        new public WeatherByCenterPointSubgridSummarizedResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            WeatherByCenterPointSubgridSummarizedResultSet results = new JavaScriptSerializer().Deserialize<WeatherByCenterPointSubgridSummarizedResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the WeatherByCenterPointSubgridSummarized Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class WeatherByCenterPointSubgridSummarizedResultSet : Temboo.Core.ResultSet
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
