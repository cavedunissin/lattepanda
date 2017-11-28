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
    /// DescribeDBSnapshot
    /// Returns information about DB Snapshots.
    /// </summary>
    public class DescribeDBSnapshot : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the DescribeDBSnapshot Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public DescribeDBSnapshot(TembooSession session) : base(session, "/Library/Amazon/RDS/DescribeDBSnapshot")
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
         /// (optional, string) The DB Instance identifier. Should be in all lowercase.
         /// </summary>
         /// <param name="value">Value of the DBInstanceIdentifier input for this Choreo.</param>
         public void setDBInstanceIdentifier(String value) {
             base.addInput ("DBInstanceIdentifier", value);
         }
         /// <summary>
         /// (optional, string) The unique identifier for the db snapshot you're retrieving information for.
         /// </summary>
         /// <param name="value">Value of the DBSnapshotIdentifier input for this Choreo.</param>
         public void setDBSnapshotIdentifier(String value) {
             base.addInput ("DBSnapshotIdentifier", value);
         }
         /// <summary>
         /// (optional, integer) The max number of results to return in the response. Defaults to 100. Minimum is 20.
         /// </summary>
         /// <param name="value">Value of the MaxRecords input for this Choreo.</param>
         public void setMaxRecords(String value) {
             base.addInput ("MaxRecords", value);
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
        /// <returns>A DescribeDBSnapshotResultSet containing execution metadata and results.</returns>
        new public DescribeDBSnapshotResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            DescribeDBSnapshotResultSet results = new JavaScriptSerializer().Deserialize<DescribeDBSnapshotResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the DescribeDBSnapshot Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class DescribeDBSnapshotResultSet : Temboo.Core.ResultSet
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
