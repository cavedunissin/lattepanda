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

namespace Temboo.Library.Amazon.DynamoDB
{
    /// <summary>
    /// UpdateTable
    /// Modifies the provisioned throughput settings, global secondary indexes, or DynamoDB Streams settings for a given table.
    /// </summary>
    public class UpdateTable : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateTable Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateTable(TembooSession session) : base(session, "/Library/Amazon/DynamoDB/UpdateTable")
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
         /// (optional, json) An array of attributes that describe the key schema for the table and indexes.
         /// </summary>
         /// <param name="value">Value of the AttributeDefinitions input for this Choreo.</param>
         public void setAttributeDefinitions(String value) {
             base.addInput ("AttributeDefinitions", value);
         }
         /// <summary>
         /// (conditional, json) One or more global secondary indexes (the maximum is five) to be created on the table.
         /// </summary>
         /// <param name="value">Value of the GlobalSecondaryIndexUpdates input for this Choreo.</param>
         public void setGlobalSecondaryIndexUpdates(String value) {
             base.addInput ("GlobalSecondaryIndexUpdates", value);
         }
         /// <summary>
         /// (conditional, json) Represents the provisioned throughput settings for a specified table or index.
         /// </summary>
         /// <param name="value">Value of the ProvisionedThroughput input for this Choreo.</param>
         public void setProvisionedThroughput(String value) {
             base.addInput ("ProvisionedThroughput", value);
         }
         /// <summary>
         /// (conditional, json) The settings for DynamoDB Streams on the table.
         /// </summary>
         /// <param name="value">Value of the StreamSpecification input for this Choreo.</param>
         public void setStreamSpecification(String value) {
             base.addInput ("StreamSpecification", value);
         }
         /// <summary>
         /// (required, string) The name of the table to create.
         /// </summary>
         /// <param name="value">Value of the TableName input for this Choreo.</param>
         public void setTableName(String value) {
             base.addInput ("TableName", value);
         }
         /// <summary>
         /// (optional, string) The AWS region that corresponds to the S3 endpoint you wish to access. The default region is "us-east-1".
         /// </summary>
         /// <param name="value">Value of the UserRegion input for this Choreo.</param>
         public void setUserRegion(String value) {
             base.addInput ("UserRegion", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UpdateTableResultSet containing execution metadata and results.</returns>
        new public UpdateTableResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateTableResultSet results = new JavaScriptSerializer().Deserialize<UpdateTableResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateTable Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateTableResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (json) The response from Amazon.</returns>
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
