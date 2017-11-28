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

namespace Temboo.Library.Fitbit.Statistics
{
    /// <summary>
    /// GetIntradayTimeSeries
    /// Returns the intraday time series for a given resource based on a date range you specify.
    /// </summary>
    public class GetIntradayTimeSeries : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetIntradayTimeSeries Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetIntradayTimeSeries(TembooSession session) : base(session, "/Library/Fitbit/Statistics/GetIntradayTimeSeries")
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
         /// (conditional, string) Number of data points to include. for heart rate data, this must be either 1sec or 1min. For other activities, it can be 1min or 15min.
         /// </summary>
         /// <param name="value">Value of the DetailLevel input for this Choreo.</param>
         public void setDetailLevel(String value) {
             base.addInput ("DetailLevel", value);
         }
         /// <summary>
         /// (required, date) The end date of the date range for the data you want to retrieve (in the format yyyy-MM-dd). You can also specify the value '1d'.
         /// </summary>
         /// <param name="value">Value of the EndDate input for this Choreo.</param>
         public void setEndDate(String value) {
             base.addInput ("EndDate", value);
         }
         /// <summary>
         /// (optional, date) The end of the period, in the format HH:mm.
         /// </summary>
         /// <param name="value">Value of the EndTime input for this Choreo.</param>
         public void setEndTime(String value) {
             base.addInput ("EndTime", value);
         }
         /// <summary>
         /// (required, string) The resource path that you want to access (for example: activities/heart). See Choreo documentation for a full list of resource paths.
         /// </summary>
         /// <param name="value">Value of the ResourcePath input for this Choreo.</param>
         public void setResourcePath(String value) {
             base.addInput ("ResourcePath", value);
         }
         /// <summary>
         /// (optional, string) The format that you want the response to be in: xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, date) The start date of the date range for the data you want to retrieve (in the format yyyy-MM-dd). You can also specify the value 'today'.
         /// </summary>
         /// <param name="value">Value of the StartDate input for this Choreo.</param>
         public void setStartDate(String value) {
             base.addInput ("StartDate", value);
         }
         /// <summary>
         /// (optional, date) The start of the period, in the format HH:mm.
         /// </summary>
         /// <param name="value">Value of the StartTime input for this Choreo.</param>
         public void setStartTime(String value) {
             base.addInput ("StartTime", value);
         }
         /// <summary>
         /// (optional, string) The user's encoded id. Defaults to "-" (dash) which will return data for the user associated with the token credentials provided.
         /// </summary>
         /// <param name="value">Value of the UserID input for this Choreo.</param>
         public void setUserID(String value) {
             base.addInput ("UserID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetIntradayTimeSeriesResultSet containing execution metadata and results.</returns>
        new public GetIntradayTimeSeriesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetIntradayTimeSeriesResultSet results = new JavaScriptSerializer().Deserialize<GetIntradayTimeSeriesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetIntradayTimeSeries Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetIntradayTimeSeriesResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Fitbit.</returns>
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
