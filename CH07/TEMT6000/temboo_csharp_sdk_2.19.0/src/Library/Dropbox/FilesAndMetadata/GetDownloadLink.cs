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
    /// GetDownloadLink
    /// Retrieves a direct download link allowing an application to stream the contents of the media.
    /// </summary>
    public class GetDownloadLink : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetDownloadLink Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetDownloadLink(TembooSession session) : base(session, "/Library/Dropbox/FilesAndMetadata/GetDownloadLink")
        {
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
         /// (required, string) The path to the file or folder you want to return a download link for (i.e. /RootFolder/SubFolder/MyFile.txt).
         /// </summary>
         /// <param name="value">Value of the Path input for this Choreo.</param>
         public void setPath(String value) {
             base.addInput ("Path", value);
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
        /// <returns>A GetDownloadLinkResultSet containing execution metadata and results.</returns>
        new public GetDownloadLinkResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetDownloadLinkResultSet results = new JavaScriptSerializer().Deserialize<GetDownloadLinkResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetDownloadLink Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetDownloadLinkResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "URL" output from this Choreo execution
        /// <returns>String - (string) The file's download URL.</returns>
        /// </summary>
        public String URL
        {
            get
            {
                return (String) base.Output["URL"];
            }
        }
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
