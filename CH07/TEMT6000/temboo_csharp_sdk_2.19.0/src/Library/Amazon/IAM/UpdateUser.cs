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
    /// UpdateUser
    /// Updates the name and/or the path of a specified user.
    /// </summary>
    public class UpdateUser : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateUser Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateUser(TembooSession session) : base(session, "/Library/Amazon/IAM/UpdateUser")
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
         /// (optional, string) The new path for the user. Include a value here only if you are changing the user's existing path. The path needs to start with and end with a slash(/).  For example, "/Division/HR/".
         /// </summary>
         /// <param name="value">Value of the NewPath input for this Choreo.</param>
         public void setNewPath(String value) {
             base.addInput ("NewPath", value);
         }
         /// <summary>
         /// (optional, string) The new name of the user. Include a value here only if you are updating the user's name.
         /// </summary>
         /// <param name="value">Value of the NewUserName input for this Choreo.</param>
         public void setNewUserName(String value) {
             base.addInput ("NewUserName", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are "xml" (the default) and "json".
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) The name of the user to update.
         /// </summary>
         /// <param name="value">Value of the UserName input for this Choreo.</param>
         public void setUserName(String value) {
             base.addInput ("UserName", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UpdateUserResultSet containing execution metadata and results.</returns>
        new public UpdateUserResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateUserResultSet results = new JavaScriptSerializer().Deserialize<UpdateUserResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateUser Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateUserResultSet : Temboo.Core.ResultSet
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
