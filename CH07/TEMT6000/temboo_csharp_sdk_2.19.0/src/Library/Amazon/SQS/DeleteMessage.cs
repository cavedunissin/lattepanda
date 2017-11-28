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

namespace Temboo.Library.Amazon.SQS
{
    /// <summary>
    /// DeleteMessage
    /// Deletes a particular message from a specified queue.
    /// </summary>
    public class DeleteMessage : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the DeleteMessage Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public DeleteMessage(TembooSession session) : base(session, "/Library/Amazon/SQS/DeleteMessage")
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
         /// (required, integer) The AWS account id associated with the queue. Enter account number omitting any dashes.
         /// </summary>
         /// <param name="value">Value of the AWSAccountId input for this Choreo.</param>
         public void setAWSAccountId(String value) {
             base.addInput ("AWSAccountId", value);
         }
         /// <summary>
         /// (required, string) The Secret Key ID provided by Amazon Web Services.
         /// </summary>
         /// <param name="value">Value of the AWSSecretKeyId input for this Choreo.</param>
         public void setAWSSecretKeyId(String value) {
             base.addInput ("AWSSecretKeyId", value);
         }
         /// <summary>
         /// (required, string) The name of the queue that contains the message you want to delete.
         /// </summary>
         /// <param name="value">Value of the QueueName input for this Choreo.</param>
         public void setQueueName(String value) {
             base.addInput ("QueueName", value);
         }
         /// <summary>
         /// (required, string) The receipt handle associated with the message you want to delete. This is returned in the RecieveMessage request.
         /// </summary>
         /// <param name="value">Value of the ReceiptHandle input for this Choreo.</param>
         public void setReceiptHandle(String value) {
             base.addInput ("ReceiptHandle", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are "xml" (the default) and "json".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) The AWS region that corresponds to the SQS endpoint you wish to access. The default region is "us-east-1". See description below for valid values.
         /// </summary>
         /// <param name="value">Value of the UserRegion input for this Choreo.</param>
         public void setUserRegion(String value) {
             base.addInput ("UserRegion", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A DeleteMessageResultSet containing execution metadata and results.</returns>
        new public DeleteMessageResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            DeleteMessageResultSet results = new JavaScriptSerializer().Deserialize<DeleteMessageResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the DeleteMessage Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class DeleteMessageResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Amazon.</returns>
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
