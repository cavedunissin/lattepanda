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
    /// ReadGraph
    /// Returns a customizable graph (Base64-encoded PNG image file) of datapoints from a specific datastream.
    /// </summary>
    public class ReadGraph : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ReadGraph Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ReadGraph(TembooSession session) : base(session, "/Library/Xively/ReadWriteData/ReadGraph")
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
         /// (optional, string) The PNG color in hex. Ex: FFCC33.
         /// </summary>
         /// <param name="value">Value of the Color input for this Choreo.</param>
         public void setColor(String value) {
             base.addInput ("Color", value);
         }
         /// <summary>
         /// (required, string) The ID for the datastream you wish to read.
         /// </summary>
         /// <param name="value">Value of the DatastreamID input for this Choreo.</param>
         public void setDatastreamID(String value) {
             base.addInput ("DatastreamID", value);
         }
         /// <summary>
         /// (optional, string) Used for a historical query. If used with EndDate will request data prior to EndDate, if used with StartDate will request data after StartDate. By itself will give most recent data. Ex: 6hours, 2days.
         /// </summary>
         /// <param name="value">Value of the Duration input for this Choreo.</param>
         public void setDuration(String value) {
             base.addInput ("Duration", value);
         }
         /// <summary>
         /// (optional, date) Used for a historical query. Defines the end point of the data returned as a timestamp. Ex: 2013-05-10T12:00:00Z. Default value is set to current timestamp.
         /// </summary>
         /// <param name="value">Value of the EndDate input for this Choreo.</param>
         public void setEndDate(String value) {
             base.addInput ("EndDate", value);
         }
         /// <summary>
         /// (required, integer) The ID of the feed you wish to read.
         /// </summary>
         /// <param name="value">Value of the FeedID input for this Choreo.</param>
         public void setFeedID(String value) {
             base.addInput ("FeedID", value);
         }
         /// <summary>
         /// (optional, boolean) Used for a historical query. Will also return the previous value to the date range being requested. Useful to allow a graph to start a graph with some datapoint. Valid values: "true", blank (default).
         /// </summary>
         /// <param name="value">Value of the FindPrevious input for this Choreo.</param>
         public void setFindPrevious(String value) {
             base.addInput ("FindPrevious", value);
         }
         /// <summary>
         /// (optional, integer) The PNG height in pixels. Max height: 500. Ex: 400.
         /// </summary>
         /// <param name="value">Value of the Height input for this Choreo.</param>
         public void setHeight(String value) {
             base.addInput ("Height", value);
         }
         /// <summary>
         /// (optional, integer) Used for a historical query. Determines what interval of data is requested and is defined in seconds between the datapoints. See documentation for full list of possible values. Ex: 0, 30, 60, etc.
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
         /// (optional, string) Label given datapoints on a legend included on the graph.
         /// </summary>
         /// <param name="value">Value of the Legend input for this Choreo.</param>
         public void setLegend(String value) {
             base.addInput ("Legend", value);
         }
         /// <summary>
         /// (optional, integer) Used for a historical query. LImits the number of results to the number specified here. Defaults to 100, has a maximum of 1000.
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
         }
         /// <summary>
         /// (optional, integer) Size of the lines/strokes in pixels. Ex: 4.
         /// </summary>
         /// <param name="value">Value of the LineSize input for this Choreo.</param>
         public void setLineSize(String value) {
             base.addInput ("LineSize", value);
         }
         /// <summary>
         /// (optional, boolean) Show access labels. Input "true" to turn on, leave blank to keep off (default).
         /// </summary>
         /// <param name="value">Value of the ShowAxisLabels input for this Choreo.</param>
         public void setShowAxisLabels(String value) {
             base.addInput ("ShowAxisLabels", value);
         }
         /// <summary>
         /// (optional, string) Show detailed grid. Input "true" to turn on, leave blank to keep off (default).
         /// </summary>
         /// <param name="value">Value of the ShowDetailedGrid input for this Choreo.</param>
         public void setShowDetailedGrid(String value) {
             base.addInput ("ShowDetailedGrid", value);
         }
         /// <summary>
         /// (optional, date) Used for a historical query. Defines the starting the point of the query as a timestamp. Ex: 2013-05-10T00:00:00Z.
         /// </summary>
         /// <param name="value">Value of the StartDate input for this Choreo.</param>
         public void setStartDate(String value) {
             base.addInput ("StartDate", value);
         }
         /// <summary>
         /// (optional, string) Timezone of the graph. For a list of valid values please see description and API documenation. Ex: Eastern Time (US & Canada), Pacific Time (US & Canada), UTC, Tokyo.
         /// </summary>
         /// <param name="value">Value of the Timezone input for this Choreo.</param>
         public void setTimezone(String value) {
             base.addInput ("Timezone", value);
         }
         /// <summary>
         /// (optional, string) Title of the graph.
         /// </summary>
         /// <param name="value">Value of the Title input for this Choreo.</param>
         public void setTitle(String value) {
             base.addInput ("Title", value);
         }
         /// <summary>
         /// (optional, integer) The PNG width in pixels. Max width: 600. Ex: 600.
         /// </summary>
         /// <param name="value">Value of the Width input for this Choreo.</param>
         public void setWidth(String value) {
             base.addInput ("Width", value);
         }
         /// <summary>
         /// (optional, string) Y-axis maximum value if the YAxisScale is set to "manual".
         /// </summary>
         /// <param name="value">Value of the YAxisMax input for this Choreo.</param>
         public void setYAxisMax(String value) {
             base.addInput ("YAxisMax", value);
         }
         /// <summary>
         /// (optional, string) Y-axis minimum value if the YAxisScale is set to "manual".
         /// </summary>
         /// <param name="value">Value of the YAxisMin input for this Choreo.</param>
         public void setYAxisMin(String value) {
             base.addInput ("YAxisMin", value);
         }
         /// <summary>
         /// (optional, string) Method used to determine the y-axis scale. Valid values: "auto" (default), "datastream", or "manual".
         /// </summary>
         /// <param name="value">Value of the YAxisScale input for this Choreo.</param>
         public void setYAxisScale(String value) {
             base.addInput ("YAxisScale", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ReadGraphResultSet containing execution metadata and results.</returns>
        new public ReadGraphResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ReadGraphResultSet results = new JavaScriptSerializer().Deserialize<ReadGraphResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ReadGraph Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ReadGraphResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Xively, which is a base64-encoded binary .png file. Decode to get the binary PNG graphic.</returns>
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
