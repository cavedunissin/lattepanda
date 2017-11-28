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

namespace Temboo.Library.Xively.ReadWriteData
{
    /// <summary>
    /// ReadFeed
    /// Returns filterable data on a specific feed viewable by the authenticated account.
    /// </summary>
    public class ReadFeed : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ReadFeed Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ReadFeed(TembooSession session) : base(session, "/Library/Xively/ReadWriteData/ReadFeed")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by Xively.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, string) Filter by datastream. Valid values - comma separated datastream IDs (Ex: energy,power).
         /// </summary>
         /// <param name="value">Value of the Datastreams input for this Choreo.</param>
         public void setDatastreams(String value) {
             base.addInput ("Datastreams", value);
         }
         /// <summary>
         /// (optional, string) Used for a historical query. If used with EndDate will request data prior to EndDate, if used with StartDate will request data after StartDate. By itself will give most recent data. Ex: 6hours, 2days.
         /// </summary>
         /// <param name="value">Value of the Duration input for this Choreo.</param>
         public void setDuration(String value) {
             base.addInput ("Duration", value);
         }
         /// <summary>
         /// (optional, date) Used for a historical query. Defines the end point of the data returned as a timestamp. Ex: 2013-05-10T12:00:00Z.
         /// </summary>
         /// <param name="value">Value of the EndDate input for this Choreo.</param>
         public void setEndDate(String value) {
             base.addInput ("EndDate", value);
         }
         /// <summary>
         /// (required, integer) The ID of the feed you wish to view.
         /// </summary>
         /// <param name="value">Value of the FeedID input for this Choreo.</param>
         public void setFeedID(String value) {
             base.addInput ("FeedID", value);
         }
         /// <summary>
         /// (optional, string) The type of feed that is being returned. Valid values are "json" (the default), "csv" and "xml". No metadata is returned for the csv feed.
         /// </summary>
         /// <param name="value">Value of the FeedType input for this Choreo.</param>
         public void setFeedType(String value) {
             base.addInput ("FeedType", value);
         }
         /// <summary>
         /// (optional, boolean) Used for a historical query. Will also return the previous value to the date range being requested. Useful when graphing, to start a graph with a datapoint. Valid values: "true", blank (default).
         /// </summary>
         /// <param name="value">Value of the FindPrevious input for this Choreo.</param>
         public void setFindPrevious(String value) {
             base.addInput ("FindPrevious", value);
         }
         /// <summary>
         /// (optional, integer) Used for a historical query. Determines what interval of data is requested and is defined in seconds between the datapoints. See documentation for full list of possible values. Ex.: 0, 30, 60, etc.
         /// </summary>
         /// <param name="value">Value of the Interval input for this Choreo.</param>
         public void setInterval(String value) {
             base.addInput ("Interval", value);
         }
         /// <summary>
         /// (optional, string) Used for a historical query. If set to "discrete" the data will be returned in fixed time interval format according to Interval value. If not set, the raw datapoints will be returned.
         /// </summary>
         /// <param name="value">Value of the IntervalType input for this Choreo.</param>
         public void setIntervalType(String value) {
             base.addInput ("IntervalType", value);
         }
         /// <summary>
         /// (optional, integer) Used for a historical query. Limits the number of results to the number specified here. Defaults to 100, has a maximum of 1000.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, string) Include user login for each feed. For JSON/XML response only. Valid values: "true", "false" (default).
         /// </summary>
         /// <param name="value">Value of the ShowUser input for this Choreo.</param>
         public void setShowUser(String value) {
             base.addInput ("ShowUser", value);
         }
         /// <summary>
         /// (optional, date) Used for a historical query. Defines the starting point of the query as a timestamp. Ex: 2013-05-10T00:00:00Z.
         /// </summary>
         /// <param name="value">Value of the StartDate input for this Choreo.</param>
         public void setStartDate(String value) {
             base.addInput ("StartDate", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ReadFeedResultSet containing execution metadata and results.</returns>
        new public ReadFeedResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ReadFeedResultSet results = new JavaScriptSerializer().Deserialize<ReadFeedResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ReadFeed Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ReadFeedResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Xively.</returns>
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
