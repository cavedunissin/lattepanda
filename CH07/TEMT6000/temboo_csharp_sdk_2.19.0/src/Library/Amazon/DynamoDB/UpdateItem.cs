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
    /// UpdateItem
    /// Edits an existing item's attributes, or adds a new item to the table if it does not already exist.
    /// </summary>
    public class UpdateItem : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateItem Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateItem(TembooSession session) : base(session, "/Library/Amazon/DynamoDB/UpdateItem")
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
         /// (optional, string) A condition that must be satisfied in order for a conditional update to succeed.
         /// </summary>
         /// <param name="value">Value of the ConditionExpression input for this Choreo.</param>
         public void setConditionExpression(String value) {
             base.addInput ("ConditionExpression", value);
         }
         /// <summary>
         /// (optional, json) One or more substitution tokens for attribute names in an expression.
         /// </summary>
         /// <param name="value">Value of the ExpressionAttributeNames input for this Choreo.</param>
         public void setExpressionAttributeNames(String value) {
             base.addInput ("ExpressionAttributeNames", value);
         }
         /// <summary>
         /// (optional, json) One or more values that can be substituted in an expression.
         /// </summary>
         /// <param name="value">Value of the ExpressionAttributeValues input for this Choreo.</param>
         public void setExpressionAttributeValues(String value) {
             base.addInput ("ExpressionAttributeValues", value);
         }
         /// <summary>
         /// (required, json) The primary key of the item to be updated. Each element consists of an attribute name and a value for that attribute.
         /// </summary>
         /// <param name="value">Value of the Key input for this Choreo.</param>
         public void setKey(String value) {
             base.addInput ("Key", value);
         }
         /// <summary>
         /// (optional, string) Determines the level of detail about provisioned throughput consumption that is returned in the response. Valid values are: INDEXES, TOTAL, NONE.
         /// </summary>
         /// <param name="value">Value of the ReturnConsumedCapacity input for this Choreo.</param>
         public void setReturnConsumedCapacity(String value) {
             base.addInput ("ReturnConsumedCapacity", value);
         }
         /// <summary>
         /// (optional, string) Determines whether item collection metrics are returned. Valid values are: SIZE and NONE.
         /// </summary>
         /// <param name="value">Value of the ReturnItemCollectionMetrics input for this Choreo.</param>
         public void setReturnItemCollectionMetrics(String value) {
             base.addInput ("ReturnItemCollectionMetrics", value);
         }
         /// <summary>
         /// (optional, string) Use ReturnValues if you want to get the item attributes as they appeared either before or after they were updated. Valid values are NONE and ALL_OLD.
         /// </summary>
         /// <param name="value">Value of the ReturnValues input for this Choreo.</param>
         public void setReturnValues(String value) {
             base.addInput ("ReturnValues", value);
         }
         /// <summary>
         /// (required, string) The name of the table to contain the item.
         /// </summary>
         /// <param name="value">Value of the TableName input for this Choreo.</param>
         public void setTableName(String value) {
             base.addInput ("TableName", value);
         }
         /// <summary>
         /// (optional, string) An expression that defines one or more attributes to be updated, the action to be performed on them, and new value(s) for them.
         /// </summary>
         /// <param name="value">Value of the UpdateExpression input for this Choreo.</param>
         public void setUpdateExpression(String value) {
             base.addInput ("UpdateExpression", value);
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
        /// <returns>A UpdateItemResultSet containing execution metadata and results.</returns>
        new public UpdateItemResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateItemResultSet results = new JavaScriptSerializer().Deserialize<UpdateItemResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateItem Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateItemResultSet : Temboo.Core.ResultSet
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
