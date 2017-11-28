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
    /// DeleteMultipleDatapoints
    /// Deletes multiple datapoints from a single datastream given a start date, end date, and/or duration.
    /// </summary>
    public class DeleteMultipleDatapoints : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the DeleteMultipleDatapoints Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public DeleteMultipleDatapoints(TembooSession session) : base(session, "/Library/Xively/ReadWriteData/DeleteMultipleDatapoints")
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
         /// (required, string) The ID of the datastream you would like to delete datapoints from.
         /// </summary>
         /// <param name="value">Value of the DatastreamID input for this Choreo.</param>
         public void setDatastreamID(String value) {
             base.addInput ("DatastreamID", value);
         }
         /// <summary>
         /// (conditional, string) Specifies the duration of the deletion. Can be used with StartDate or EndDate. Ex: 5seconds, 10minutes, 6hours. See documentation for full description / examples.
         /// </summary>
         /// <param name="value">Value of the Duration input for this Choreo.</param>
         public void setDuration(String value) {
             base.addInput ("Duration", value);
         }
         /// <summary>
         /// (conditional, date) Defines the end point of the deletion as a timestamp. Can be used with Duration. Ex: 2013-05-10T12:00:00Z.
         /// </summary>
         /// <param name="value">Value of the EndDate input for this Choreo.</param>
         public void setEndDate(String value) {
             base.addInput ("EndDate", value);
         }
         /// <summary>
         /// (required, string) The ID of the feed you would like to delete datapoints from.
         /// </summary>
         /// <param name="value">Value of the FeedID input for this Choreo.</param>
         public void setFeedID(String value) {
             base.addInput ("FeedID", value);
         }
         /// <summary>
         /// (conditional, date) Defines the starting point of the deletion as a timestamp. Can be used with Duration. Ex: 2013-05-10T00:00:00Z.
         /// </summary>
         /// <param name="value">Value of the StartDate input for this Choreo.</param>
         public void setStartDate(String value) {
             base.addInput ("StartDate", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A DeleteMultipleDatapointsResultSet containing execution metadata and results.</returns>
        new public DeleteMultipleDatapointsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            DeleteMultipleDatapointsResultSet results = new JavaScriptSerializer().Deserialize<DeleteMultipleDatapointsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the DeleteMultipleDatapoints Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class DeleteMultipleDatapointsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "ResponsStatusCode" output from this Choreo execution
        /// <returns>String - (integer) The response status code returned from Xively. For a successful datapoint range deletion, the code should be 200.</returns>
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
