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
    /// GetItem
    /// Returns a set of attributes for the item with the given primary key.
    /// </summary>
    public class GetItem : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetItem Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetItem(TembooSession session) : base(session, "/Library/Amazon/DynamoDB/GetItem")
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
         /// (optional, boolean) Determines the read consistency model: If set to true, then the operation uses strongly consistent reads; otherwise, the operation uses eventually consistent reads.
         /// </summary>
         /// <param name="value">Value of the ConsistentRead input for this Choreo.</param>
         public void setConsistentRead(String value) {
             base.addInput ("ConsistentRead", value);
         }
         /// <summary>
         /// (optional, json) One or more substitution tokens for attribute names in an expression.
         /// </summary>
         /// <param name="value">Value of the ExpressionAttributeNames input for this Choreo.</param>
         public void setExpressionAttributeNames(String value) {
             base.addInput ("ExpressionAttributeNames", value);
         }
         /// <summary>
         /// (required, json) A map of attribute names to AttributeValue objects, representing the primary key of the item to retrieve.
         /// </summary>
         /// <param name="value">Value of the Key input for this Choreo.</param>
         public void setKey(String value) {
             base.addInput ("Key", value);
         }
         /// <summary>
         /// (optional, string) A string that identifies one or more attributes to retrieve from the table.
         /// </summary>
         /// <param name="value">Value of the ProjectionExpression input for this Choreo.</param>
         public void setProjectionExpression(String value) {
             base.addInput ("ProjectionExpression", value);
         }
         /// <summary>
         /// (optional, string) Determines the level of detail about provisioned throughput consumption that is returned in the response. Valid values are: INDEXES, TOTAL, NONE.
         /// </summary>
         /// <param name="value">Value of the ReturnConsumedCapacity input for this Choreo.</param>
         public void setReturnConsumedCapacity(String value) {
             base.addInput ("ReturnConsumedCapacity", value);
         }
         /// <summary>
         /// (required, string) The name of the table containing the requested items.
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
        /// <returns>A GetItemResultSet containing execution metadata and results.</returns>
        new public GetItemResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetItemResultSet results = new JavaScriptSerializer().Deserialize<GetItemResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetItem Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetItemResultSet : Temboo.Core.ResultSet
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
