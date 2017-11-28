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
    /// SetTopicAttributes
    /// Allows a topic owner to update the attribute of a topic to a new value.
    /// </summary>
    public class SetTopicAttributes : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SetTopicAttributes Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SetTopicAttributes(TembooSession session) : base(session, "/Library/Amazon/SNS/SetTopicAttributes")
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
         /// (required, string) The name of the attribute you want to modify. Valid values are: Policy and DisplayName.
         /// </summary>
         /// <param name="value">Value of the AttributeName input for this Choreo.</param>
         public void setAttributeName(String value) {
             base.addInput ("AttributeName", value);
         }
         /// <summary>
         /// (required, string) The new value for the attribute that you want to update.
         /// </summary>
         /// <param name="value">Value of the AttributeValue input for this Choreo.</param>
         public void setAttributeValue(String value) {
             base.addInput ("AttributeValue", value);
         }
         /// <summary>
         /// (required, string) The ARN of the topic that has an attribute that you want to set.
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
        /// <returns>A SetTopicAttributesResultSet containing execution metadata and results.</returns>
        new public SetTopicAttributesResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SetTopicAttributesResultSet results = new JavaScriptSerializer().Deserialize<SetTopicAttributesResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SetTopicAttributes Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SetTopicAttributesResultSet : Temboo.Core.ResultSet
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
