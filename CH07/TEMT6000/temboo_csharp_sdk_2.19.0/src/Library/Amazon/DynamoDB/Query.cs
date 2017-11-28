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
    /// Query
    /// Queries a table using the primary key or a secondary index.
    /// </summary>
    public class Query : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Query Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Query(TembooSession session) : base(session, "/Library/Amazon/DynamoDB/Query")
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
         /// (optional, json) The primary key of the first item that this operation will evaluate. Use the value that was returned for LastEvaluatedKey in the previous operation.
         /// </summary>
         /// <param name="value">Value of the ExclusiveStartKey input for this Choreo.</param>
         public void setExclusiveStartKey(String value) {
             base.addInput ("ExclusiveStartKey", value);
         }
         /// <summary>
         /// (optional, json) One or more substitution tokens for attribute names in an expression.
         /// </summary>
         /// <param name="value">Value of the ExpressionAttributeNames input for this Choreo.</param>
         public void setExpressionAttributeNames(String value) {
             base.addInput ("ExpressionAttributeNames", value);
         }
         /// <summary>
         /// (conditional, json) One or more values that can be substituted in an expression.
         /// </summary>
         /// <param name="value">Value of the ExpressionAttributeValues input for this Choreo.</param>
         public void setExpressionAttributeValues(String value) {
             base.addInput ("ExpressionAttributeValues", value);
         }
         /// <summary>
         /// (optional, string) A string that contains conditions that DynamoDB applies after the Query operation, but before the data is returned to you.
         /// </summary>
         /// <param name="value">Value of the FilterExpression input for this Choreo.</param>
         public void setFilterExpression(String value) {
             base.addInput ("FilterExpression", value);
         }
         /// <summary>
         /// (optional, string) The name of an index to query. This index can be any local secondary index or global secondary index on the table.
         /// </summary>
         /// <param name="value">Value of the IndexName input for this Choreo.</param>
         public void setIndexName(String value) {
             base.addInput ("IndexName", value);
         }
         /// <summary>
         /// (conditional, string) The condition that specifies the key value(s) for items to be retrieved by the Query action.
         /// </summary>
         /// <param name="value">Value of the KeyConditionExpression input for this Choreo.</param>
         public void setKeyConditionExpression(String value) {
             base.addInput ("KeyConditionExpression", value);
         }
         /// <summary>
         /// (optional, integer) The maximum number of items to evaluate (not necessarily the number of matching items).
         /// </summary>
         /// <param name="value">Value of the Limit input for this Choreo.</param>
         public void setLimit(String value) {
             base.addInput ("Limit", value);
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
         /// (optional, boolean) Specifies the order for index traversal: If true (default), the traversal is performed in ascending order; if false, the traversal is performed in descending order.
         /// </summary>
         /// <param name="value">Value of the ScanIndexForward input for this Choreo.</param>
         public void setScanIndexForward(String value) {
             base.addInput ("ScanIndexForward", value);
         }
         /// <summary>
         /// (optional, string) The attributes to be returned in the result. Valid values are: ALL_ATTRIBUTES, ALL_PROJECTED_ATTRIBUTES, SPECIFIC_ATTRIBUTES, and COUNT.
         /// </summary>
         /// <param name="value">Value of the Select input for this Choreo.</param>
         public void setSelect(String value) {
             base.addInput ("Select", value);
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
        /// <returns>A QueryResultSet containing execution metadata and results.</returns>
        new public QueryResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            QueryResultSet results = new JavaScriptSerializer().Deserialize<QueryResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Query Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class QueryResultSet : Temboo.Core.ResultSet
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
