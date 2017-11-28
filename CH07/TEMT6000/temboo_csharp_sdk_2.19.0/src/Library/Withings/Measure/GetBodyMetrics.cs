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

namespace Temboo.Library.Withings.Measure
{
    /// <summary>
    /// GetBodyMetrics
    /// Retrieves body metrics for the specified user.
    /// </summary>
    public class GetBodyMetrics : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetBodyMetrics Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetBodyMetrics(TembooSession session) : base(session, "/Library/Withings/Measure/GetBodyMetrics")
        {
        }

         /// <summary>
         /// (required, string) The Access Token retrieved during the OAuth process.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (required, string) The Access Token Secret retrieved during the OAuth process.
         /// </summary>
         /// <param name="value">Value of the AccessTokenSecret input for this Choreo.</param>
         public void setAccessTokenSecret(String value) {
             base.addInput ("AccessTokenSecret", value);
         }
         /// <summary>
         /// (optional, integer) Set to 2 to retrieve objectives or to 1 to retrieve actual measurements.
         /// </summary>
         /// <param name="value">Value of the Category input for this Choreo.</param>
         public void setCategory(String value) {
             base.addInput ("Category", value);
         }
         /// <summary>
         /// (required, string) The Consumer Key provided by Withings.
         /// </summary>
         /// <param name="value">Value of the ConsumerKey input for this Choreo.</param>
         public void setConsumerKey(String value) {
             base.addInput ("ConsumerKey", value);
         }
         /// <summary>
         /// (required, string) The Consumer Secret provided by Withings.
         /// </summary>
         /// <param name="value">Value of the ConsumerSecret input for this Choreo.</param>
         public void setConsumerSecret(String value) {
             base.addInput ("ConsumerSecret", value);
         }
         /// <summary>
         /// (optional, integer) Retrieves data for a particular device type. Specifying 1 will retrieve all body scale related measures and 0 will retrieve all user personal data entered at user creation time.
         /// </summary>
         /// <param name="value">Value of the DeviceType input for this Choreo.</param>
         public void setDeviceType(String value) {
             base.addInput ("DeviceType", value);
         }
         /// <summary>
         /// (optional, date) Retrieves results dated before the specified EPOCH formatted date.
         /// </summary>
         /// <param name="value">Value of the EndDate input for this Choreo.</param>
         public void setEndDate(String value) {
             base.addInput ("EndDate", value);
         }
         /// <summary>
         /// (optional, date) Retrieves results added or modified since the specified EPOCH formatted date.
         /// </summary>
         /// <param name="value">Value of the LastUpdated input for this Choreo.</param>
         public void setLastUpdated(String value) {
             base.addInput ("LastUpdated", value);
         }
         /// <summary>
         /// (optional, integer) Limits the number of measure groups returned in the result.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, integer) Filters by the measurement type. Set to 1 to filter by weight or 4 to filter by height.
         /// </summary>
         /// <param name="value">Value of the MeasurementType input for this Choreo.</param>
         public void setMeasurementType(String value) {
             base.addInput ("MeasurementType", value);
         }
         /// <summary>
         /// (optional, integer) Used in combination with the Limit parameter to page through results.
         /// </summary>
         /// <param name="value">Value of the Offset input for this Choreo.</param>
         public void setOffset(String value) {
             base.addInput ("Offset", value);
         }
         /// <summary>
         /// (optional, date) Retrieves results dated after the specified EPOCH formatted date.
         /// </summary>
         /// <param name="value">Value of the StartDate input for this Choreo.</param>
         public void setStartDate(String value) {
             base.addInput ("StartDate", value);
         }
         /// <summary>
         /// (required, string) The ID of the user to retrieve body metrics for.
         /// </summary>
         /// <param name="value">Value of the UserID input for this Choreo.</param>
         public void setUserID(String value) {
             base.addInput ("UserID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetBodyMetricsResultSet containing execution metadata and results.</returns>
        new public GetBodyMetricsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetBodyMetricsResultSet results = new JavaScriptSerializer().Deserialize<GetBodyMetricsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetBodyMetrics Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetBodyMetricsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Withings.</returns>
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
