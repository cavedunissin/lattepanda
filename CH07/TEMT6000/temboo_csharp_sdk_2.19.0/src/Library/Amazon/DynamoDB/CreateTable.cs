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
    /// CreateTable
    /// Adds a new table to your account.
    /// </summary>
    public class CreateTable : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateTable Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateTable(TembooSession session) : base(session, "/Library/Amazon/DynamoDB/CreateTable")
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
         /// (required, json) An array of attributes that describe the key schema for the table and indexes.
         /// </summary>
         /// <param name="value">Value of the AttributeDefinitions input for this Choreo.</param>
         public void setAttributeDefinitions(String value) {
             base.addInput ("AttributeDefinitions", value);
         }
         /// <summary>
         /// (optional, json) One or more global secondary indexes (the maximum is five) to be created on the table.
         /// </summary>
         /// <param name="value">Value of the GlobalSecondaryIndexes input for this Choreo.</param>
         public void setGlobalSecondaryIndexes(String value) {
             base.addInput ("GlobalSecondaryIndexes", value);
         }
         /// <summary>
         /// (required, json) Specifies the attributes that make up the primary key for a table or an index. This is a JSON array of objects containing properties for AttributeName and KeyType. 
         /// </summary>
         /// <param name="value">Value of the KeySchema input for this Choreo.</param>
         public void setKeySchema(String value) {
             base.addInput ("KeySchema", value);
         }
         /// <summary>
         /// (optional, json) One or more local secondary indexes (the maximum is five) to be created on the table.
         /// </summary>
         /// <param name="value">Value of the LocalSecondaryIndexes input for this Choreo.</param>
         public void setLocalSecondaryIndexes(String value) {
             base.addInput ("LocalSecondaryIndexes", value);
         }
         /// <summary>
         /// (required, json) Represents the provisioned throughput settings for a specified table or index.
         /// </summary>
         /// <param name="value">Value of the ProvisionedThroughput input for this Choreo.</param>
         public void setProvisionedThroughput(String value) {
             base.addInput ("ProvisionedThroughput", value);
         }
         /// <summary>
         /// (optional, json) The settings for DynamoDB Streams on the table.
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
        /// <returns>A CreateTableResultSet containing execution metadata and results.</returns>
        new public CreateTableResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateTableResultSet results = new JavaScriptSerializer().Deserialize<CreateTableResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateTable Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateTableResultSet : Temboo.Core.ResultSet
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
