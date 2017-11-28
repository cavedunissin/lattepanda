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

namespace Temboo.Library.Amazon.RDS
{
    /// <summary>
    /// DescribeEvents
    /// Returns events related to DB Instances, DB Security Groups, DB Snapshots and DB Parameter Groups for the past 14 days.
    /// </summary>
    public class DescribeEvents : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the DescribeEvents Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public DescribeEvents(TembooSession session) : base(session, "/Library/Amazon/RDS/DescribeEvents")
        {
        }

         /// <summary>
         /// (required, string) The Access Key ID provided by Amazon Web Services.
         /// </summary>
         /// <param name="value">Value of the AWSAccessKeyId input for this Choreo.</param>
         public void setAWSAccessKeyId(String value) {
             base.addInput ("AWSAccessKeyId", value);
         }
         /// <summary>
         /// (required, string) The Secret Key ID provided by Amazon Web Services.
         /// </summary>
         /// <param name="value">Value of the AWSSecretKeyId input for this Choreo.</param>
         public void setAWSSecretKeyId(String value) {
             base.addInput ("AWSSecretKeyId", value);
         }
         /// <summary>
         /// (optional, integer) The number of minutes to retrieve events for. Defaults to 60.
         /// </summary>
         /// <param name="value">Value of the Duration input for this Choreo.</param>
         public void setDuration(String value) {
             base.addInput ("Duration", value);
         }
         /// <summary>
         /// (optional, date) The end of the time interval for which to retrieve events, specified in ISO 8601 format (i.e. 2009-07-08T18:00Z).
         /// </summary>
         /// <param name="value">Value of the EndTime input for this Choreo.</param>
         public void setEndTime(String value) {
             base.addInput ("EndTime", value);
         }
         /// <summary>
         /// (optional, integer) If this parameter is specified, the response includes only records beyond the marker, up to the value specified by MaxRecords.
         /// </summary>
         /// <param name="value">Value of the Marker input for this Choreo.</param>
         public void setMarker(String value) {
             base.addInput ("Marker", value);
         }
         /// <summary>
         /// (optional, integer) The maximum number of records to include in the response. If more records exist, a marker is included in the response so that the remaining results may be retrieved. Defaults to max (100). Min is 20.
         /// </summary>
         /// <param name="value">Value of the MaxRecords input for this Choreo.</param>
         public void setMaxRecords(String value) {
             base.addInput ("MaxRecords", value);
         }
         /// <summary>
         /// (optional, string) The identifier of the event source for which events will be returned. If not specified, then all sources are included in the response.
         /// </summary>
         /// <param name="value">Value of the SourceIdentifier input for this Choreo.</param>
         public void setSourceIdentifier(String value) {
             base.addInput ("SourceIdentifier", value);
         }
         /// <summary>
         /// (optional, string) The event source to retrieve events for. If no value is specified, all events are returned. Valid values are: db-instance | db-parameter-group | db-security-group | db-snapshot.
         /// </summary>
         /// <param name="value">Value of the SourceType input for this Choreo.</param>
         public void setSourceType(String value) {
             base.addInput ("SourceType", value);
         }
         /// <summary>
         /// (optional, date) The beginning of the time interval to retrieve events for, specified in ISO 8601 format (i.e. 2009-07-08T18:00Z)
         /// </summary>
         /// <param name="value">Value of the StartTime input for this Choreo.</param>
         public void setStartTime(String value) {
             base.addInput ("StartTime", value);
         }
         /// <summary>
         /// (optional, string) The AWS region that corresponds to the RDS endpoint you wish to access. The default region is "us-east-1". See description below for valid values.
         /// </summary>
         /// <param name="value">Value of the UserRegion input for this Choreo.</param>
         public void setUserRegion(String value) {
             base.addInput ("UserRegion", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A DescribeEventsResultSet containing execution metadata and results.</returns>
        new public DescribeEventsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            DescribeEventsResultSet results = new JavaScriptSerializer().Deserialize<DescribeEventsResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the DescribeEvents Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class DescribeEventsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) The response from Amazon.</returns>
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
