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
    /// WriteData
    /// Allows you to update your feed, including updating/creating new datastreams and datapoints. 
    /// </summary>
    public class WriteData : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the WriteData Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public WriteData(TembooSession session) : base(session, "/Library/Xively/ReadWriteData/WriteData")
        {
        }

         /// <summary>
         /// (optional, any) Custom data body for the new feed in JSON or XML format (set by FeedType).  See Xively documentation (link below) for the minimum required fields. If FeedData is used, Value and Timestamp are ignored.
         /// </summary>
         /// <param name="value">Value of the FeedData input for this Choreo.</param>
         public void setFeedData(String value) {
             base.addInput ("FeedData", value);
         }
         /// <summary>
         /// (required, string) The API Key provided by Xively.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, string) ID for single datastream you would like to update. Required if specifying a single datapoint update using Value.
         /// </summary>
         /// <param name="value">Value of the DatastreamID input for this Choreo.</param>
         public void setDatastreamID(String value) {
             base.addInput ("DatastreamID", value);
         }
         /// <summary>
         /// (required, integer) The ID for the feed that you would like to update.
         /// </summary>
         /// <param name="value">Value of the FeedID input for this Choreo.</param>
         public void setFeedID(String value) {
             base.addInput ("FeedID", value);
         }
         /// <summary>
         /// (optional, string) The type of feed that is being provided for custom FeedData. Valid values are "json" (the default), "xml" and "csv". Ignored if specifying single datapoint Value.
         /// </summary>
         /// <param name="value">Value of the FeedType input for this Choreo.</param>
         public void setFeedType(String value) {
             base.addInput ("FeedType", value);
         }
         /// <summary>
         /// (optional, date) Can be used with a single Value and DatastreamID. If specified, sets timestamp for Value. If Value is set with blank Timestamp, Value's timestamp will be current time. Ex: 2013-05-10T00:00:00.123456Z.
         /// </summary>
         /// <param name="value">Value of the Timestamp input for this Choreo.</param>
         public void setTimestamp(String value) {
             base.addInput ("Timestamp", value);
         }
         /// <summary>
         /// (optional, string) Specifies the value for a single datapoint in a specified datastream.
         /// </summary>
         /// <param name="value">Value of the Value input for this Choreo.</param>
         public void setValue(String value) {
             base.addInput ("Value", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A WriteDataResultSet containing execution metadata and results.</returns>
        new public WriteDataResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            WriteDataResultSet results = new JavaScriptSerializer().Deserialize<WriteDataResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the WriteData Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class WriteDataResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "ResponseStatusCode" output from this Choreo execution
        /// <returns>String - (integer) The response status code returned from Xively. For a successful feed / data update, the code should be 200.</returns>
        /// </summary>
        public String ResponseStatusCode
        {
            get
            {
                return (String) base.Output["ResponseStatusCode"];
            }
        }
    }
}
