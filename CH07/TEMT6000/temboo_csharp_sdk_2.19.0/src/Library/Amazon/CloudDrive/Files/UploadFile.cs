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

namespace Temboo.Library.Amazon.CloudDrive.Files
{
    /// <summary>
    /// UploadFile
    /// Calls the Amazon Cloud Drive API to upload a file to Amazon Cloud Drive.
    /// </summary>
    public class UploadFile : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UploadFile Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UploadFile(TembooSession session) : base(session, "/Library/Amazon/CloudDrive/Files/UploadFile")
        {
        }

         /// <summary>
         /// (optional, string) A valid access token retrieved during the OAuth process. This is required unless you provide the ClientID, ClientSecret, and RefreshToken to generate a new access token.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (conditional, string) The Client ID provided by Amazon. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (conditional, string) The Client Secret provided by Amazon. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientSecret input for this Choreo.</param>
         public void setClientSecret(String value) {
             base.addInput ("ClientSecret", value);
         }
         /// <summary>
         /// (required, string) The Content-Type of the file that is being uploaded (e.g., image/jpeg, text/plain, etc.) Defaults to application/octet-stream.
         /// </summary>
         /// <param name="value">Value of the ContentType input for this Choreo.</param>
         public void setContentType(String value) {
             base.addInput ("ContentType", value);
         }
         /// <summary>
         /// (optional, string) The appropriate contentUrl for your account. When not provided, the Choreo will lookup the URL using the Account.GetEndpoint Choreo.
         /// </summary>
         /// <param name="value">Value of the ContentURL input for this Choreo.</param>
         public void setContentURL(String value) {
             base.addInput ("ContentURL", value);
         }
         /// <summary>
         /// (conditional, string) The Base64 encoded contents of the file to upload.
         /// </summary>
         /// <param name="value">Value of the FileContent input for this Choreo.</param>
         public void setFileContent(String value) {
             base.addInput ("FileContent", value);
         }
         /// <summary>
         /// (optional, boolean) Whether or not to perform a retry sequence if a throttling error occurs. Set to true to enable this feature. The request will be retried up-to five times when enabled.
         /// </summary>
         /// <param name="value">Value of the HandleRequestThrottling input for this Choreo.</param>
         public void setHandleRequestThrottling(String value) {
             base.addInput ("HandleRequestThrottling", value);
         }
         /// <summary>
         /// (optional, json) A JSON array containing labels to apply to the file.
         /// </summary>
         /// <param name="value">Value of the Labels input for this Choreo.</param>
         public void setLabels(String value) {
             base.addInput ("Labels", value);
         }
         /// <summary>
         /// (optional, string) A unique ID within the application. Multiple POSTs with the same localId from the same application will result in the same node-id. If not provided the server will generate a node-id.
         /// </summary>
         /// <param name="value">Value of the LocalID input for this Choreo.</param>
         public void setLocalID(String value) {
             base.addInput ("LocalID", value);
         }
         /// <summary>
         /// (required, string) The name of the file being uploaded.
         /// </summary>
         /// <param name="value">Value of the Name input for this Choreo.</param>
         public void setName(String value) {
             base.addInput ("Name", value);
         }
         /// <summary>
         /// (optional, json) A JSON array containing parent IDs associated with the new folder.
         /// </summary>
         /// <param name="value">Value of the Parents input for this Choreo.</param>
         public void setParents(String value) {
             base.addInput ("Parents", value);
         }
         /// <summary>
         /// (optional, json) A JSON object containing properties to be applied to the file.
         /// </summary>
         /// <param name="value">Value of the Properties input for this Choreo.</param>
         public void setProperties(String value) {
             base.addInput ("Properties", value);
         }
         /// <summary>
         /// (conditional, string) An OAuth refresh token used to generate a new access token when the original token is expired. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the RefreshToken input for this Choreo.</param>
         public void setRefreshToken(String value) {
             base.addInput ("RefreshToken", value);
         }
         /// <summary>
         /// (optional, string) Valid values are: "deduplication" (disables checking for duplicates when uploading) and "process" (disables any processing Amazon may do on the file).
         /// </summary>
         /// <param name="value">Value of the Supress input for this Choreo.</param>
         public void setSupress(String value) {
             base.addInput ("Supress", value);
         }


        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UploadFileResultSet containing execution metadata and results.</returns>
        new public UploadFileResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UploadFileResultSet results = new JavaScriptSerializer().Deserialize<UploadFileResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UploadFile Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UploadFileResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "NewAccessToken" output from this Choreo execution
        /// <returns>String - (string) Contains a new AccessToken when the RefreshToken is provided.</returns>
        /// </summary>
        public String NewAccessToken
        {
            get
            {
                return (String) base.Output["NewAccessToken"];
            }
        }
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
