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

namespace Temboo.Library.Google.Drive.Files
{
    /// <summary>
    /// Get
    /// Gets a file's metadata and content by ID.
    /// </summary>
    public class Get : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the Get Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public Get(TembooSession session) : base(session, "/Library/Google/Drive/Files/Get")
        {
        }

         /// <summary>
         /// (optional, string) A valid access token retrieved during the OAuth2 process. This is required unless you provide the ClientID, ClientSecret, and RefreshToken to generate a new access token.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (conditional, string) The Client ID provided by Google. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientID input for this Choreo.</param>
         public void setClientID(String value) {
             base.addInput ("ClientID", value);
         }
         /// <summary>
         /// (conditional, string) The Client Secret provided by Google. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the ClientSecret input for this Choreo.</param>
         public void setClientSecret(String value) {
             base.addInput ("ClientSecret", value);
         }
         /// <summary>
         /// (optional, string) Indicates the download format (i.e. pdf, doc, txt, rtf, odt, etc). When specified, the FileContent output will contain the file's base64 encoded value.
         /// </summary>
         /// <param name="value">Value of the ExportFormat input for this Choreo.</param>
         public void setExportFormat(String value) {
             base.addInput ("ExportFormat", value);
         }
         /// <summary>
         /// (optional, string) Selector specifying a subset of fields to include in the response.
         /// </summary>
         /// <param name="value">Value of the Fields input for this Choreo.</param>
         public void setFields(String value) {
             base.addInput ("Fields", value);
         }
         /// <summary>
         /// (required, string) The ID of the file to retrieve.
         /// </summary>
         /// <param name="value">Value of the FileID input for this Choreo.</param>
         public void setFileID(String value) {
             base.addInput ("FileID", value);
         }
         /// <summary>
         /// (conditional, string) An OAuth refresh token used to generate a new access token when the original token is expired. Required unless providing a valid AccessToken.
         /// </summary>
         /// <param name="value">Value of the RefreshToken input for this Choreo.</param>
         public void setRefreshToken(String value) {
             base.addInput ("RefreshToken", value);
         }
         /// <summary>
         /// (optional, boolean) Whether to update the view date after successfully retrieving the file. Default value is false.
         /// </summary>
         /// <param name="value">Value of the UpdateViewDate input for this Choreo.</param>
         public void setUpdateViewDate(String value) {
             base.addInput ("UpdateViewDate", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetResultSet containing execution metadata and results.</returns>
        new public GetResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetResultSet results = new JavaScriptSerializer().Deserialize<GetResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the Get Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "FileContent" output from this Choreo execution
        /// <returns>String - (string) The Base64 encoded file content. Only returned when the optional "Format" parameter is provided.</returns>
        /// </summary>
        public String FileContent
        {
            get
            {
                return (String) base.Output["FileContent"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "FileMetadata" output from this Choreo execution
        /// <returns>String - (json) The file metadata returned in the response from Google.</returns>
        /// </summary>
        public String FileMetadata
        {
            get
            {
                return (String) base.Output["FileMetadata"];
            }
        }
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
    }
}
