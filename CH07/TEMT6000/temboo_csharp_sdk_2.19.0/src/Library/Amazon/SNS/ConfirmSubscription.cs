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

namespace Temboo.Library.Amazon.SNS
{
    /// <summary>
    /// ConfirmSubscription
    /// Verifies that the endpoint owner wishes to receive messages by verifying the token sent during the Subscribe action.
    /// </summary>
    public class ConfirmSubscription : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the ConfirmSubscription Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public ConfirmSubscription(TembooSession session) : base(session, "/Library/Amazon/SNS/ConfirmSubscription")
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
         /// (optional, boolean) Indicates that you want to disable the ability to unsubscribe from the subscription without authenticating. Specify 1 to enable this flag.
         /// </summary>
         /// <param name="value">Value of the AuthenticateOnUnsubscribed input for this Choreo.</param>
         public void setAuthenticateOnUnsubscribed(String value) {
             base.addInput ("AuthenticateOnUnsubscribed", value);
         }
         /// <summary>
         /// (required, string) The short-lived token sent to an endpoint during the Subscribe action.
         /// </summary>
         /// <param name="value">Value of the Token input for this Choreo.</param>
         public void setToken(String value) {
             base.addInput ("Token", value);
         }
         /// <summary>
         /// (required, string) The ARN of the topic you want to confirm a subscription for.
         /// </summary>
         /// <param name="value">Value of the TopicArn input for this Choreo.</param>
         public void setTopicArn(String value) {
             base.addInput ("TopicArn", value);
         }
         /// <summary>
         /// (optional, string) The AWS region that corresponds to the SNS endpoint you wish to access. The default region is "us-east-1". See description below for valid values.
         /// </summary>
         /// <param name="value">Value of the UserRegion input for this Choreo.</param>
         public void setUserRegion(String value) {
             base.addInput ("UserRegion", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A ConfirmSubscriptionResultSet containing execution metadata and results.</returns>
        new public ConfirmSubscriptionResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            ConfirmSubscriptionResultSet results = new JavaScriptSerializer().Deserialize<ConfirmSubscriptionResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the ConfirmSubscription Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class ConfirmSubscriptionResultSet : Temboo.Core.ResultSet
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
