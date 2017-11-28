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
    /// ReceiveMessage
    /// Returns one or more messages from the specified queue.
    /// </summary>
    public class ReceiveMessage : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ReceiveMessage Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ReceiveMessage(TembooSession session) : base(session, "/Library/Amazon/SQS/ReceiveMessage")
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
         /// (required, integer) The id for the AWS account associated with the queue you're retrieving a message from (remove all dashes in the account number).
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
         /// (optional, string) The attribute you wish to return. Values are: All (default), SenderId, SentTimestamp, ApproximateReceiveCount, or ApproximateFirstReceiveTimestamp.
         /// </summary>
         /// <param name="value">Value of the AttributeName input for this Choreo.</param>
         public void setAttributeName(String value) {
             base.addInput ("AttributeName", value);
         }
         /// <summary>
         /// (optional, integer) The maximum number of messages to return. Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the MaxNumberOfMessages input for this Choreo.</param>
         public void setMaxNumberOfMessages(String value) {
             base.addInput ("MaxNumberOfMessages", value);
         }
         /// <summary>
         /// (optional, string) The name of a message attribute to return. You can return all of the attributes by specifying "All".
         /// </summary>
         /// <param name="value">Value of the MessageAttributeName input for this Choreo.</param>
         public void setMessageAttributeName(String value) {
             base.addInput ("MessageAttributeName", value);
         }
         /// <summary>
         /// (required, string) The name of the queue you want to retrieve a message from.
         /// </summary>
         /// <param name="value">Value of the QueueName input for this Choreo.</param>
         public void setQueueName(String value) {
             base.addInput ("QueueName", value);
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
         /// (optional, integer) The duration (in seconds) that the received messages are hidden from future retrieve requests after a ReceiveMessage request (max is 43200).
         /// </summary>
         /// <param name="value">Value of the VisibilityTimeout input for this Choreo.</param>
         public void setVisibilityTimeout(String value) {
             base.addInput ("VisibilityTimeout", value);
         }
         /// <summary>
         /// (optional, integer) The duration (in seconds) for which the call will wait for a message to arrive in the queue before returning. If a message is available, the call will return sooner than WaitTimeSeconds.
         /// </summary>
         /// <param name="value">Value of the WaitTimeSeconds input for this Choreo.</param>
         public void setWaitTimeSeconds(String value) {
             base.addInput ("WaitTimeSeconds", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ReceiveMessageResultSet containing execution metadata and results.</returns>
        new public ReceiveMessageResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ReceiveMessageResultSet results = new JavaScriptSerializer().Deserialize<ReceiveMessageResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ReceiveMessage Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ReceiveMessageResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Body" output from this Choreo execution
        /// <returns>String - (string) The body of the latest message.</returns>
        /// </summary>
        public String Body
        {
            get
            {
                return (String) base.Output["Body"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "MessageId" output from this Choreo execution
        /// <returns>String - (string) A unique identifier for the latest message.</returns>
        /// </summary>
        public String MessageId
        {
            get
            {
                return (String) base.Output["MessageId"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "ReceiptHandle" output from this Choreo execution
        /// <returns>String - (string) An identifier associated with the act of receiving the message. A new receipt handle is returned every time you receive a message. Provide the last received receipt handle to delete the message.</returns>
        /// </summary>
        public String ReceiptHandle
        {
            get
            {
                return (String) base.Output["ReceiptHandle"];
            }
        }
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
