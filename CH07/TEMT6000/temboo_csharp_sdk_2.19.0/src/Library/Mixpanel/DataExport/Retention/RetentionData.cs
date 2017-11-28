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

namespace Temboo.Library.Mixpanel.DataExport.Retention
{
    /// <summary>
    /// RetentionData
    /// Gets cohort analysis.
    /// </summary>
    public class RetentionData : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the RetentionData Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public RetentionData(TembooSession session) : base(session, "/Library/Mixpanel/DataExport/Retention/RetentionData")
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
         /// (conditional, string) The first event a user must do to be counted in a birth retention cohort. Required when retention_type is 'birth'.
         /// </summary>
         /// <param name="value">Value of the BornEvent input for this Choreo.</param>
         public void setBornEvent(String value) {
             base.addInput ("BornEvent", value);
         }
         /// <summary>
         /// (optional, string) An expression to filter born_events by. See Choreo description for examples.
         /// </summary>
         /// <param name="value">Value of the BornWhere input for this Choreo.</param>
         public void setBornWhere(String value) {
             base.addInput ("BornWhere", value);
         }
         /// <summary>
         /// (optional, string) The event to generate returning counts for.
         /// </summary>
         /// <param name="value">Value of the EventName input for this Choreo.</param>
         public void setEventName(String value) {
             base.addInput ("EventName", value);
         }
         /// <summary>
         /// (optional, integer) The amount of minutes past NOW() before the request will expire. Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the Expire input for this Choreo.</param>
         public void setExpire(String value) {
             base.addInput ("Expire", value);
         }
         /// <summary>
         /// (required, date) The date in yyyy-mm-dd format from which to begin generating cohorts from. This date is inclusive.
         /// </summary>
         /// <param name="value">Value of the FromDate input for this Choreo.</param>
         public void setFromDate(String value) {
             base.addInput ("FromDate", value);
         }
         /// <summary>
         /// (optional, integer) The number of days you want your results bucketed into.The default value is 1 or specified by unit.
         /// </summary>
         /// <param name="value">Value of the Interval input for this Choreo.</param>
         public void setInterval(String value) {
             base.addInput ("Interval", value);
         }
         /// <summary>
         /// (optional, integer) The number of intervals you want. Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the IntervalCount input for this Choreo.</param>
         public void setIntervalCount(String value) {
             base.addInput ("IntervalCount", value);
         }
         /// <summary>
         /// (optional, integer) Return the top limit segmentation values. This parameter is ignored if the On input is not specified.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, string) The property expression to segment the second event on. See Choreo description for examples.
         /// </summary>
         /// <param name="value">Value of the On input for this Choreo.</param>
         public void setOn(String value) {
             base.addInput ("On", value);
         }
         /// <summary>
         /// (conditional, string) The type of retention. Valid values are: birth (the default) or compounded.
         /// </summary>
         /// <param name="value">Value of the RetentionType input for this Choreo.</param>
         public void setRetentionType(String value) {
             base.addInput ("RetentionType", value);
         }
         /// <summary>
         /// (required, date) The date in yyyy-mm-dd format from which to stop generating cohorts from. This date is inclusive.
         /// </summary>
         /// <param name="value">Value of the ToDate input for this Choreo.</param>
         public void setToDate(String value) {
             base.addInput ("ToDate", value);
         }
         /// <summary>
         /// (optional, string) This is an alternate way of specifying interval. Valid values are: day, week, or month.
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
        /// <returns>A RetentionDataResultSet containing execution metadata and results.</returns>
        new public RetentionDataResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            RetentionDataResultSet results = new JavaScriptSerializer().Deserialize<RetentionDataResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the RetentionData Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class RetentionDataResultSet : Temboo.Core.ResultSet
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
