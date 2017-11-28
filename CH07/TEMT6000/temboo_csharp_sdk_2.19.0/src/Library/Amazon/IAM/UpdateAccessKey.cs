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

namespace Temboo.Library.Amazon.IAM
{
    /// <summary>
    /// UpdateAccessKey
    /// Changes the status of the specified access key from Active to Inactive, or vice versa. This action can be used to disable a user's key as part of a key rotation workflow.
    /// </summary>
    public class UpdateAccessKey : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateAccessKey Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateAccessKey(TembooSession session) : base(session, "/Library/Amazon/IAM/UpdateAccessKey")
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
         /// (conditional, string) The Access Key ID for the Access Key ID and Secret Access Key you want to delete.
         /// </summary>
         /// <param name="value">Value of the AccessKeyId input for this Choreo.</param>
         public void setAccessKeyId(String value) {
             base.addInput ("AccessKeyId", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are "xml" (the default) and "json".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) The status you want to assign to the Secret Access Key. Active means the key can be used for API calls to AWS, while Inactive means the key cannot be used.
         /// </summary>
         /// <param name="value">Value of the Status input for this Choreo.</param>
         public void setStatus(String value) {
             base.addInput ("Status", value);
         }
         /// <summary>
         /// (conditional, string) Name of the user whose key you want to update.  If the UserName field is not specified, the UserName is determined implicitly based on the AWS Access Key ID used to sign the request.
         /// </summary>
         /// <param name="value">Value of the UserName input for this Choreo.</param>
         public void setUserName(String value) {
             base.addInput ("UserName", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UpdateAccessKeyResultSet containing execution metadata and results.</returns>
        new public UpdateAccessKeyResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateAccessKeyResultSet results = new JavaScriptSerializer().Deserialize<UpdateAccessKeyResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateAccessKey Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateAccessKeyResultSet : Temboo.Core.ResultSet
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
