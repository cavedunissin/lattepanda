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

namespace Temboo.Library.Dropbox.FilesAndMetadata
{
    /// <summary>
    /// UploadFile
    /// Uploads a file to your Dropbox account.
    /// </summary>
    public class UploadFile : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UploadFile Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UploadFile(TembooSession session) : base(session, "/Library/Dropbox/FilesAndMetadata/UploadFile")
        {
        }

         /// <summary>
         /// (conditional, string) The Base64-encoded contents of the file you want to upload. Required UNLESS uploading a file from a URL using the FileContentsFromURL input variable.
         /// </summary>
         /// <param name="value">Value of the FileContents input for this Choreo.</param>
         public void setFileContents(String value) {
             base.addInput ("FileContents", value);
         }
         /// <summary>
         /// (required, string) The Access Token retrieved during the OAuth process.
         /// </summary>
         /// <param name="value">Value of the AccessToken input for this Choreo.</param>
         public void setAccessToken(String value) {
             base.addInput ("AccessToken", value);
         }
         /// <summary>
         /// (required, string) The Access Token Secret retrieved during the OAuth process.
         /// </summary>
         /// <param name="value">Value of the AccessTokenSecret input for this Choreo.</param>
         public void setAccessTokenSecret(String value) {
             base.addInput ("AccessTokenSecret", value);
         }
         /// <summary>
         /// (required, string) The App Key provided by Dropbox (AKA the OAuth Consumer Key).
         /// </summary>
         /// <param name="value">Value of the AppKey input for this Choreo.</param>
         public void setAppKey(String value) {
             base.addInput ("AppKey", value);
         }
         /// <summary>
         /// (required, string) The App Secret provided by Dropbox (AKA the OAuth Consumer Secret).
         /// </summary>
         /// <param name="value">Value of the AppSecret input for this Choreo.</param>
         public void setAppSecret(String value) {
             base.addInput ("AppSecret", value);
         }
         /// <summary>
         /// (conditional, string) URL for file you want to upload. Alternative to uploading Base64Encoded data. If specifiying URL, leave FileContents blank. Valid URLs: http(s) requests only.
         /// </summary>
         /// <param name="value">Value of the FileContentsFromURL input for this Choreo.</param>
         public void setFileContentsFromURL(String value) {
             base.addInput ("FileContentsFromURL", value);
         }
         /// <summary>
         /// (required, string) The name of the file you are uploading to Dropbox.
         /// </summary>
         /// <param name="value">Value of the FileName input for this Choreo.</param>
         public void setFileName(String value) {
             base.addInput ("FileName", value);
         }
         /// <summary>
         /// (optional, string) The name of the folder that that you want to upload a file to. A path to a sub-folder is also valid (i.e. /RootFolder/SubFolder).
         /// </summary>
         /// <param name="value">Value of the Folder input for this Choreo.</param>
         public void setFolder(String value) {
             base.addInput ("Folder", value);
         }
         /// <summary>
         /// (optional, string) The format that the response should be in. Can be set to xml or json. Defaults to json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (optional, string) Defaults to "auto" which automatically determines the root folder using your app's permission level. Other options are "sandbox" (App Folder) and "dropbox" (Full Dropbox).
         /// </summary>
         /// <param name="value">Value of the Root input for this Choreo.</param>
         public void setRoot(String value) {
             base.addInput ("Root", value);
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
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Dropbox. Corresponds to the ResponseFormat input. Defaults to json.</returns>
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
