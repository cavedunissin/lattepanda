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
    /// DeleteAccessKey
    /// Deletes the access key associated with the specified user.
    /// </summary>
    public class DeleteAccessKey : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the DeleteAccessKey Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public DeleteAccessKey(TembooSession session) : base(session, "/Library/Amazon/IAM/DeleteAccessKey")
        {
        }

         /// <summary>
         /// (required, string) An AWS Access Key ID with sufficient permissions to delete the specified AccessKeyId.
         /// </summary>
         /// <param name="value">Value of the AWSAccessKeyId input for this Choreo.</param>
         public void setAWSAccessKeyId(String value) {
             base.addInput ("AWSAccessKeyId", value);
         }
         /// <summary>
         /// (required, string) The Secret Key ID associated with the AWS AccessKey ID with sufficient permissions to delete the AccessKeyId.
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
         /// (conditional, string) Name of the user whose key you want to delete.  If you do not specify a user name, IAM determines the user name implicitly based on the AWS Access Key ID signing the request.
         /// </summary>
         /// <param name="value">Value of the UserName input for this Choreo.</param>
         public void setUserName(String value) {
             base.addInput ("UserName", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A DeleteAccessKeyResultSet containing execution metadata and results.</returns>
        new public DeleteAccessKeyResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            DeleteAccessKeyResultSet results = new JavaScriptSerializer().Deserialize<DeleteAccessKeyResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the DeleteAccessKey Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class DeleteAccessKeyResultSet : Temboo.Core.ResultSet
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
