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
    /// DeleteDatapoint
    /// Deletes a single existing datapoint for a specific timestamp.
    /// </summary>
    public class DeleteDatapoint : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the DeleteDatapoint Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public DeleteDatapoint(TembooSession session) : base(session, "/Library/Xively/ReadWriteData/DeleteDatapoint")
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
         /// (required, string) The ID of the datastream you would like to delete the datapoint for.
         /// </summary>
         /// <param name="value">Value of the DatastreamID input for this Choreo.</param>
         public void setDatastreamID(String value) {
             base.addInput ("DatastreamID", value);
         }
         /// <summary>
         /// (required, string) The ID of the feed you would like to delete the datapoint for.
         /// </summary>
         /// <param name="value">Value of the FeedID input for this Choreo.</param>
         public void setFeedID(String value) {
             base.addInput ("FeedID", value);
         }
         /// <summary>
         /// (required, date) Timestamp of datapoint value to delete. Must be in ISO 8601 format, and can include up to 6 decimal places of resolution (in seconds), default zone is UTC.  Ex: 2013-05-07T00:00:00.123456Z.
         /// </summary>
         /// <param name="value">Value of the Timestamp input for this Choreo.</param>
         public void setTimestamp(String value) {
             base.addInput ("Timestamp", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A DeleteDatapointResultSet containing execution metadata and results.</returns>
        new public DeleteDatapointResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            DeleteDatapointResultSet results = new JavaScriptSerializer().Deserialize<DeleteDatapointResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the DeleteDatapoint Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class DeleteDatapointResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "ResponsStatusCode" output from this Choreo execution
        /// <returns>String - (integer) The response status code returned from Xively. For a successful datapoint deletion, the code should be 200.</returns>
        /// </summary>
        public String ResponsStatusCode
        {
            get
            {
                return (String) base.Output["ResponsStatusCode"];
            }
        }
    }
}
