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
    /// CreateQueue
    /// Creates a new queue with a specified queue name.
    /// </summary>
    public class CreateQueue : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateQueue Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateQueue(TembooSession session) : base(session, "/Library/Amazon/SQS/CreateQueue")
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
         /// (optional, integer) The visibility timeout for the queue. An integer from 0 to 43200 (12 hours). The default for this attribute is 30.
         /// </summary>
         /// <param name="value">Value of the DefaultVisibilityTimeout input for this Choreo.</param>
         public void setDefaultVisibilityTimeout(String value) {
             base.addInput ("DefaultVisibilityTimeout", value);
         }
         /// <summary>
         /// (optional, integer) The limit of how many bytes a message can contain before Amazon SQS rejects it. An integer from 1024 bytes (1 KiB) up to 262144 bytes (256 KiB)
         /// </summary>
         /// <param name="value">Value of the MaximumMessageSize input for this Choreo.</param>
         public void setMaximumMessageSize(String value) {
             base.addInput ("MaximumMessageSize", value);
         }
         /// <summary>
         /// (optional, integer) The number of seconds Amazon SQS retains a message. Integer representing seconds, from 60 (1 minute) to 1209600 (14 days). The default for this attribute is 345600 (4 days).
         /// </summary>
         /// <param name="value">Value of the MessageRetentionPeriod input for this Choreo.</param>
         public void setMessageRetentionPeriod(String value) {
             base.addInput ("MessageRetentionPeriod", value);
         }
         /// <summary>
         /// (optional, json) The queue's policy.
         /// </summary>
         /// <param name="value">Value of the Policy input for this Choreo.</param>
         public void setPolicy(String value) {
             base.addInput ("Policy", value);
         }
         /// <summary>
         /// (required, string) The name of the queue you want to create.
         /// </summary>
         /// <param name="value">Value of the QueueName input for this Choreo.</param>
         public void setQueueName(String value) {
             base.addInput ("QueueName", value);
         }
         /// <summary>
         /// (optional, integer) The time for which a ReceiveMessage call will wait for a message to arrive. An integer from 0 to 20 (seconds). The default for this attribute is 0.
         /// </summary>
         /// <param name="value">Value of the ReceiveMessageWaitTimeSeconds input for this Choreo.</param>
         public void setReceiveMessageWaitTimeSeconds(String value) {
             base.addInput ("ReceiveMessageWaitTimeSeconds", value);
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
        /// <returns>A CreateQueueResultSet containing execution metadata and results.</returns>
        new public CreateQueueResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateQueueResultSet results = new JavaScriptSerializer().Deserialize<CreateQueueResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateQueue Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateQueueResultSet : Temboo.Core.ResultSet
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
