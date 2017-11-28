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

namespace Temboo.Library.Mixpanel.DataExport.Funnels
{
    /// <summary>
    /// FunnelData
    /// Gets data for a specified funnel.
    /// </summary>
    public class FunnelData : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the FunnelData Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public FunnelData(TembooSession session) : base(session, "/Library/Mixpanel/DataExport/Funnels/FunnelData")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided my Mixpanel. You can find your Mixpanel API Key in the project settings dialog in the Mixpanel app.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, string) The API Secret provided by Mixpanel. You can find your Mixpanel API Secret in the project settings dialog in the Mixpanel app.
         /// </summary>
         /// <param name="value">Value of the APISecret input for this Choreo.</param>
         public void setAPISecret(String value) {
             base.addInput ("APISecret", value);
         }
         /// <summary>
         /// (optional, integer) The amount of minutes past NOW() before the request will expire. Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the Expire input for this Choreo.</param>
         public void setExpire(String value) {
             base.addInput ("Expire", value);
         }
         /// <summary>
         /// (optional, date) The first date in yyyy-mm-dd format from which a user can begin the first step in the funnel. This date is inclusive.
         /// </summary>
         /// <param name="value">Value of the FromDate input for this Choreo.</param>
         public void setFromDate(String value) {
             base.addInput ("FromDate", value);
         }
         /// <summary>
         /// (required, string) The ID of the funnel to get data for.
         /// </summary>
         /// <param name="value">Value of the FunnelID input for this Choreo.</param>
         public void setFunnelID(String value) {
             base.addInput ("FunnelID", value);
         }
         /// <summary>
         /// (optional, integer) The number of days you want your results bucketed into.The default value is 1.
         /// </summary>
         /// <param name="value">Value of the Interval input for this Choreo.</param>
         public void setInterval(String value) {
             base.addInput ("Interval", value);
         }
         /// <summary>
         /// (optional, integer) The number of days each user has to complete the funnel, starting from the time they triggered the first step in the funnel. May not be greater than 60 days. Defaults to 14.
         /// </summary>
         /// <param name="value">Value of the Length input for this Choreo.</param>
         public void setLength(String value) {
             base.addInput ("Length", value);
         }
         /// <summary>
         /// (optional, integer) Return the top limit property values. This parameter is ignored if the On input is not specified.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, string) The property expression to segment the event on (e.g., properties["Referred By"] == "Friend"). See Choreo description for examples.
         /// </summary>
         /// <param name="value">Value of the On input for this Choreo.</param>
         public void setOn(String value) {
             base.addInput ("On", value);
         }
         /// <summary>
         /// (optional, date) The last date in yyyy-mm-dd format from which a user can begin the first step in the funnel. This date is inclusive. The date range may not be more than 60 days.
         /// </summary>
         /// <param name="value">Value of the ToDate input for this Choreo.</param>
         public void setToDate(String value) {
             base.addInput ("ToDate", value);
         }
         /// <summary>
         /// (optional, string) This is an alternate way of specifying interval and can set to be 'day' or 'week'.
         /// </summary>
         /// <param name="value">Value of the Unit input for this Choreo.</param>
         public void setUnit(String value) {
             base.addInput ("Unit", value);
         }
         /// <summary>
         /// (optional, string) An expression to filter events by  (e.g., properties["Signed Up"]). See Choreo description for examples.
         /// </summary>
         /// <param name="value">Value of the Where input for this Choreo.</param>
         public void setWhere(String value) {
             base.addInput ("Where", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A FunnelDataResultSet containing execution metadata and results.</returns>
        new public FunnelDataResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            FunnelDataResultSet results = new JavaScriptSerializer().Deserialize<FunnelDataResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the FunnelData Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class FunnelDataResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Mixpanel.</returns>
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
