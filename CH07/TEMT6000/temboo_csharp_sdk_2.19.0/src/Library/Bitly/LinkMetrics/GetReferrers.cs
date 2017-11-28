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

namespace Temboo.Library.Bitly.LinkMetrics
{
    /// <summary>
    /// GetReferrers
    /// Returns metrics about the pages referring click traffic to a single Bitly link.
    /// </summary>
    public class GetReferrers : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetReferrers Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetReferrers(TembooSession session) : base(session, "/Library/Bitly/LinkMetrics/GetReferrers")
        {
        }

         /// <summary>
         /// (required, string) The OAuth access token provided by Bitly.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (optional, integer) The result limit. Defaults to 100. Range is 1 to 1000.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (required, string) A Bitly link.
         /// </summary>
         /// <param name="value">Value of the Link input for this Choreo.</param>
         public void setLink(String value) {
             base.addInput ("Link", value);
         }
         /// <summary>
         /// (optional, string) The format that you want the response to be in. Accepted values are "json" or "xml". Defaults to "json".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, boolean) Accepted values are true or false. When set to true, this returns data for multiple units rolled up to a single result instead of a separate value for each period of time.
         /// </summary>
         /// <param name="value">Value of the Rollup input for this Choreo.</param>
         public void setRollup(String value) {
             base.addInput ("Rollup", value);
         }
         /// <summary>
         /// (optional, date) An epoch timestamp, indicating the most recent time for which to pull metrics.
         /// </summary>
         /// <param name="value">Value of the Timestamp input for this Choreo.</param>
         public void setTimestamp(String value) {
             base.addInput ("Timestamp", value);
         }
         /// <summary>
         /// (optional, string) An integer hour offset from UTC (-12..12), or a timezone string. Defaults to "America/New_York".
         /// </summary>
         /// <param name="value">Value of the Timezone input for this Choreo.</param>
         public void setTimezone(String value) {
             base.addInput ("Timezone", value);
         }
         /// <summary>
         /// (optional, string) The unit of time that corresponds to query you want to run. Accepted values are: minute, hour, day, week, month, and day. Defaults to "day".
         /// </summary>
         /// <param name="value">Value of the UnitName input for this Choreo.</param>
         public void setUnitName(String value) {
             base.addInput ("UnitName", value);
         }
         /// <summary>
         /// (optional, integer) An integer representing the amount of time to query for. Corresponds to the UnitName input. Defaults to -1 indicating to return all units of time.
         /// </summary>
         /// <param name="value">Value of the UnitValue input for this Choreo.</param>
         public void setUnitValue(String value) {
             base.addInput ("UnitValue", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetReferrersResultSet containing execution metadata and results.</returns>
        new public GetReferrersResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetReferrersResultSet results = new JavaScriptSerializer().Deserialize<GetReferrersResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetReferrers Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetReferrersResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Bitly.</returns>
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
