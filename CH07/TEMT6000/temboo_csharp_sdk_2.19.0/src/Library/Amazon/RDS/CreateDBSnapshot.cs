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
    /// CreateDBSnapshot
    /// Creates a snapshot of an existing database instance.
    /// </summary>
    public class CreateDBSnapshot : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateDBSnapshot Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateDBSnapshot(TembooSession session) : base(session, "/Library/Amazon/RDS/CreateDBSnapshot")
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
         /// (required, string) The DB Instance identifier. Should be in all lowercase.
         /// </summary>
         /// <param name="value">Value of the DBInstanceIdentifier input for this Choreo.</param>
         public void setDBInstanceIdentifier(String value) {
             base.addInput ("DBInstanceIdentifier", value);
         }
         /// <summary>
         /// (required, string) The unique identifier for the db snapshot you're creating.
         /// </summary>
         /// <param name="value">Value of the DBSnapshotIdentifier input for this Choreo.</param>
         public void setDBSnapshotIdentifier(String value) {
             base.addInput ("DBSnapshotIdentifier", value);
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
        /// <returns>A CreateDBSnapshotResultSet containing execution metadata and results.</returns>
        new public CreateDBSnapshotResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateDBSnapshotResultSet results = new JavaScriptSerializer().Deserialize<CreateDBSnapshotResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateDBSnapshot Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateDBSnapshotResultSet : Temboo.Core.ResultSet
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
